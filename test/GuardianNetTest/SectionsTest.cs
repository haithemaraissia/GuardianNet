// GuardianNet/GuardianNetTest/SectionsTest.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System.IO;
using System.Threading.Tasks;
using GuardianNet;
using Xunit;

namespace GuardianNetTest
{
    public class SectionsTest
    {
        public GuardianApi GetApi()
        {
            var token = File.ReadAllText("token.txt");
            return new GuardianApi(token);
        }

        [Fact]
        public async Task SearchingSectionTest()
        {
            var guard = GetApi();
            var res = await guard.GetSectionsAsync("sport");

            Assert.NotNull(res);
        }
    }
}