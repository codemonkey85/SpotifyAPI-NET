using Newtonsoft.Json;
using System;

namespace SpotifyAPI.SpotifyWebAPI.Models
{
    public class Snapshot : BasicModel
    {
        [JsonProperty("snapshot_id")]
        public String SnapshotId { get; set; }
    }
}