using Company.Service.Domain.Base;
using Company.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Test.BlogService.Domain.Posts;

namespace Test.BlogService.Infrastructure.Domain.Posts
{
    public class PostRepository<T> : IPostRepository where T : IAggregateRoot
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit() => await _context.SaveChangesAsync();

        public async Task<List<Post>> GetAll() =>
            await _context.Posts.AsNoTracking().Include(post => post.Comments).ToListAsync();

        public async Task<Post> GetById(int id) => await _context.Posts.AsNoTracking().Include(s => s.Comments)
            .FirstOrDefaultAsync(post => post.Id.Equals(id));

        public async Task<Post> AddPost(Post post,
            bool commitChanges = true)
        {
            var resultEntity = await _context.Posts.AddAsync(post);

            if (commitChanges) 
                await Commit();
            
            return resultEntity.Entity;
        }

        public async Task<Post> UpdatePost(int postId, Post post, bool commitChanges = true)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> DeletePost(int postId, bool commitChanges = true)
        {
            var resultEntity = await _context.Posts.FindAsync(postId) 
                               ?? throw new KeyNotFoundException();
            resultEntity.Delete();

            if (commitChanges) await Commit();

            return resultEntity;
        }
    }
}
