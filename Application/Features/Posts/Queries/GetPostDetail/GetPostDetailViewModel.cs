using Application.Features.Posts.Queries.GetPostList;

namespace Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public CategoryDto Category { get; set; } 
    }
}
