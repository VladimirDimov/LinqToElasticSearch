using Nest;

namespace Test
{
    [ElasticsearchType(Name = "entry")]
    public class Entry
    {
        [Keyword(Ignore = true)]
        public string Id { get; set; }

        [Keyword(Name = "IntProp")]
        public int IntProp { get; set; }

        [Keyword(Name = "stringProp")]
        public string StringProp { get; set; }
    }
}
