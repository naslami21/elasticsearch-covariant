using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ElasticsearchPoc.Models;
using Newtonsoft.Json.Linq;

namespace ElasticsearchPoc.Utils
{
    public static class EntitiesFetcher
    {
        public async static Task<List<BaseEntity>> FetchEntities()
        {
            var httpClient = new HttpClient();

            var content = new StringContent(JObject.FromObject(new
            {
                from = 0,
                size = 2,
                query = new
                {
                    query_string = new
                    {
                        query = "the"
                    }
                }

            }).ToString(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var uri = new Uri("http://localhost:9200/searchable/_search");

            var response = httpClient.PostAsync(uri, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JToken.Parse(json)
                    .SelectToken("hits.hits")
                    .Select(t => BaseEntityConverter.ParseBaseEntity(t))
                    .ToList();
                return result;
            }
            return default;
        }
    }
}
