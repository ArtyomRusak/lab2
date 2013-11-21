using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongExercise;
using SongExercise.EventArgsExtensions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Playlist playlist = new Playlist();
            var song = new Song {Id = 1, Duration = new TimeSpan(0,0,3), Name = "Hello", Path = @""};
            var song1 = new Song { Id = 2, Duration = new TimeSpan(0, 0, 2), Name = "Hello1", Path = @"" };
            playlist.AddSong(song);
            playlist.AddSong(song1);
            Console.WriteLine(playlist.FullDuration);

            MediaPlayer player = new MediaPlayer(playlist);
            playlist.IsShuffle = true;
            
            player.StartPlayList();
            player.StartSongPlaying += player_StartSongPlaying;
            player.SongPlaying += player_SongPlaying;
            //Console.WriteLine("End operation");
            Console.ReadLine();
        }

        static void player_SongPlaying(object sender, PlayingSongEventArgs e)
        {
            Console.WriteLine("Song playing {0}", e.DueTime);
        }

        static void player_StartSongPlaying(object sender, StartPlayingSongEventArgs e)
        {
            Console.WriteLine("Song starts at {0}, Name of the song = {1}", e.StartTime, e.Song.Name);
        }
    }
}
