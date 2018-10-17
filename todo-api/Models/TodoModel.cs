using System;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TodoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset? Updated { get; set; }
    }
}