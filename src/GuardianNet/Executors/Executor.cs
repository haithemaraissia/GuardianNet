﻿// GuardianNet/GuardianNet/Executor.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GuardianNet.Executors
{
    internal class Executor
    {
        private readonly HttpClient _client = new HttpClient();

        protected async Task<T> Execute<T>(string q)
        {
            //var qq = q.Replace("+", "%20");

            HttpResponseMessage response = await _client.GetAsync(q);

            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("TheGuardian Error");

            var temp = JObject.Parse(await response.Content.ReadAsStringAsync());
            return temp["response"].ToObject<T>();
        }
    }
}