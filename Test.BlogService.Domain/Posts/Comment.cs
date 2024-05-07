using Company.Service.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Test.BlogService.Domain.Posts
{
    public sealed partial class Comment : Entity
    {
        [Required]
        public int PostId { get; private set; }
        
        [MaxLength(250)]
        public string Content { get; private set; }
        
        public Post Post { get; private set; }

        public Comment(Post post, string content)
        {
            PostId = post.Id;
            Content = content;
            Post = post;

            Validate();
        }
    }
}
