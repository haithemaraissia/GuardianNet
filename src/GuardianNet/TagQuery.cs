// GuardianNet/GuardianNet/TaqQuery.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis
namespace GuardianNet
{
    public class TagQuery
    {
        public string Query { get; set; }
        public TagType? Type { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Section { get; set; }
    }
}