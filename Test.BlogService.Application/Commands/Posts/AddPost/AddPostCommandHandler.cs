using Company.Service.Application.Configuration.Commands;
using Test.BlogService.Domain.Posts;

namespace Test.BlogService.Application.Commands.Posts
{
    public class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostDTO>
    {
        private readonly IPostRepository _postRepository;

        public AddPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostDTO> Handle(AddPostCommand request,
            CancellationToken cancellationToken)
        {
            var entityToAdd = new Post(request.Title, request.Content);
            Post createdEntity = await _postRepository.AddPost(entityToAdd);

            return new PostDTO(createdEntity.Id, createdEntity.Title, createdEntity.Content, createdEntity.DateCreated,
                createdEntity.DateUpdated);
        }
    }
}
