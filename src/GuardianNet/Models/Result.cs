// GuardianNet/GuardianNet/Result.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;

namespace GuardianNet.Models
{
    public class Result
    {
        public string Id { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public DateTime WebPublicatonDate { get; set; }
        public string Thumbnail { get; set; }
        public DateTime LastModified { get; set; }
        public string ShortUrl { get; set; }
        public int WordCount { get; set; }
        public bool Commentable { get; set; }
        public bool IsPremoderated { get; set; }
        public DateTime CommentCloseDate { get; set; }
        public int StarRating { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public string ApiUrl { get; set; }
    }
}