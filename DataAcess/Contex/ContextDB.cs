using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Models;

namespace DataAccess.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {
        }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Integrated Security=True;");
        }
        public DbSet<Mebli> Meblis { get; set; }
        public DbSet<MebliOpis> Opsis { get; set; }
        public DbSet<Pocupci> Pocupcis { get; set; }
        public DbSet<Zamovlennya> Zamovlennyas { get; set; }
        public DbSet<Prodavci> Prodavcis { get; set; }
        public DbSet<Robitniki> Robitnikis { get; set; }

        /*public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer(@"Data Source=ASUS-DESKTOP\SQLEXPRESS;Database=Mebli;Trusted_Connection=True;");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mebli>().HasOne(o => o.Prodavci).WithMany(o => o.Meblis).HasForeignKey(o => o.ProdavecID);
            modelBuilder.Entity<Mebli>().HasOne(o => o.Opis).WithOne(o => o.Mebli).HasForeignKey<MebliOpis>(o => o.MebliID);
            modelBuilder.Entity<Zamovlennya>().HasOne(o => o.Mebli).WithMany(o => o.Zamovlennyas).HasForeignKey(o => o.MebliID);
            modelBuilder.Entity<Zamovlennya>().HasOne(o => o.Pocupci).WithMany(o => o.Zamovlennyas).HasForeignKey(o => o.PocupciID);
            modelBuilder.Entity<Zamovlennya>().HasMany(o => o.Robitnikis).WithMany(o => o.Zamovlennyas).UsingEntity(o => o.ToTable("ZamovlenyaRobitniki"));
        }
    }
}
