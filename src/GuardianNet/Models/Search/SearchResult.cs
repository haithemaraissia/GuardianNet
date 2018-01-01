// GuardianNet/GuardianNet/SearchResult.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Collections.Generic;

namespace GuardianNet.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public DateTime WebPublicationDate { get; set; }
        public bool Commentable { get; set; }
        public int StarRating { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public string ApiUrl { get; set; }
        public bool Hosted { get; set; }
        public string PillarId { get; set; }
        public string PillarName { get; set; }

        public Fields Fields { get; set; }
        public List<Tag> Tags { get; set; }
    }
}