# TheGuardian API wrapper for .NET

## Quick tutorial

### Search Articles
With this endpoint you can fetch articles from API
```csharp
var guardian = new GuardianApi(TOKEN);

// Simple way, searching with only query string
var result = guardian.Search(QUERY);

//Advenced searching, using model class
var query = new SearchQuery
{
    // Fields here. Leave other properties if you dont want to use it.
};

var result2 = await guardian.SearchAsync(query);
```

#### SearchQuery class
```csharp
namespace GuardianNet
{
    public class SearchQuery
    {
        public Query Query { get; set; }
        public string Section { get; set; }
        public List<string> Tags { get; set; }
        public string Lang { get; set; }
        public int StarRating { get; set; }

        public OrderBy? OrderBy { get; set; }
        public OrderDate? OrderDate { get; set; }

        public DateQuery DateQuery { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class DateQuery
    {
        public enum Date
        {
            FromDate,
            ToDate
        }

        public DateTime DateTime { get; set; }
        public Date Type { get; set; }
    }
}
```

### Tags Endpoint
This endpoint provides searching within tags, and returns specific tag data.

```csharp
var guardian = new GuardianApi(TOKEN);

var res = await guardian.GetTagsAsync("Poland");

//EXAMPLE QUERY
var qq = new TagQuery()
{
    Type = TagType.Keyword,
    Query = "F1",
    Section = "sport"
};

var res2 = await guardian.GetTagsAsync(qq);
```

### Sections Endpoint
It returns endpoints within specified query.

```csharp
var guard = GetApi();
var res = await guard.GetSectionsAsync("sport");
```

### Editions Endpoint
This endpoint return IEnumerable of 4 actually available editions.

```csharp
var guardian = GetApi();
var res = await guardian.GetEditionsAsync();
```
