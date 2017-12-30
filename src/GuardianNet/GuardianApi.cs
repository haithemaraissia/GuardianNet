// GuardianNet/GuardianNet/GuardianApi.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using System.Threading.Tasks;
using GuardianNet.Models;

namespace GuardianNet
{
    public class GuardianApi
    {
        private readonly string _token;
        private readonly QueryExecutor Executor = new QueryExecutor();
        
        public GuardianApi(string token)
            => _token = token;

        public async Task<Response> Search(string query)
            => await Executor.Search(_token, query);

        public async Task<Response> Search(SearchQuery query)
            => await Executor.Search(_token, query);
    }
}