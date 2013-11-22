using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using SongExercise.EventArgsExtensions;
using SongExercise.Interfaces;
using Timer = System.Timers.Timer;

namespace SongExercise
{
    public class MediaPlayer : IMediaPlayer
    {
        #region [Constants]

        private const int TimeToGenerateEvent = 10000;

        #endregion


        #region [Private members]

        private Playlist _playlist;
        private readonly Task _task;
        private Timer _timer;
        private DateTime _startTime;

        #endregion


        #region [Public members]

        public event EventHandler<PlayingSongEventArgs> SongPlaying;
        public event EventHandler<StartPlayingSongEventArgs> StartSongPlaying;

        #endregion


        #region [Ctor's]

        public MediaPlayer(Playlist playlist)
        {
            _playlist = playlist;
            _task = new Task(() =>
            {
                while (_playlist.NextSong() != null)
                {
                    Play(_playlist.CurrentSong);
                }
            });
        }

        #endregion


        #region Implementation of IMediaPlayer

        public void Play(Song song)
        {
            _startTime = DateTime.Now;
            var eventArg = new StartPlayingSongEventArgs(_playlist.CurrentSong, _startTime);
            var temp = StartSongPlaying;
            if (temp != null)
            {
                temp(this, eventArg);
            }

            _timer = new Timer();
            _timer.Elapsed += HandlingEvent;
            _timer.Interval = TimeToGenerateEvent;
            _timer.Enabled = true;

            Thread.Sleep((int)song.Duration.TotalMilliseconds);
            _timer.Dispose();
        }

        void HandlingEvent(object sender, ElapsedEventArgs e)
        {
            var eventArg = new PlayingSongEventArgs(_playlist.CurrentSong, DateTime.Now - _startTime);
            var temp = SongPlaying;
            if (temp != null)
            {
                temp(this, eventArg);
            }
        }

        public void StartPlayList()
        {
            _task.Start();
        }

        public void SetPlaylist(Playlist playlist)
        {
            _playlist = playlist;
        }

        public void Pause()
        {
            // Pause playing.
        }

        public void Continue()
        {
            // Continue playing.
        }

        #endregion
    }
}
