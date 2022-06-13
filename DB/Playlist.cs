using System;
using System.Collections.Generic;

namespace MusicPlayerWPF.DB
{
    public partial class Playlist
    {
        public Playlist()
        {
            Tracks = new HashSet<Track>();
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
