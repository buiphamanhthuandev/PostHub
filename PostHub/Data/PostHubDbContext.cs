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
        
        DbSet<CategoryType> CategoryTypes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Subscribe> Subscribes { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Comment> Comments { get; set; }


    }
}

