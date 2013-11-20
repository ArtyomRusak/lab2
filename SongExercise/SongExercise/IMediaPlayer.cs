using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public interface IMediaPlayer
    {
        void Play(Song song);
        void StartPlayList();
        void SetPlaylist(Playlist playlist);
        void Pause();
    }
}
