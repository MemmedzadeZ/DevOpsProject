using IdentityService.Entitiess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.DataAccess.Data
{
    public class MusicAppDbContext:IdentityDbContext<CustomIdentityUser, CustomIdenitityRole ,string>
    {

        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options) : base(options)
        {

        }
       
       
    }
}
