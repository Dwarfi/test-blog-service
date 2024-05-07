using Company.Service.Application.Configuration.Commands;

namespace Test.BlogService.Application.Commands.Posts;

public class GetPostByIdCommand : CommandBase<PostDTO>
{
    public int Id { get; init; }

    public GetPostByIdCommand(int postId)
    {
        Id = postId;
    }   
}