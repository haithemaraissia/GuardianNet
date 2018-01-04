// GuardianNet/GuardianNet/TagExecutor.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis
using GuardianNet.Models.Tags;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GuardianNet.Executors
{
    internal sealed class TagExecutor : Executor
    {
        private const string _ENDPOINT = "http://content.guardianapis.com/tags";

        internal async Task<TagResponse> Search(string apiKey, string query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            reqQuery["q"] = query;
            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            return await Execute<TagResponse>(_ENDPOINT + $"?{reqQuery}");
        }

        internal async Task<TagResponse> Search(string apiKey, TagQuery query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            reqQuery["q"] = query.Query;

            if (query.Section != null)
                reqQuery["section"] = query.Section;

            if (query.Page > 0)
                reqQuery["page"] = query.Page.ToString();

            if (query.PageSize > 0)
                reqQuery["page-size"] = query.PageSize.ToString();

            if (query.Type != null)
                reqQuery["type"] = query.Type.ToString().ToLowerInvariant();

            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            return await Execute<TagResponse>(_ENDPOINT + $"?{reqQuery}");
        }
    }
}