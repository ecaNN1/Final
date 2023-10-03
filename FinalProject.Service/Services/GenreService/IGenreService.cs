using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.GenreService
{
    public interface IGenreService
    {
        Task Create(CreateGenreDTO model);

        void Update(UpdateGenreDTO model);

        Task Delete(int id);

        Task<UpdateGenreDTO> GetById(int id);

        Task<List<GetGenreVM>> GetGenres();
    }
}
