using System.Collections.Generic;

namespace SongExercise.Interfaces
{
    public interface IPlaylistCollection
    {
        void AddSong(Song song);
        bool RemoveSong(int id);
        Song FindSong(int id);
        List<Song> FindSong(string name);
    }
}
