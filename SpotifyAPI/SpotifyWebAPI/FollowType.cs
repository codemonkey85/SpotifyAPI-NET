using System;

namespace SpotifyAPI.SpotifyWebAPI
{
    [Flags]
    public enum FollowType
    {
        [StringAttribute("artist")]
        ARTIST = 1,

        [StringAttribute("user")]
        USER = 2
    }
}