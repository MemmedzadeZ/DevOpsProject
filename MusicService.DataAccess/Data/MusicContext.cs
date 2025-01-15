using Microsoft.EntityFrameworkCore;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.DataAccess.Data
{
    public class MusicContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}
