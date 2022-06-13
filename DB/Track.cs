using System;
using System.Collections.Generic;

namespace MusicPlayerWPF.DB
{
    public partial class Track
    {
        public int TrackId { get; set; }
        public string? Name { get; set; }
        public int? GenreId { get; set; }
        public int? PlaylistId { get; set; }

        public virtual MusicGenre? Genre { get; set; }
        public virtual Playlist? Playlist { get; set; }
    }
}
