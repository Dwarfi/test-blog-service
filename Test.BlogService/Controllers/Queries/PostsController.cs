using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.BlogService.Application.Commands.Posts;

namespace Test.BlogService.API.Controllers.Queries
{
    [ApiController]
    [Route("query/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetPostsCommand()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required][Range(0, int.MaxValue)] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(await _mediator.Send(new GetPostByIdCommand(id)));
        }
    }
}
