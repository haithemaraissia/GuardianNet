// GuardianNet/GuardianNet/Fields.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System;

namespace GuardianNet.Models
{
    public class Fields
    {
        public string Thumbnail { get; set; }
        public DateTime LastModified { get; set; }
        public string ShortUrl { get; set; }
        public bool IsPremoderated { get; set; }
        public int WordCount { get; set; }
        public float Score { get; set; }
    }
}