using System;
using System.Collections.Generic;

namespace Music_API_Project.Models
{
    public partial class Favorites
    {
        public string UserId { get; set; }
        public int FavoriteId { get; set; }
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public string ArtistName { get; set; }
        public string AlbumCover { get; set; }
        public string PreviewSong { get; set; }
    }
}
