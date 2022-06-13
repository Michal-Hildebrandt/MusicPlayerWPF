using System;
using System.Collections.Generic;

namespace MusicPlayerWPF.DB
{
    public partial class MusicGenre
    {
        public MusicGenre()
        {
            Tracks = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
