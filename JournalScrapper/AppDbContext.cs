﻿using CSV2Sql.Models;
using JournalScrapper.Entity;
using Microsoft.EntityFrameworkCore;
using Profile_Shakhsi.Models.Entity;
using static JournalScrapper.Entity.ISCMySql;
using Author = JournalScrapper.Entity.Author;
using Journal = JournalScrapper.Entity.Journal;
using Keyword = JournalScrapper.Entity.Keyword;

namespace JournalScrapper
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Article> Articles { get; set; }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Keyword> Keywords { get; set; }
        internal DbSet<Journal> Journals { get; set; }
        internal DbSet<ISCJournal> ISCJournals { get; set; }
        internal DbSet<Quality> Qualities { get; set; }
        internal DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=JournalScrapper_DB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }

    public class ProfileShakhsiDbContext : DbContext
    {
        public DbSet<All_Article> All_Articles { get; set; }
        public DbSet<ResearcherFavorite> ResearcherFavorites { get; set; }
        public DbSet<ISCMySql.Keyword> Keywords { get; set; }
        public DbSet<ISCMySql.Author> Authors { get; set; }
        public DbSet<ISC_Article> ISC_Articles { get; set; }
        public DbSet<Author_Article> Author_Articles { get; set; }
        public DbSet<ISCMySql.Journal> Journals { get; set; }
        public DbSet<Author_ISC> Author_ISCs { get; set; }
        public DbSet<CitationAll_Article> CitationAll_Articles { get; set; }
        public DbSet<CitationAuthor> CitationAuthors { get; set; }
        public DbSet<InputMaster> InputMasters { get; set; }
        public DbSet<Author_Article_ISC> Author_Article_ISCs { get; set; }

        public DbSet<ProfessorProfile> ProfessorProfiles { get; set; }
        public DbSet<ProfessionalActivity> ProfessionalActivities { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ResearchArea> ResearchAreas { get; set; }
        public DbSet<WebLink> WebLinks { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<TeachingInterest> TeachingInterests { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.;Initial Catalog=Professor_DB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }

    public class ISCMySqlDbContext : DbContext
    {
        public DbSet<All_Article> scholar_all_article { get; set; }
        public DbSet<ResearcherFavorite> areas_of_interest { get; set; }
        public DbSet<ISCMySql.Keyword> keywords_articles_isc_xml { get; set; }
        public DbSet<ISCMySql.Author> scholar_profile_authors { get; set; }
        public DbSet<ISC_Article> article_isc_xml { get; set; }
        public DbSet<Author_Article> author_article_relation { get; set; }
        public DbSet<ISCMySql.Journal> iranian_journals { get; set; }
        public DbSet<Author_ISC> authors_isc_xml { get; set; }
        public DbSet<CitationAll_Article> citation_article_scholar { get; set; }

        public DbSet<CitationAuthor> all_citation_authors { get; set; }

        //public DbSet<ISCMySql.InputMaster> InputMasters { get; set; }
        public DbSet<Author_Article_ISC> author_article_isc_relation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=info_mysql;user=root;password=",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InputMaster>(entity =>
            {
                entity.Property(e => e.AuthorScholarId)
                    .HasColumnType("varchar(255) CHARACTER SET utf8");
            });
            // تنظیمات مدل‌ها (مثال)
            modelBuilder.Entity<ResearcherFavorite>().HasKey(rf => rf.Id);
            modelBuilder.Entity<All_Article>().HasKey(a => a.Id);
            modelBuilder.Entity<ISCMySql.Keyword>().HasKey(k => k.Id);
            modelBuilder.Entity<ISCMySql.Author>().HasKey(a => a.Id);
            modelBuilder.Entity<ISC_Article>().HasKey(i => i.Id);
            modelBuilder.Entity<Author_Article>().HasKey(aa => aa.Id);
            modelBuilder.Entity<ISCMySql.Journal>().HasKey(j => j.Id);
            modelBuilder.Entity<Author_ISC>().HasKey(ai => ai.Id);
            modelBuilder.Entity<CitationAll_Article>().HasKey(ca => ca.Id);
            modelBuilder.Entity<CitationAuthor>().HasKey(c => c.Id);
            modelBuilder.Entity<InputMaster>().HasKey(im => im.AuthorScholarId);
            modelBuilder.Entity<Author_Article_ISC>().HasKey(aai => aai.Id);
        }
    }
}