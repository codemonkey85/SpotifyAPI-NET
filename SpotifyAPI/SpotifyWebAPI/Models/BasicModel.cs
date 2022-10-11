using Newtonsoft.Json;
using System;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error ErrorResponse { get; set; }

        public Boolean HasError()
        {
            return ErrorResponse != null;
        }
    }
}