using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class StartPlayingSong : EventArgs
    {
        public Song Song { get; set; }
        public DateTime StartTime { get; set; }

        public StartPlayingSong(Song song, DateTime startTime)
        {
            Song = song;
            StartTime = startTime;
        }
    }
}
