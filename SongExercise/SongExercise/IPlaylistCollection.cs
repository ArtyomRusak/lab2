using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public interface IPlaylistCollection
    {
        bool AddSong(Song song);
        bool RemoveSong(int id);
        Song FindSong(int id);
        List<Song> FindSong(string name);
    }
}
