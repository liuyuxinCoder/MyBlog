using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Model.Entities;

namespace Blog.Model
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("BlogDBConnStr")
        {
        }

        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<BlogInfo> BlogInfos { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
    }
}
