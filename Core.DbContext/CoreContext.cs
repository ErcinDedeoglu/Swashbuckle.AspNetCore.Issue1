using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.DbContext
{
    public class CoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        { }

        public DbSet<Blog0> Blogs0 { get; set; }
        public DbSet<Post0> Posts0 { get; set; }
    }

    public class Blog0
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post0> Posts { get; set; }
    }

    public class Post0
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog0 Blog { get; set; }
    }
}