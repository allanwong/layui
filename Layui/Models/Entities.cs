namespace Layui.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public class Entities : DbContext
    {
        public Entities()
            : base("name=DefaultConnection")
        {
        }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Map one-to-many relationship
            modelBuilder.Entity<Post>()
                .HasMany(t => t.Upload)
                .WithRequired(t => t.Post);
            base.OnModelCreating(modelBuilder);
        }
    }
}