﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static JournalScrapper.Entity;

namespace JournalScrapper
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Article> Articles { get; set; }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Keyword> Keywords { get; set; }
        internal DbSet<Journal> Journals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=JournalScrapper_DB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
    public class DatabaseContext
    {

    }
}