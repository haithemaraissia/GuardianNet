// GuardianNet/GuardianNet/GuardianApi.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using System.Threading.Tasks;
using GuardianNet.Executors;
using GuardianNet.Models;
using GuardianNet.Models.Search;
using GuardianNet.Models.Tags;

namespace GuardianNet
{
    public sealed class GuardianApi
    {
        private readonly string _token;
        private readonly SearchExecutor SearchExecutor = new SearchExecutor();
        private readonly TagExecutor TagExecutor = new TagExecutor();
        
        public GuardianApi(string token)
            => _token = token;

        public async Task<SearchResponse> SearchAsync(string query)
            => await SearchExecutor.Search(_token, query);

        public async Task<SearchResponse> SearchAsync(SearchQuery query)
            => await SearchExecutor.Search(_token, query);

        public async Task<TagResponse> GetTagsAsync(string query)
            => await TagExecutor.Search(_token, query);

        public async Task<TagResponse> GetTagsAsync(TagQuery query)
            => await TagExecutor.Search(_token, query);
    }
}