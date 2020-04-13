using Nest;
using System;
using System.Collections.Generic;
using ElasticsearchPoc.Models;

namespace ElasticsearchPoc.Utils
{
    public static class EntitiesSeeder
    {
        private static readonly string ELASTIC_SERVER = "http://localhost:9200";
        public static void CreateIndices()
        {

            var node = new Uri(ELASTIC_SERVER);
            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            client.Indices.Create("posts", c => c.Map<PostEntity>(m => m.AutoMap()));
            client.Indices.BulkAlias(ba => ba.Add(a => a.Index("posts").Alias("searchable")));

            client.Indices.Create("documents", c => c.Map<DocumentEntity>(m => m.AutoMap()));
            client.Indices.BulkAlias(ba => ba.Add(a => a.Index("documents").Alias("searchable")));
        }
        public static void Seed<T>(List<T> entities) where T: BaseEntity
        {
            var indexName = BaseEntity.GetIndexName(typeof(T));
            var node = new Uri(ELASTIC_SERVER);
            var settings = new ConnectionSettings(node)
                .DefaultMappingFor<T>(m => m
                .IndexName(indexName));

            var client = new ElasticClient(settings);

            var response = client.IndexMany(entities);

            if (response.Errors)
            {
                foreach (var itemWithError in response.ItemsWithErrors)
                {
                    Console.WriteLine("Failed to index document {0}: {1}", itemWithError.Id, itemWithError.Error);
                }
            }
        }
    }
}
