using System;
using Nest;
using Newtonsoft.Json;

namespace ElasticsearchPoc.Models
{
    [ElasticsearchType]
    public class DocumentEntity: BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; }

        public DocumentEntity(string name, string path, string type)
        {
            Name = name;
            Path = path;
            Type = type;
            CreationDate = DateTime.Now;
        }
    }
}
