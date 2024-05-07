namespace Test.BlogService.Application.Commands.Posts
{
    public record PostDTO(int Id, string Title, string Content, DateTime DateCreated,
        DateTime DateUpdated);
}
