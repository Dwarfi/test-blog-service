using Company.Service.Application.Configuration.Commands;

namespace Test.BlogService.Application.Commands.Posts;

public class GetPostsCommand : CommandBase<PostDTO>, ICommand<IEnumerable<PostDTO>>
{ }