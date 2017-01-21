using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var contentObj = new
            {
                query = new
                {
                    boolClause = new
                    {
                        filter = new
                        {
                            term = new
                            {
                                IntProp = 2
                            }
                        }
                    }
                }
            };

            var content = JsonConvert.SerializeObject(contentObj).Replace("boolClause", "bool");
            Console.WriteLine(content);
            var client = new System.Net.Http.HttpClient();
            var result = client.PostAsync(
                "http://localhost:9200/twitter/entry/_search", new StringContent(content)).Result;

            var cont = result.Content.ReadAsStringAsync().Result;
        }
    }
}
