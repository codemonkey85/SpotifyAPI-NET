namespace SpotifyAPI.Web
{
  public class AlbumTracksRequest : RequestParams
  {
    /// <summary>
    /// An ISO 3166-1 alpha-2 country code or the string from_token.
    /// Provide this parameter if you want to apply Track Relinking.
    /// </summary>
    /// <value></value>
    [QueryParam("market")]
    public string? Market { get; set; }

    /// <summary>
    /// The maximum number of tracks to return. Default: 20. Minimum: 1. Maximum: 50.
    /// </summary>
    /// <value></value>
    [QueryParam("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The index of the first track to return. Default: 0 (the first object).
    /// Use with limit to get the next set of tracks.
    /// </summary>
    /// <value></value>
    [QueryParam("offset")]
    public int? Offset { get; set; }
  }
}

