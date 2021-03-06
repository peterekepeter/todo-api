﻿using Newtonsoft.Json;

namespace TodoApi.Models
{
    /// <summary>
    /// Represents information necessary to create or update TodoModel
    /// </summary>
    public class TodoCreateOrUpdateModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}