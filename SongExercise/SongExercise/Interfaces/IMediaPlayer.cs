namespace SongExercise.Interfaces
{
    public interface IMediaPlayer
    {
        void Play(Song song);
        void StartPlayList();
        void SetPlaylist(Playlist playlist);
        void Pause();
        void Continue();
    }
}
