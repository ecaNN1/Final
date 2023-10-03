using FinalProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Models.DTOs
{
    public class UpdateProfileDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez!")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status = Status.Modified;
    }
}
