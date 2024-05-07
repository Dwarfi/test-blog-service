using System.ComponentModel.DataAnnotations;

namespace Test.BlogService.Application.Commands.Posts
{
    public record AddPostRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; init; } = string.Empty;

        [Required]
        [MaxLength(2500)]
        public string Content { get; init; } = string.Empty;
    }
}
