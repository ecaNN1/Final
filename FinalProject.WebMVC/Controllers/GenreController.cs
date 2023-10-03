using FinalProject.Service.Models.DTOs;
using FinalProject.Service.Services.GenreService;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WebMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreDTO model)
        {
            if (ModelState.IsValid)
            {
                await _genreService.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genreService.GetGenres());
        }
    }
}
