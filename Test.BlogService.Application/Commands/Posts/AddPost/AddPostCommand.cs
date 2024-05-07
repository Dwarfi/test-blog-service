using Company.Service.Application.Configuration.Commands;

namespace Test.BlogService.Application.Commands.Posts
{
    public class AddPostCommand : CommandBase<PostDTO>
    {
        public string Title { get; init; }
        public string Content { get; init; }  
        public AddPostCommand(string title,
            string content)
        {
            Title = title;
            Content = content;  
        }
    }
}
