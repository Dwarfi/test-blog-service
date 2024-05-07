using Company.Service.Domain.Base;

namespace Test.BlogService.Domain.Posts;

public interface IPostRepository : IRepository<Post>
{
    Task<List<Post>> GetAll();
    Task<Post> GetById(int id);
    Task<Post> AddPost(Post post, bool commitChanges = true);
    Task<Post> UpdatePost(int postId, Post post, bool commitChanges = true);
    Task<Post> DeletePost(int postId, bool commitChanges = true);
    Task Commit();
}