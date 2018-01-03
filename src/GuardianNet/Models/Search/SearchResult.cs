// GuardianNet/GuardianNet/SearchResult.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Collections.Generic;

namespace GuardianNet.Models.Search
{
    public class SearchResult
    {
        public string Id { get; internal set; }
        public string Type { get; internal set; }
        public string SectionId { get; internal set; }
        public string SectionName { get; internal set; }
        public DateTime WebPublicationDate { get; internal set; }
        public bool Commentable { get; internal set; }
        public int StarRating { get; internal set; }
        public string WebTitle { get; internal set; }
        public string WebUrl { get; internal set; }
        public string ApiUrl { get; internal set; }
        public bool Hosted { get; internal set; }
        public string PillarId { get; internal set; }
        public string PillarName { get; internal set; }

        public Fields Fields { get; internal set; }
        public List<Tag> Tags { get; internal set; }
    }
}