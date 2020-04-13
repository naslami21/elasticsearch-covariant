using System;
using Nest;
using Newtonsoft.Json;

namespace ElasticsearchPoc.Models
{
    public class PostEntity: BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("publicationDate")]
        public DateTime PublicationDate { get; }
        [JsonProperty("writer")]
        public string Writer { get; }

        public PostEntity(string title, string postContent, string writer)
        {
            Title = title;
            Content = postContent;
            Writer = writer;
            PublicationDate = DateTime.Now;
        }

    }
}
