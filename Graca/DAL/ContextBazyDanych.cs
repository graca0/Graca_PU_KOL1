using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContextBazyDanych : DbContext
    {
        public DbSet<Student>? Studenci { get; set; }
        public DbSet<Grupa>? Grupy { get; set; }
        public DbSet<Historia>? Historie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnection.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable(x => x.HasTrigger("UsuwanieStudenta"));
            modelBuilder.Entity<Student>().ToTable(x => x.HasTrigger("AktualizacjaStudenta"));
        }
    }
    public static class DbConnection
    {
        public static string ConnectionString => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KamilGracaKolokwium;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
