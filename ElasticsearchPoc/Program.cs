using ElasticsearchPoc.Utils;
using System;
using System.Threading.Tasks;

namespace ElasticsearchPoc
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var posts = EntitiesLoader.LoadPosts();
            var documents = EntitiesLoader.LoadDocuments();

            EntitiesSeeder.CreateIndices();
            EntitiesSeeder.Seed(posts);
            EntitiesSeeder.Seed(documents);

            Console.WriteLine("Finished indexing.");
            // Indexing or fetching because the indexed documents are directly available for fetching.
            /*
            Console.WriteLine("Extracting entities from ElasticSearch...");
            var entities = await EntitiesFetcher.FetchEntities();
            Console.WriteLine($"{entities.Count} entities were fetched from Elasticsearch.");
            */
        }
    }
}
