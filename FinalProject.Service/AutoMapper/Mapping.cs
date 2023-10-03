using AutoMapper;
using FinalProject.Core.Entities;
using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Genre, CreateGenreDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();
            CreateMap<Genre, GetGenreVM>().ReverseMap();

            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LogInDTO>().ReverseMap();

            CreateMap<Post, CreatePostDTO>().ReverseMap();
        }
    }
}
