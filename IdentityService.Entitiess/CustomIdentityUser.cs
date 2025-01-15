using Microsoft.AspNetCore.Identity;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Entitiess
{
    public class CustomIdentityUser :IdentityUser
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual IEnumerable<Music> Musics { get; set; }
        public CustomIdentityUser()
        {
            Musics = new List<Music>();
        }

    }
}
