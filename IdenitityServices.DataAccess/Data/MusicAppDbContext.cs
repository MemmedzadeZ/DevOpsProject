using IdentityService.Entitiess;
using Microsoft.AspNetCore.Identity;
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
    public class MusicAppDbContext:IdentityDbContext<CustomIdentityUser,CustomIdenitityRole,string>
    {

        public MusicAppDbContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<CustomIdentityUser> Users { get; set; }
        //public DbSet<CustomIdenitityRole> Roles { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityUserLogin<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        //    });
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicDbb;Integrated Security=True;", b => b.MigrationsAssembly("IdentityService.Web-API"));
        }
    }
}
