// GuardianNet/GuardianNetTest/EditionsTest.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System.IO;
using System.Threading.Tasks;
using GuardianNet;
using Xunit;

namespace GuardianNetTest
{
    public class EditionsTest
    {
        public GuardianApi GetApi()
        {
            var token = File.ReadAllText("token.txt");
            return new GuardianApi(token);
        }

        [Fact]
        public async Task GetAllEditionsTest()
        {
            var guardian = GetApi();
            var res = await guardian.GetEditionsAsync();

            Assert.NotNull(res);
        }
    }
}