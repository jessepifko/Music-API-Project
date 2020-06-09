using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_API_Project.Models
{
    public class TrackList
    {
        public DatumFromTrack[] data { get; set; }
        public int total { get; set; }
        public string next { get; set; }
    }

    public class DatumFromTrack
    {
        public int id { get; set; }
        public bool readable { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string title_version { get; set; }
        public string link { get; set; }
        public int duration { get; set; }
        public int rank { get; set; }
        public bool explicit_lyrics { get; set; }
        public int explicit_content_lyrics { get; set; }
        public int explicit_content_cover { get; set; }
        public string preview { get; set; }
        public Contributor[] contributors { get; set; }
        public ArtistFromTrack artist { get; set; }
        public AlbumFromTrack album { get; set; }
        public string type { get; set; }
    }

    public class ArtistFromTrack
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class AlbumFromTrack
    {
        public int id { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Contributor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string share { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public bool radio { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
        public string role { get; set; }
    }

}
