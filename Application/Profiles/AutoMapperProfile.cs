using Application.Features.Posts.Commands.CreatePost;
using Application.Features.Posts.Queries.GetPostList;
using AutoMapper;
using Domain_Model;
using PostLand.Application.Features.Posts.Queries.GetPostDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();

        }
    }
}
