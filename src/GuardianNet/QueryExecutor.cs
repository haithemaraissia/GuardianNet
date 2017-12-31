// GuardianNet/GuardianNet/QueryExecutor.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GuardianNet.Models;
using Newtonsoft.Json.Linq;

namespace GuardianNet
{
    public class QueryExecutor
    {
        private const string _CONTENT_ENDPOINT = "https://content.guardianapis.com/search";
        
        private readonly HttpClient _client = new HttpClient();

        public async Task<Response> Search(string apiKey, string query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty);

            if(query.Contains(" "))
                reqQuery["q"] = $"\"{query}\"";
            else
                reqQuery["q"] = query;

            reqQuery["api-key"] = apiKey;

            return await Search(_CONTENT_ENDPOINT + $"?{reqQuery}");
        }

        public async Task<Response> Search(string apiKey, SearchQuery query)
        {

            var reqQuery = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            reqQuery["q"] = query.Query.Build();

            if (query.Section != null)
                reqQuery["section"] = query.Section;

            if (query.Tags.Count > 0)
                reqQuery["tag"] = query.GetTagsString();

            if (query.Lang != null)
                reqQuery["lang"] = query.Lang;

            if (query.StarRating > 0)
                reqQuery["star-rating"] = query.StarRating.ToString();

            if (query.Page > 0)
                reqQuery["page"] = query.Page.ToString();

            if (query.PageSize > 0)
                reqQuery["page-size"] = query.PageSize.ToString();

            if(query.OrderBy != null)
                reqQuery["order-by"] = query.OrderBy.ToString().ToLowerInvariant();

            if(query.DateQuery != null)
            {
                if(query.DateQuery.Type == DateQuery.Date.ToDate)
                    reqQuery["to-date"] = query.DateQuery.DateTime.ToString("yyyy-MM-dd");
                else
                    reqQuery["from-date"] = query.DateQuery.DateTime.ToString("yyyy-MM-dd");
            }

            if(query.OrderDate != null)
            {
                string res = String.Empty;
                switch(query.OrderDate)
                {
                    case OrderDate.Published:
                        res = "published";
                        break;
                    case OrderDate.NewspaperEdition:
                        res = "newspaper-edition";
                        break;
                    case OrderDate.LastModified:
                        res = "last-modified";
                        break;
                }
                reqQuery["order-date"] = res;
            }

            reqQuery["show-fields"] = @"thumbnail,lastModified,shortUrl,wordcount,commentable,isPremoderated,commentCloseDate,starRating";
            reqQuery["api-key"] = apiKey;

            return await Search(_CONTENT_ENDPOINT + $"?{reqQuery}");
        }

        private async Task<Response> Search(string q)
        {
            //var qq = q.Replace("+", "%20");

            HttpResponseMessage response = await _client.GetAsync(q);

            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("TheGuardianError");

            var resp = await response.Content.ReadAsStringAsync();
            var temp = JObject.Parse(resp);
            var obj = temp["response"].ToObject<Response>();

            if(obj.Status != "ok" || obj.Pages <= 0)
                throw new InvalidOperationException("No results");

            return obj;
        }
    }
}