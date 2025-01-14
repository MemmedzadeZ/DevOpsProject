using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual IEnumerable<Music> Musics { get; set; }
        public User()
        {
            Musics = new List<Music>();
        }
    }
}
