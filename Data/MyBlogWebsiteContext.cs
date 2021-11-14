using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Models;

namespace MyBlogWebsite.Data
{
    public class MyBlogWebsiteContext : DbContext
    {
        public MyBlogWebsiteContext (DbContextOptions<MyBlogWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<MyBlogWebsite.Models.Author> Author { get; set; }

        public DbSet<MyBlogWebsite.Models.Post> Post { get; set; }

        public DbSet<MyBlogWebsite.Models.Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(p => new { p.AuthorId, p.TagId});
            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostAuthor)
                .WithMany(pa => pa.Posts)
                .HasForeignKey(p => p.AuthorId);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.PostTag)
                .WithMany(pt => pt.TagPosts)
                .HasForeignKey(p => p.TagId);
        }
    }
}
