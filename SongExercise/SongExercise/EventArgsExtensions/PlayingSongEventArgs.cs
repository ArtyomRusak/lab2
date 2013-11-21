using System;

namespace SongExercise.EventArgsExtensions
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
