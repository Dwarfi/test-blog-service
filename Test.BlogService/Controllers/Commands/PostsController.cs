using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.BlogService.Application.Commands.Posts;

namespace Test.BlogService.API.Controllers.Commands
{
    [ApiController]
    [Route("command/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IMediator mediator, ILogger<PostsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetPostsCommand()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([Required][Range(0, int.MaxValue)] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(await _mediator.Send(new GetPostByIdCommand(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPostRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            return Ok(await _mediator.Send(new AddPostCommand(request.Title, request.Content)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required][Range(0, int.MaxValue)] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(await _mediator.Send(new DeletePostCommand(id)));
        }

        [HttpPost("{id}/Comments")]
        public async Task<IActionResult> CreateComment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
