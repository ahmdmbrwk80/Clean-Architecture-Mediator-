using MediatR;
using PostLand.Application.Features.Posts.Queries.GetPostDetail;
using System;

namespace Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQuery : IRequest<GetPostDetailViewModel>
    {
        public Guid PostId { get; set; }
    }
}
