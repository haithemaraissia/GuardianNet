// GuardianNet/GuardianNet/Edition.cs
// 
// Created at: 01/01/2018
// Author: Szymon 'l7ssha' Uglis

using Newtonsoft.Json;

namespace GuardianNet.Models.Editions
{
    public class Edition
    {
        public string Id { get; set; }
        public string Path { get; set; }
        [JsonProperty(PropertyName = "Edition")]
        public string Name { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
    }
}