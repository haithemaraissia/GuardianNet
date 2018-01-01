// GuardianNet/GuardianNet/Response.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis
namespace GuardianNet.Models
{
    public interface IResponse
    {
        string Status { get; set; }
        string UserTier { get; set; }
        int Total { get; set; }
        int StartIndex { get; set; }
        int PageSize { get; set; }
        int CurrentPage { get; set; }
        int Pages { get; set; }
    }
}