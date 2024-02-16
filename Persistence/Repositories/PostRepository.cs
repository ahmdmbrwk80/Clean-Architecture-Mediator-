using Application.Contracts;
using Domain_Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext DbContext) : base(DbContext)
        {

        }
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> allPosts = new List<Post>();
            allPosts = includeCategory ? await _dbContext.Posts.Include(x => x.category)
                      .ToListAsync() : await _dbContext.Posts.ToListAsync();
            return allPosts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post? Post = new Post();
            Post = includeCategory ? await _dbContext.Posts.Include(x => x.category)
                  .FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return Post;
        }
    }

}
