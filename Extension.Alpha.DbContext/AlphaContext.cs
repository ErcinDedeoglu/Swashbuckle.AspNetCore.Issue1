using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Extension.Alpha.DbContext
{
    public class AlphaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AlphaContext(DbContextOptions<AlphaContext> options)
            : base(options)
        { }

        public DbSet<Blog1> Blogs1 { get; set; }
        public DbSet<Post1> Posts1 { get; set; }
    }

    public class Blog1
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post1> Posts { get; set; }
    }

    public class Post1
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog1 Blog { get; set; }
    }
}