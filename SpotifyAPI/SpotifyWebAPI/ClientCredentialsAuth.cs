using Newtonsoft.Json;
using SpotifyAPI.SpotifyWebAPI.Models;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class ClientCredentialsAuth
    {
        public Scope Scope { get; set; }

        public String ClientId { get; set; }

        public String ClientSecret { get; set; }

        public Token DoAuth()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                wc.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret)));

                NameValueCollection col = new NameValueCollection();
                col.Add("grant_type", "client_credentials");
                col.Add("scope", Scope.GetStringAttribute(" "));

                byte[] data = null;
                try
                {
                    data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                }
                catch (WebException e)
                {
                    String test = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                }
                return JsonConvert.DeserializeObject<Token>(Encoding.UTF8.GetString(data));
            }
        }
    }
}