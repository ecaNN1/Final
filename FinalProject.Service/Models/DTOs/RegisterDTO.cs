using FinalProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Models.DTOs
{
    public class RegisterDTO
    {
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
        [Compare(nameof(Password),ErrorMessage = "Şifreler Aynı Olmalıdır!")]
        public string ConfirmPassword { get; set; }

        public DateTime CreateDate => DateTime.Now;
        public Status Status = Status.Active;
    }
}
