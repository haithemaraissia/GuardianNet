// GuardianNet/GuardianNet/EditionsExecutor.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using GuardianNet.Models.Editions;
using GuardianNet.Models.Search;

namespace GuardianNet.Executors
{
    // Custom logic due we want only IEnumerable of editions not an all response object
    internal class EditionsExecutor : Executor
    {
        private const string _ENDPOINT = "https://content.guardianapis.com/editions";

        private class TempResult
        {
            public string Status { get; set; }
            public int Total { get; set; }
            public List<Edition> Results { get; set; }
        }

        internal async Task<IEnumerable<Edition>> GetEditions(string apiKey)
        {
            var reqQuery = HttpUtility.ParseQueryString(string.Empty);

            reqQuery["format"] = "json";
            reqQuery["api-key"] = apiKey;

            var s = await Execute<TempResult>(_ENDPOINT + $"?{reqQuery}");
            return s.Results;
        }
    }
}