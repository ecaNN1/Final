using AutoMapper;
using FinalProject.Core.Entities;
using FinalProject.Core.Enums;
using FinalProject.Repository.Interfaces;
using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateGenreDTO model)
        {
            var genre = _mapper.Map<Genre>(model);
            await _genreRepository.Create(genre);
        }

        public async Task Delete(int id)
        {
            var genre = await _genreRepository.GetDefault(x => x.Id == id);
            genre.DeleteDate = DateTime.Now;
            genre.Status = Status.Passive;

            _genreRepository.Delete(genre);
        }

        public async Task<UpdateGenreDTO> GetById(int id)
        {
            var genre = await _genreRepository.GetFilteredFirstOrDefault(select: x => new UpdateGenreDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            },
            where: x => x.Id == id && x.Status != Status.Passive);

            //II. YOL
            //var genre2 = await _genreRepository.GetDefault(x => x.Id == id && x.Status != Status.Passive);
            //var updateGenre = _mapper.Map<UpdateGenreDTO>(genre2);

            return genre;
        }

        public async Task<List<GetGenreVM>> GetGenres()
        {
            var genres = await _genreRepository.GetFilteredList(select: x => new GetGenreVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            },
            where: x => x.Status != Status.Passive,
            orderBy: x => x.OrderBy(x => x.Name));

            return genres;
        }

        public void Update(UpdateGenreDTO model)
        {
            _genreRepository.Update(_mapper.Map<Genre>(model));
        }
    }
}
