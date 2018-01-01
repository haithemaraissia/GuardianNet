// GuardianNet/GuardianNetTest/TagTest.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System.IO;
using System.Threading.Tasks;
using GuardianNet;
using Xunit;

namespace GuardianNetTest
{
    public class TagTest
    {
        public GuardianApi GetApi()
        {
            var token = File.ReadAllText("token.txt");
            return new GuardianApi(token);
        }

        [Fact]
        public async Task SearchTest()
        {
            var guard = GetApi();
            var res = await guard.GetTagsAsync("Poland");

            Assert.NotNull(res);
            Assert.True(res.Status == "ok");
            Assert.True(res.Results != null && res.Results.Count > 0);
        }

        [Fact]
        public async Task AdvencedSearchTest()
        {
            var guard = GetApi();

            var qq = new TagQuery()
            {
                Type = TagType.Keyword,
                Query = "F1",
                Section = "sport"
            };
            var res = await guard.GetTagsAsync(qq);

            Assert.NotNull(res);
            Assert.True(res.Status == "ok");
            Assert.True(res.Results != null && res.Results.Count > 0);
        }
    }
}