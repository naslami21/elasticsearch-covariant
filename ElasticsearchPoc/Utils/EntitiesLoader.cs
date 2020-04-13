using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ElasticsearchPoc.Models;

namespace ElasticsearchPoc.Utils
{
    public static class EntitiesLoader
    {
        public static List<PostEntity> LoadPosts()
        {
            Console.WriteLine("Started loading posts...");
            var posts = JsonConvert.DeserializeObject<List<PostEntity>>(File.ReadAllText(@"Imports\posts.json"));
            Console.WriteLine("Finished loading posts...");
            return posts;
        }
        public static List<DocumentEntity> LoadDocuments()
        {
            Console.WriteLine("Started loading documents...");
            var documents = JsonConvert.DeserializeObject<List<DocumentEntity>>(File.ReadAllText(@"Imports\documents.json"));
            Console.WriteLine("Finished loading posts...");
            return documents;
        }
    }
}
