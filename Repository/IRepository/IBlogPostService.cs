using BlogPostApp.Models;

namespace BlogPostApp.Repository.IRepository
{
    public interface IBlogPostService
    {
        List<Post> GetAllPostsByAuthorId(int authorId);
        int GetPostCountByCategoryId(int categoryId);
        Post GetPostDetailsById(int postId);
        Author GetAuthorDetailsById(int authorId);
        Category GetCategoryDetailsById(int categoryId);
        void UpdateExistingPost(Post updatedPost);

        List<Category> GetAllCategories();
        void SaveChanges();
    }
}
