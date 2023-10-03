using AutoMapper;
using FinalProject.Core.Entities;
using FinalProject.Core.Enums;
using FinalProject.Repository.Interfaces;
using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Models.VMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task Create(CreatePostDTO model)
        {
            var post = _mapper.Map<Post>(model);
            await _postRepository.Create(post);
        }

        public async Task Delete(int id)
        {
            var post = await _postRepository.GetDefault(x => x.Id == id);
            post.DeleteDate = DateTime.Now;
            post.Status = Status.Passive;
            _postRepository.Delete(post);
        }

        public async Task<CreatePostDTO> GetOnlyPostId(int id)
        {
            return _mapper.Map<CreatePostDTO>(await _postRepository.GetDefault(x => x.Id==id));
        }

        public async Task<GetPostDetailVM> GetPostDetail(int id)
        {
            var post = await _postRepository.GetFilteredFirstOrDefault(select: x => new GetPostDetailVM
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                AuthorFullName = x.AppUser.FullName,
                LikeCount = x.Likes.Count(),
                CommentCount = x.Comments.Count,
                Comments = x.Comments.Where(x => x.PostId == id)
                                .OrderByDescending(x => x.CreateDate)
                                .Select(x => new GetCommentVM
                                {
                                    Id = x.Id,
                                    Text = x.Text,
                                    CreateDate = x.CreateDate,
                                    UserName = x.AppUser.UserName
                                }).ToList()
            },
            where: x => x.Status != Status.Passive && x.Id == id,
            join: x => x.Include(x => x.AppUser).ThenInclude(x => x.Comments));

            return post;
        }

        public async Task<List<GetPostVM>> GetPosts()
        {
            var posts = await _postRepository.GetFilteredList(
                select: x => new GetPostVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreateDate),
                join: x => x.Include(x => x.AppUser)
                );

            return posts;
        }

        public void Update(CreatePostDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
