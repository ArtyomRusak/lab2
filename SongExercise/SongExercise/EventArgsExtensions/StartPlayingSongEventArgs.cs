using System;

namespace SongExercise.EventArgsExtensions
{
    public class StartPlayingSongEventArgs : EventArgs
    {
        public Song Song { get; set; }
        public DateTime StartTime { get; set; }

        public StartPlayingSongEventArgs(Song song, DateTime startTime)
        {
            Song = song;
            StartTime = startTime;
        }
    }
}
