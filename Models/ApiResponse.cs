namespace BlogPostApp.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
