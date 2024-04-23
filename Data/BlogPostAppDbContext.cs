using BlogPostApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostApp.Data
{
    public class BlogPostAppDbContext:DbContext
    {
        public BlogPostAppDbContext(DbContextOptions<BlogPostAppDbContext> Options) : base(Options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
           new List<Author>()
                {
                    new Author() { Id = 1, Name = "Test" },
                    new Author() { Id = 2, Name = "Jeffery Achher" },
                    new Author() { Id = 3, Name = "Chetan Bhagat" },
                    new Author() { Id = 4, Name = "Jane Doe" },
                    new Author() { Id = 5, Name = "John Smith" },
                    new Author() { Id = 6, Name = "Emily Johnson" },
                    new Author() { Id = 7, Name = "Michael Brown" },
                    new Author() { Id = 8, Name = "Sophia Williams" },
                    new Author() { Id = 9, Name = "William Jones" },
                    new Author() { Id = 10, Name = "Olivia Garcia" }
                }
            );


            modelBuilder.Entity<Category>().HasData(
              new List<Category>()
                {
                    new Category() { Id = 1, Name = "Test Category" },
                    new Category() { Id = 2, Name = "Drama" },
                    new Category() { Id = 3, Name = "Action" },
                    new Category() { Id = 4, Name = "Romance" },
                    new Category() { Id = 5, Name = "Science Fiction" },
                    new Category() { Id = 6, Name = "Mystery" },
                    new Category() { Id = 7, Name = "Thriller" },
                    new Category() { Id = 8, Name = "Fantasy" },
                    new Category() { Id = 9, Name = "Horror" },
                    new Category() { Id = 10, Name = "Comedy" }
                });

            modelBuilder.Entity<Post>().HasData(
               new List<Post>()
        {
            new Post()
            {
                Id = 1,
                Title = "Introduction",
                Description = "This is an introduction.",
                CategoryId = 1,
                AuthorId = 1,
                CreatedOn = DateTime.Now
            },
            new Post()
            {
                Id = 2,
                Title = "Experiment",
                Description = "This is an experiment.",
                CategoryId = 1,
                AuthorId = 2,
                CreatedOn = DateTime.Now
            },
            new Post()
            {
                Id = 3,
                Title = "Exploration",
                Description = "This is an exploration.",
                CategoryId = 2,
                AuthorId = 3,
                CreatedOn = DateTime.Now
            },
            new Post()
            {
                Id = 4,
                Title = "Illustration",
                Description = "This is an illustration.",
                CategoryId = 3,
                AuthorId = 4,
                CreatedOn = DateTime.Now
            },
            new Post()
            {
                Id = 5,
                Title = "Demonstration",
                Description = "This is a demonstration.",
                CategoryId = 4,
                AuthorId = 5,
                CreatedOn = DateTime.Now
            }
        });


        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
