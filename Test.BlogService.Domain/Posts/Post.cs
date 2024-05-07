using Company.Service.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Test.BlogService.Domain.Posts
{
    public sealed partial class Post : Entity, IAggregateRoot
    {
        [MaxLength(100)]
        [Required]
        public string Title { get; private set; } = string.Empty;

        [MaxLength(2500)]
        [Required]
        public string Content { get; private set; } = string.Empty;

        public ICollection<Comment> Comments { get; private set; }

        public Post(string title, string content)
        {
            Title = title;
            Content = content;
            Comments = new List<Comment>();
            Validate();
        }
    }
}
