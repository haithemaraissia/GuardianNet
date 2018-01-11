using System.Collections.Generic;

namespace GuardianNet.Models.Tags
{
    public sealed class TagResponse : IResponse
    {
        public List<Tag> Results { get; set; }
        public string Status { get; set; }
        public string UserTier { get; set; }
        public int Total { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}
