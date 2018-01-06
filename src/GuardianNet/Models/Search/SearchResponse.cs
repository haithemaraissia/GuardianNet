// GuardianNet/GuardianNet/SearchResponse.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;

namespace GuardianNet.Models.Search
{
    public sealed class SearchResponse : IResponse
    {
        public List<SearchResult> Results { get; set; }
        public string Status { get; set; }
        public string UserTier { get; set; }
        public int Total { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public OrderBy OrderBy { get; set; }
    }
}