using System.ComponentModel.DataAnnotations;

namespace BlogPostApp.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
