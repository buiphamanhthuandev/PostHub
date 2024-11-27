using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostHub.Models;

namespace PostHub.Data
{
    public class PostHubDbContext : IdentityDbContext<User>
    {
        public PostHubDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

