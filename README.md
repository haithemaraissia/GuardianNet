# TheGuardian API wrapper for .NET

### Quick tutorial

```csharp
var guardian = new GuardianApi(TOKEN);

// Simple way, searching with only query string
var result = guardian.Search(QUERY);

//Advenced searching, using model class
var query = new SearchQuery
{
    // Fields here. Leave other properties if you dont want to use it.
};

var result2 = guardian.Search(query);
```

### SearchQuery class
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
