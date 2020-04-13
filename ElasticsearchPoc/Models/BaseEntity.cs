using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ElasticsearchPoc.Models
{
    public abstract class BaseEntity
    {
        protected static int AUTO_INC_ID = 0;
        [JsonProperty("id")]
        public virtual int Id { get; private set; }
        protected BaseEntity()
        {
            Id = AUTO_INC_ID++;
        }

        public static string GetIndexName(Type t)
        {
            return IndexNames[t];
        }



        // This maps index name to corresponding entity class
        public static ReadOnlyDictionary<Type, string> IndexNames = new ReadOnlyDictionary<Type, string>(new Dictionary<Type, string>
        {
            {typeof(PostEntity), "posts" },
            {typeof(DocumentEntity), "documents" },
        });
    }
}
