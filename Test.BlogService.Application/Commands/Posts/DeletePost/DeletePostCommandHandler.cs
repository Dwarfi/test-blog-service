using Company.Service.Application.Configuration.Commands;
using Test.BlogService.Domain.Posts;

namespace Test.BlogService.Application.Commands.Posts;

public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand, PostDTO>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDTO> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var deletedPost = await _postRepository.DeletePost(request.Id);

        return new PostDTO(deletedPost.Id, deletedPost.Title, deletedPost.Content, deletedPost.DateCreated,
            deletedPost.DateUpdated);
    }
}