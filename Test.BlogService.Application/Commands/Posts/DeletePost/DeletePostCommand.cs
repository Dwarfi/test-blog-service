using Company.Service.Application.Configuration.Commands;

namespace Test.BlogService.Application.Commands.Posts;

public class DeletePostCommand: CommandBase<PostDTO>
{
    public int Id { get; init; }

    public DeletePostCommand(int postId)
    {
        Id = postId;
    }
}