using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class Playlist : IPlaylistCollection
    {
        #region [Constants]

        private const int DefaultIndex = 0;

        #endregion


        #region [Private members]

        private readonly List<Song> _songs;
        private int _index = 0;
        private readonly Lazy<Random> _random = new Lazy<Random>(() => new Random());

        #endregion


        #region [Properties]

        public int Id { get; private set; }
        public string Name { get; set; }
        public bool IsShuffle { get; set; }
        public Song CurrentSong { get; private set; }

        public TimeSpan FullDuration
        {
            get
            {
                var result = new TimeSpan();
                return _songs.Aggregate(result, (current, song) => current + song.Duration);
            }
        }

        #endregion


        #region [Ctor's]

        public Playlist()
        {
            Id = _random.Value.Next();
            _songs = new List<Song>();
            IsShuffle = false;
        }

        public Playlist(int id, string name)
        {
            Id = id;
            Name = name;
            _songs = new List<Song>();
            IsShuffle = false;
        }

        public Playlist(int id)
        {
            Id = id;
            _songs = new List<Song>();
            IsShuffle = false;
        }

        public Playlist(List<Song> songs)
        {
            _songs = songs;
        }

        #endregion

        #region Implementation of IPlaylistCollection

        public bool AddSong(Song song)
        {
            if (CheckSong(song))
            {
                _songs.Add(song);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveSong(int id)
        {
            return _songs.Where(song => song.Id == id).Select(song => _songs.Remove(song)).FirstOrDefault();
        }

        public Song FindSong(int id)
        {
            return _songs.FirstOrDefault(e => e.Id == id);
        }

        public List<Song> FindSong(string name)
        {
            return _songs.Where(e => e.Name.Contains(name)).ToList();
        }

        #endregion

        private bool CheckSong(Song song)
        {
            return _songs.All(song1 => song1.Id != song.Id);
        }

        public Song NextSong()
        {
            if (_index >= _songs.Count)
            {
                return null;
                //_index = DefaultIndex;
            }

            if (IsShuffle)
            {
                _index = _random.Value.Next(DefaultIndex, _songs.Count);
                CurrentSong = _songs[_index];
                return CurrentSong;
            }
            else
            {
                CurrentSong = _songs[_index++];
                return CurrentSong;
            }
        }
    }
}
