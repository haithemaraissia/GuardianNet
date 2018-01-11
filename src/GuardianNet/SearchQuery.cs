// GuardianNet/GuardianNet/SearchQuery.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;

namespace GuardianNet
{
    public class SearchQuery
    {
        public Query Query { get; set; }
        public string Section { get; set; }
        public string Tags { get; set; }
        public string Lang { get; set; }
        public int StarRating { get; set; }

        public OrderBy? OrderBy { get; set; }
        public OrderDate? OrderDate { get; set; }

        public DateQuery DateQuery { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool ShowRights { get; set; }
    }

    public class DateQuery
    {
        public DateQuery(DateTime dateTime, Date date)
        {
            DateTime = dateTime;
            Type = date;
        }

        public enum Date
        {
            FromDate,
            ToDate
        }

        public DateTime DateTime { get; }
        public Date Type { get; }
    }
}