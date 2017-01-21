namespace Test
{
    using LinqToNest;
    using Nest;
    using System;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Collections.Generic;

    public class ElasticContext : IQueryContext
    {
        private IElasticClient elasticClient;

        public ElasticContext(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public ElasticQueryable<Entry> Entries
        {
            get
            {
                return new ElasticQueryable<Entry>(this);
            }
        }

        public object Execute(Expression expression, bool isEnumerable)
        {
            var queryString = (string)ExpressionParser.Process(expression);
            var client = new System.Net.Http.HttpClient();
            var result = client.PostAsync(
                "http://localhost:9200/twitter/entry/_search", new StringContent(queryString)).Result;
            var resultContent = result.Content.ReadAsStringAsync();

            var cont = result.Content.ReadAsStringAsync().Result;

            return new List<int>();
        }
    }
}