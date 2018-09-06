using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Extension.Beta.DbContext
{
    public class BetaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BetaContext(DbContextOptions<BetaContext> options)
            : base(options)
        { }

        public DbSet<Blog2> Blogs2 { get; set; }
        public DbSet<Post2> Posts2 { get; set; }
    }

    public class Blog2
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post2> Posts { get; set; }
    }

    public class Post2
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog2 Blog { get; set; }
    }
}