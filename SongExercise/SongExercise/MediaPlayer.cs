using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SongExercise
{
    public class MediaPlayer : IMediaPlayer
    {
        #region [Private members]

        private Playlist _playlist;
        private Task _task;
        private DateTime _startTime;

        #endregion

        #region [Public members]

        public event EventHandler<PlayingSongEventArgs> SongPlaying;
        public event EventHandler<StartPlayingSong> StartSongPlaying;

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
            StartPlayingSong eventArg = new StartPlayingSong(_playlist.CurrentSong, _startTime);
            var temp = StartSongPlaying;
            if (temp!=null)
            {
                temp(this, eventArg);
            }

            Timer timer = new Timer();
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 10000;
            timer.Enabled = true;

            Thread.Sleep((int)song.Duration.TotalMilliseconds);
            timer.Dispose();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PlayingSongEventArgs eventArg = new PlayingSongEventArgs(_playlist.CurrentSong, DateTime.Now - _startTime);
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
            _task.Wait();
        }

        #endregion
    }
}
