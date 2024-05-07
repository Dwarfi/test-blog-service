using Company.Service.Application.Configuration.Commands;
using Test.BlogService.Domain.Posts;

namespace Test.BlogService.Application.Commands.Posts;

public class GetPostsCommandHandler : ICommandHandler<GetPostsCommand, IEnumerable<PostDTO>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<PostDTO>> Handle(GetPostsCommand request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAll();
        var dtos = new List<PostDTO>();

        posts.AsParallel().ForAll(post =>
            dtos.Add(new PostDTO(post.Id, post.Title, post.Content, post.DateCreated, post.DateUpdated))
        );

        return dtos;
    }
}