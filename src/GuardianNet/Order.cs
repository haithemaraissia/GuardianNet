// GuardianNet/GuardianNet/Order.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis
namespace GuardianNet
{
    public enum OrderBy
    {
        Newest,
        Oldest,
        Relevance
    }

    public enum OrderDate
    {
        Published,
        NewspaperEdition,
        LastModified
    }
}