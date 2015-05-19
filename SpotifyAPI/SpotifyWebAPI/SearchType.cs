using System;

namespace SpotifyAPI.SpotifyWebAPI
{
    [Flags]
    public enum SearchType
    {
        [StringAttribute("artist")]
        ARTIST = 1,

        [StringAttribute("album")]
        ALBUM = 2,

        [StringAttribute("track")]
        TRACK = 4,

        [StringAttribute("track,album,artist")]
        ALL = 8
    }
}