using FinalProject.Service.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);

        Task<SignInResult> LogIn(LogInDTO model);

        Task LogOut();

        Task<UpdateProfileDTO> GetById(string id);
        Task UpdateUser(UpdateProfileDTO model);
    }
}
