using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class PlayingSongEventArgs : EventArgs
    {
        public Song Song { get; set; }
        public TimeSpan DueTime { get; set; }

        public PlayingSongEventArgs(Song song, TimeSpan timeSpan)
        {
            Song = song;
            DueTime = timeSpan;
        }
    }
}
