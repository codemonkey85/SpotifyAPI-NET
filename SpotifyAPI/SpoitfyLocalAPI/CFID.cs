using System;

namespace SpotifyAPI.SpotifyLocalAPI
{
    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    internal class CFID
    {
        public Error error { get; set; }

        public String token { get; set; }

        public String version { get; set; }

        public String client_version { get; set; }

        public Boolean running { get; set; }
    }

    /// <summary>
    /// JSON Response, used internaly
    /// </summary>
    internal class Error
    {
        public String type { get; set; }

        public String message { get; set; }
    }
}