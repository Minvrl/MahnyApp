using Mahny.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Album> Albums { get; set; }    
        public DbSet<Artist> Artists { get; set; }  
        public DbSet<AlbumArtist> AlbumArtist {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Slider> Slider { get; set; }   
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongArtist> SongArtist { get; set; }
        public DbSet<SongCategory> SongCategory { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumArtist>().HasKey(x => new { x.AlbumId, x.ArtistId });
            modelBuilder.Entity<SongArtist>().HasKey(x => new { x.SongId, x.ArtistId });
            modelBuilder.Entity<SongCategory>().HasKey(x => new { x.SongId, x.CategoryId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
