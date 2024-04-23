using BlogPostApp.Models;
using BlogPostApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection.Metadata;

namespace BlogPostApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPost : Controller
    {
        private readonly IBlogPostService _blog;
        private readonly ApiResponse _apiRespone;
        public BlogPost(IBlogPostService blog)
        {
            _blog = blog;
            _apiRespone = new ApiResponse();
        }
        [HttpGet("{authorId}")]
        public ApiResponse GetPostsByAuthorId(int authorId)
        {
            Log.Information("GetPostsByAuthorId method called.");

            try
            {
                if (authorId <= 0)
                {
                    Log.Debug($"Invalid authorId provided: {authorId}");

                    return BadRequestResponse("Author Id must be a valid positive integer.");
                }

                var author = _blog.GetAuthorDetailsById(authorId);
                if (author == null)
                {
                    Log.Debug($"Author not found for authorId: {authorId}");

                    return NotFoundResponse("Author not found.");
                }

                var posts = _blog.GetAllPostsByAuthorId(authorId);

                if (posts.Count == 0)
                {
                    Log.Debug($"No posts found for authorId: {authorId}");

                    return NotFoundResponse("No posts found for this author.");
                }

                Log.Information($"Posts successfully retrieved for authorId: {authorId}");

                return SuccessResponse("Posts retrieved successfully.", posts);
            }
            catch (Exception ex)
            {
                Log.Error($"Error occurred while fetching posts for authorId: {authorId}. Error: {ex}");

                return ServerErrorResponse("An error occurred. Please try again later.");
            }
        }



        private ApiResponse ServerErrorResponse(string message)
        {
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                IsSuccess = false,
                Message = message
            };
        }



        [HttpPut("UpdatePostCategory")]
        public ApiResponse UpdatePostCategory(UpdatePostCategoryViewModel updatePostCategoryVM)
        {
            try
            {
                Log.Debug($"UpdatePostCategory method called. Category ID: {updatePostCategoryVM.CategoryId}, Post ID: {updatePostCategoryVM.PostId}");

                if (updatePostCategoryVM.CategoryId <= 0)
                {
                    Log.Debug($"Invalid Category ID: {updatePostCategoryVM.CategoryId}");

                    return BadRequestResponse("Invalid category ID.");
                }

                if (updatePostCategoryVM.PostId <= 0)
                {
                    Log.Debug($"Invalid Post ID: {updatePostCategoryVM.PostId}");

                    return BadRequestResponse("Invalid post ID.");
                }

                var post = _blog.GetPostDetailsById(updatePostCategoryVM.PostId);
                if (post == null)
                {
                    Log.Debug($"Post not found for ID: {updatePostCategoryVM.PostId}");

                    return NotFoundResponse("Post not found.");
                }

                var category = _blog.GetCategoryDetailsById(updatePostCategoryVM.CategoryId);
                if (category == null)
                {
                    Log.Debug($"Category not found for ID: {updatePostCategoryVM.CategoryId}");

                    return NotFoundResponse("Category not found.");
                }

                post.CategoryId = updatePostCategoryVM.CategoryId;

                _blog.UpdateExistingPost(post);

                Log.Debug($"Successfully updated post with ID: {updatePostCategoryVM.PostId}");

                return SuccessResponse("Post category updated successfully.", post);
            }
            catch (Exception ex)
            {
                Log.Error($"Error occurred while updating post. Error: {ex}");

                return ServerErrorResponse("Something went wrong. Please try again.");
            }
        }

        [HttpGet("GetPostCountByCategory")]
        public ApiResponse GetPostCountByCategory()
        {
            try
            {
                Log.Information("GetPostCountByCategory method called.");

                List<CategoryCountViewModel> categoryCounts = new List<CategoryCountViewModel>();

                var categories = _blog.GetAllCategories();

                foreach (var category in categories)
                {
                    var categoryCount = _blog.GetPostCountByCategoryId(category.Id);

                    categoryCounts.Add(new CategoryCountViewModel
                    {
                        Name = category.Name,
                        Count = categoryCount
                    });
                }

                Log.Information("Successfully fetched post counts by category.");

                return SuccessResponse("Post counts by category retrieved successfully.", categoryCounts);
            }
            catch (Exception ex)
            {
                Log.Error($"Error occurred while fetching post counts by category. Error: {ex}");

                return ServerErrorResponse("Something went wrong. Please try again.");
            }
        }
        private ApiResponse BadRequestResponse(string message)
        {
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                IsSuccess = false,
                Message = message
            };
        }

        private ApiResponse NotFoundResponse(string message)
        {
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status404NotFound,
                IsSuccess = false,
                Message = message
            };
        }

        private ApiResponse SuccessResponse(string message, object data)
        {
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status200OK,
                IsSuccess = true,
                Message = message,
                Result = data
            };
        }

    }
}
