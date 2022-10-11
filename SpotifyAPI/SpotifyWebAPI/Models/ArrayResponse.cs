using System.Collections.Generic;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public class ListResponse<T> : BasicModel
    {
        public List<T> List { get; set; }
    }
}