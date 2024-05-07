using Company.Service.Application.Configuration.Commands;
using Test.BlogService.Domain.Posts;

namespace Test.BlogService.Application.Commands.Posts;

public class GetPostByIdCommandHandler : ICommandHandler<GetPostByIdCommand, PostDTO>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDTO> Handle(GetPostByIdCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetById(request.Id);

        return new PostDTO(post.Id, post.Title, post.Content, post.DateCreated,
            post.DateUpdated);
    }
}