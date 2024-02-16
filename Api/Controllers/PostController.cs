﻿using Application.Features.Posts.Commands.CreatePost;
using Application.Features.Posts.Commands.DeletePost;
using Application.Features.Posts.Commands.UpdatePost;
using Application.Features.Posts.Queries.GetPostDetail;
using Application.Features.Posts.Queries.GetPostList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetPostListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetPostListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostDetailViewModel>> GetPostById(Guid id)
        {
            var getEventDetailQuery = new GetPostDetailQuery() { PostId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            Guid id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeletePostCommand() { postId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }
    }
}
