using FinalProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Models.DTOs
{
    public class CreateGenreDTO
    {
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metinsel İfadeler!")]
        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status = Status.Active;
    }
}
