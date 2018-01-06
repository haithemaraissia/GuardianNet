// GuardianNet/GuardianNet/SearchExecutor.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GuardianNet.Models.Search;

namespace GuardianNet.Executors
{
    internal sealed class SearchExecutor : Executor
    {
        private const string _ENDPOINT = "https://content.guardianapis.com/search";

        internal async Task<SearchResponse> Search(string apiKey, string query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty);

            if (string.IsNullOrWhiteSpace(query))
                throw new InvalidOperationException("Cant create request with null or empty query");

            if (query.Contains(" "))
                reqQuery["q"] = $"\"{query}\"";
            else
                reqQuery["q"] = query;

            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            return await Execute<SearchResponse>(_ENDPOINT + $"?{reqQuery}");
        }

        internal async Task<SearchResponse> Search(string apiKey, SearchQuery query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            var queryString = query.Query.Build();
            if(string.IsNullOrWhiteSpace(queryString))
                throw new InvalidOperationException("Cant create request with null or empty query");

            reqQuery["q"] = queryString;

            if (string.IsNullOrWhiteSpace(query.Section))
                reqQuery["section"] = query.Section;

            if(string.IsNullOrWhiteSpace(query.Tags))
                reqQuery["tag"] = query.Tags;

            if (string.IsNullOrWhiteSpace(query.Lang))
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

            if(query.ShowRights)
                reqQuery["show-rights"] = "all";

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

            reqQuery["show-tags"] = "keyword";
            reqQuery["show-fields"] = @"thumbnail,lastModified,shortUrl,wordcount,commentable,isPremoderated,starRating,score";

            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            return await Execute<SearchResponse>(_ENDPOINT + $"?{reqQuery}");
        }
    }
}