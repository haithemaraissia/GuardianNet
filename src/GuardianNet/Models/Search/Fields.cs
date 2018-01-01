// GuardianNet/GuardianNet/Fields.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System;

namespace GuardianNet.Models.Search
{
    public class Fields
    {
        public string Thumbnail { get; internal set; }
        public DateTime LastModified { get; internal set; }
        public string ShortUrl { get; internal set; }
        public bool IsPremoderated { get; internal set; }
        public int WordCount { get; internal set; }
        public float Score { get; internal set; }
    }
}