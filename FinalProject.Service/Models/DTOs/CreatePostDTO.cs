using FinalProject.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Models.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;

        public List<SelectListItem> GenreList { get; set; }
        public int GenreId { get; set; }
        public string AppUserId { get; set; }

    }
}
