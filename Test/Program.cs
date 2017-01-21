using LinqToNest;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Test
{
    class Program
    {
        static void Main()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node).DefaultIndex("twitter");
            var client = new ElasticClient(settings);

            var searchDescriptor = new SearchDescriptor<Entry>();
            searchDescriptor
                .Query(x => x.Term(t => t.Field(f => f.StringProp).Value("some string 1")));
            // Exact property match
            var response1 = client
                    .SearchAsync<Entry>(s => searchDescriptor).Result;

            var context = new ElasticContext(client);
            var entries = context.Entries
                .Where(x => x.Id == "someId")
                .Select(x =>  x.IntProp);

            var collection = entries.ToList();
        }
    }
}
