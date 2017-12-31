﻿// GuardianNet/GuardianNetTest/QuerySearchTest.cs
// 
// Created at: 30/12/2017
// Author: Szymon 'l7ssha' Uglis

using System;
using System.IO;
using System.Threading.Tasks;
using GuardianNet;
using Xunit;

namespace GuardianNetTest
{
    public class QuerySearchTest
    {
        public GuardianApi GetApi()
        {
            var token = File.ReadAllText("token.txt");
            return new GuardianApi(token);
        }

        [Theory]
        [InlineData("Terrorism")]
        [InlineData("Trump")]
        public async Task QueryTest(object query)
        {
            var guard = GetApi();

            var res = await guard.Search((string)query);

            Assert.True(res.CurrentPage == 1);
            Assert.True(res.Results.Count > 5);
            Assert.True(res.Status == "ok");
        }

        [Fact]
        public async Task AdvencedQueryTest()
        {
            var guard = GetApi();

            var qq = new SearchQuery
            {
                Query = new Query().Add("Terrorism").Add("Trump"),
                OrderBy = OrderBy.Relevance,
                StarRating = 5,
                PageSize = 10
            };
            var res = await guard.Search(qq);

            Assert.True(res.CurrentPage == 1);
            Assert.True(res.PageSize == 10);
            Assert.True(res.Results.Count > 5);
            Assert.True(res.Status == "ok");
        }
    }
}