// GuardianNet/GuardianNet/Executor.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Net.Http;
using System.Threading.Tasks;
using GuardianNet.Models;
using Newtonsoft.Json.Linq;

namespace GuardianNet
{
    internal class Executor
    {
        protected readonly HttpClient _client = new HttpClient();

        protected async Task<T> Search<T>(string q)
        {
            //var qq = q.Replace("+", "%20");

            HttpResponseMessage response = await _client.GetAsync(q);

            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("TheGuardian Error");

            var resp = await response.Content.ReadAsStringAsync();
            var temp = JObject.Parse(resp);
            var obj = temp["response"].ToObject<T>();

            return obj;
        }
    }
}