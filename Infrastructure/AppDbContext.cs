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
        public DbSet<Ogrenci >   Ogrenciler { get; set; } 
        public DbSet<Sinav> Sinavlar {  get; set; }
        public DbSet<Ders>  Dersler {  get; set; }
        public DbSet<Veli> Veliler { get; set; }

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
        }



    }
}
