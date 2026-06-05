using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Personel >   Personels { get; set; }
        public DbSet<Ogrenci >   Ogrencis { get; set; } 
        public DbSet<Sinav> Sinavs {  get; set; }
        public DbSet<Ders>  Derss {  get; set; }
        public DbSet<Veli> Velis { get; set; }
        public DbSet<Program> Programs {  get; set; }
        public DbSet<OgrenciSinav> OgrenciSinavs {  get; set; }
       
        public DbSet<Sinif> Sinifs {  get; set; }
        public DbSet<User> Users {  get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(SqlCon.con);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foreignKeys = modelBuilder.Model.GetEntityTypes()
        .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in foreignKeys)
            {
                // Hepsinin silme davranışını Restrict olarak değiştirir
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<Personel>().HasKey(a => a.PerId);
            modelBuilder.Entity<Personel>()
                .HasMany(a => a.Programs)
                .WithOne(a => a.Personel)
                .HasForeignKey(a => a.Per_id);

            modelBuilder.Entity<Personel>()
                .HasMany(a => a.Sinavs)
                .WithOne(a => a.personel)
                .HasForeignKey(a => a.Hoca_Id);

            modelBuilder.Entity<Personel>()
                .HasOne(c => c.Ders)
                .WithMany(c => c.Personels)
                .HasForeignKey(a => a.DersId);

            modelBuilder.Entity<Ders>()
                .HasMany(a=>a.Sinavlar)
                .WithOne(a=>a.ders)
                .HasForeignKey(a=>a.Ders_Id);


            modelBuilder.Entity<Ders>()
               .HasMany(a => a.Programs)
               .WithOne(a => a.ders)
               .HasForeignKey(a => a.ders_Id);

            modelBuilder.Entity<OgrenciSinav>()
               .HasOne(os => os.Ogrenci)
               .WithMany(o => o.OgrenciSinavs)
               .HasForeignKey(os => os.Ogrenci_id);

          
            modelBuilder.Entity<OgrenciSinav>()
                .HasOne(os => os.Sinav)
                .WithMany(s => s.OgrenciSinavs)
                .HasForeignKey(os => os.Sinav_id);

            modelBuilder.Entity<Ogrenci>()
                .HasOne(a => a.sinif)
                .WithMany(a => a.Ogrenciler)
                .HasForeignKey(a => a.Sinif_Id);

            modelBuilder.Entity<Ogrenci> ()
                .HasOne(a=>a.veli)
                .WithMany(a=>a.Ogrenciler)
                .HasForeignKey (a => a.Veli_Id);

            modelBuilder.Entity<Sinif>()
                .HasMany(a=>a.programs)
                .WithOne(a=>a.Sinif)
                .HasForeignKey(a=>a.Sinif_id);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Ogrenci)
                .WithOne(a => a.User)
                .HasForeignKey<User>(a => a.Ogrenci_id);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Personel)
                .WithOne(a => a.User)
                .HasForeignKey<User>(a => a.personel_id);

            modelBuilder.Entity<Ogrenci>()
                .HasIndex(a => a.Ogrenci_No).IsUnique();

            modelBuilder.Entity<Personel>()
                .HasIndex(a=>a.TC).IsUnique();



        }



    }
}
