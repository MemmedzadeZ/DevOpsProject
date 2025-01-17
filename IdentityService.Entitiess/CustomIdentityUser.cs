using Microsoft.AspNetCore.Identity;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Entitiess
{
    public class CustomIdentityUser :IdentityUser<string>
    {
        public override string Id { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public virtual IEnumerable<Music> Musics { get; set; }
      
        public CustomIdentityUser() : base()
        {
            this.Id = Guid.NewGuid().ToString(); // id avtomatik təyin edilir
            Musics = new List<Music>();
        }

    }
}
