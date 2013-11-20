using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Path { get; set; }

        public Song()
        {
            
        }

        public Song(int id)
        {
            Id = id;
        }
    }
}
