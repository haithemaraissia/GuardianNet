// GuardianNet/GuardianNet/SearchQuery.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System.Collections.Generic;
using System.Text;

namespace GuardianNet
{
    public class SearchQuery
    {
        public SearchQuery() 
            => Tags = new List<string>();

        public Query Query { get; set; }
        public string Section { get; set; }
        public List<string> Tags { get; set; }
        public string Lang { get; set; }
        public int StarRating { get; set; }

        public OrderBy? OrderBy { get; set; }
        public OrderDate? OrderDate { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        internal string GetTagsString()
        {
            StringBuilder str = new StringBuilder();
            foreach(var tag in Tags)
                str.Append($"{tag}/");
            return str.ToString().TrimEnd('/');
        }
    }
}