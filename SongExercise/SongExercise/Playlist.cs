using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan FullDuration
        {
            get { throw new NotImplementedException(); }
        }

        public Playlist()
        {
            Id = Guid.NewGuid();
        }
    }
}
