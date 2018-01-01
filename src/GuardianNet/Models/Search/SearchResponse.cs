// GuardianNet/GuardianNet/SearchResponse.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuardianNet.Models
{
    public class SearchResponse
    {
        public string Status { get; set; }
        public string UserTier { get; set; }
        public int Total { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public OrderBy OrderBy { get; set; }
        public List<SearchResult> Results { get; set; }
    }
}