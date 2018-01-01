// GuardianNet/GuardianNet/SectionsExecutor.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using GuardianNet.Models.Sections;

namespace GuardianNet.Executors
{
    internal class SectionsExecutor : Executor
    {
        private const string _ENDPOINT = "https://content.guardianapis.com/sections";

        private class TempResponse
        {
            public IEnumerable<Section> Results { get; set; }
        }

        public async Task<IEnumerable<Section>> Search(string apiKey, string query)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty);

            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            var s = await Execute<TempResponse>(_ENDPOINT + $"?{reqQuery}");
            return s.Results;
        }
    }
}