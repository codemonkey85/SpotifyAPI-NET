﻿using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public class CategoryList : BasicModel
    {
        [JsonProperty("categories")]
        public Paging<Category> Categories { get; set; }
    }
}