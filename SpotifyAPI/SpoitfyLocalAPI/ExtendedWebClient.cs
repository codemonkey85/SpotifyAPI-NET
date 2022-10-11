using System;
using System.Net;

namespace SpotifyAPI.SpotifyLocalAPI
{
    internal class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            webRequest.Timeout = Timeout;
            return webRequest;
        }
    }
}