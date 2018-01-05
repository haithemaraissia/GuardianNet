// GuardianNet/GuardianNet/GuardianApi.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using System.Threading.Tasks;
using GuardianNet.Executors;
using GuardianNet.Models.Editions;
using GuardianNet.Models.Search;
using GuardianNet.Models.Sections;
using GuardianNet.Models.Tags;

namespace GuardianNet
{
    public sealed class GuardianApi
    {
        private readonly string _token;
        private readonly SearchExecutor _searchExecutor = new SearchExecutor();
        private readonly TagExecutor _tagExecutor = new TagExecutor();
        private readonly EditionsExecutor _editionsExecutor = new EditionsExecutor();
        private readonly SectionsExecutor _sectionExecutor = new SectionsExecutor();
        
        /// <summary> </summary>
        /// <param name="token">TheGuardian API Token</param>
        public GuardianApi(string token)
            => _token = token;

        // Those comments are possibly written in wrong way. Pls fix it.

        /// <summary>
        /// Fetch Guardian database with specified query
        /// </summary>
        /// <param name="query">Phrase to search. Space in string will flag search query as exact</param>
        /// <returns>Response object</returns>
        public async Task<SearchResponse> SearchAsync(string query)
            => await _searchExecutor.Search(_token, query);

        /// <summary>
        /// Search in API with SearchQuery object.
        /// </summary>
        /// <param name="query">SearchQuery object containing few parameters</param>
        /// <returns>response object</returns>
        public async Task<SearchResponse> SearchAsync(SearchQuery query)
            => await _searchExecutor.Search(_token, query);

        /// <summary>
        /// Search in tags API endpoint.
        /// </summary>
        /// <param name="query">Phrase to search</param>
        /// <returns>Response object</returns>
        public async Task<TagResponse> GetTagsAsync(string query)
            => await _tagExecutor.Search(_token, query);

        /// <summary>
        /// Search in tags API endpoint with query object.
        /// </summary>
        /// <param name="query">Query object to search in enpoint</param>
        /// <returns>Returns Response object</returns>
        public async Task<TagResponse> GetTagsAsync(TagQuery query)
            => await _tagExecutor.Search(_token, query);

        /// <summary>
        /// Fetches editions from Guardian. For now we have 4 editions.
        /// </summary>
        /// <returns>IEnumerale of Edition object</returns>
        public async Task<IEnumerable<Edition>> GetEditionsAsync()
            => await _editionsExecutor.GetEditions(_token);

        /// <summary>
        /// Fetch sections within specified query
        /// </summary>
        /// <param name="query">Phrase to search</param>
        /// <returns>IEnumerable of Section object</returns>
        public async Task<IEnumerable<Section>> GetSectionsAsync(string query)
            => await _sectionExecutor.Search(_token, query);
    }
}