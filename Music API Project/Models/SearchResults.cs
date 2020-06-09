﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_API_Project.Models
{
    public class SearchResults
    {
        public Datum[] data { get; set; }
        public int total { get; set; }
        public string next { get; set; }

    }

    public class Datum : IComparable<Datum>
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
        public Artist artist { get; set; }
        public Album album { get; set; }
        public string type { get; set; }
        public int CompareTo(Datum other)
        {            
            //higher ranks must go to the top of the results
            return -1*this.rank.CompareTo( other.rank );
        }
    }

    public class Artist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }
    public class Album
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

    public class ArtistDetailsVM
    {
        public Artist artist { get; set; }

        public TrackList trackList { get; set; }
    }
}