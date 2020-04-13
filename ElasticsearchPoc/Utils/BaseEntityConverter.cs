using ElasticsearchPoc.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElasticsearchPoc.Utils
{
    public static class BaseEntityConverter
    {
        public static BaseEntity ParseBaseEntity(JToken token)
        {
            foreach (var entry in BaseEntity.IndexNames)
            {
                if (token.HasValues && token.Value<string>("_index") == entry.Value)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    string _object = token.Value<object>("_source").ToString();
                    var jsonObject = JsonConvert.DeserializeObject(_object, entry.Key);
                    return (BaseEntity) jsonObject;
                }
            }
            return default;
        }
    }
}
