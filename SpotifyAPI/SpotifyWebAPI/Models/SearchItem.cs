using Newtonsoft.Json;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public class SearchItem : BasicModel
    {
        [JsonProperty("artists")]
        public Paging<SimpleArtist> Artists { get; set; }

        [JsonProperty("albums")]
        public Paging<SimpleAlbum> Albums { get; set; }

        [JsonProperty("tracks")]
        public Paging<FullTrack> Tracks { get; set; }
    }
}