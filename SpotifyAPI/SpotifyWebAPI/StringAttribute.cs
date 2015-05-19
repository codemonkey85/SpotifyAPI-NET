using System;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class StringAttribute : Attribute
    {
        public String Text { get; set; }

        public StringAttribute(String text)
        {
            this.Text = text;
        }
    }
}