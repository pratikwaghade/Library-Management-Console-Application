using Library_Management_Console_Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Console_Application.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = LibraryMNSEFDb; TrustServerCertificate = True; Integrated Security = True";

            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
