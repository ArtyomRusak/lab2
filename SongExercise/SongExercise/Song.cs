using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongExercise
{
    public class Song
    {
        #region [Properties]

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Path { get; set; }

        #endregion


        #region [Ctor's]

        public Song()
        {

        }

        public Song(int id)
        {
            Id = id;
        }

        #endregion

    }
}
