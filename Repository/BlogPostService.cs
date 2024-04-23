using BlogPostApp.Data;
using BlogPostApp.Models;
using BlogPostApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlogPostApp.Repository
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogPostAppDbContext _context;
        public BlogPostService(BlogPostAppDbContext context)
        {
            _context = context;
        }
        public List<Post> GetAllPostsByAuthorId(int authorId)
        {
            var data = _context.Posts.Where(x => x.AuthorId == authorId).ToList();
            return data;
        }

        public int GetPostCountByCategoryId(int categoryId)
        {
            var data = _context.Posts.Where(x => x.CategoryId == categoryId).Count();
            return data;
        }

        public Post GetPostDetailsById(int postId)
        {
            var data = _context.Posts.Where(x => x.Id == postId).FirstOrDefault();
            return data;
        }

        public Category GetCategoryDetailsById(int categoryId)
        {
            var data = _context.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
            return data;
        }
        public Author GetAuthorDetailsById(int authorId)
        {
            var data = _context.Authors.Where(x => x.Id == authorId).FirstOrDefault();
            return data;
        }

        public void UpdateExistingPost(Post updatedPost)
        {
            _context.Posts.Update(updatedPost);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            var data = _context.Categories.ToList();
            return data;
        }
    }
   
}
    