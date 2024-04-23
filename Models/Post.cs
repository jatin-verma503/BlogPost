using System.ComponentModel.DataAnnotations;

namespace BlogPostApp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
