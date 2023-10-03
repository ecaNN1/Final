using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetPostVM>> GetPosts();

        Task<GetPostDetailVM> GetPostDetail(int id);

        Task<CreatePostDTO> GetOnlyPostId(int id);
        Task Create(CreatePostDTO model);
        void Update(CreatePostDTO model);

        Task Delete(int id);
    }
}
