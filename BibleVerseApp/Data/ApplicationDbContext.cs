using Microsoft.EntityFrameworkCore;
using BibleVerseApp.Models;

namespace BibleVerseApp.Data {
    /**
     * this class is for interacting with the database using the entity framework
     */
    public class ApplicationDbContext : DbContext {

        /// <summary>
        /// constructor that takes in a DbContextOptions from entity framework
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        //the collection of bibleverses in the database
        public DbSet<BibleVerseModel> BibleVerses { get; set; }

        /// <summary>
        /// method that will tie the model with the actual table in the database
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BibleVerseModel>(entity => {
                //maps the entity to the table in the db
                entity.ToTable("t_kjv");

                //the primary key on the table
                entity.HasKey(e => e.Id);

                //the table columns for each property of the entity
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Book).HasColumnName("b");
                entity.Property(e => e.Chapter).HasColumnName("c");
                entity.Property(e => e.Verse).HasColumnName("v");
                entity.Property(e => e.Text).HasColumnName("t");
            });
        }
    }
}