using AutoMapper;
using FinalProject.Core.Entities;
using FinalProject.Core.Enums;
using FinalProject.Repository.Interfaces;
using FinalProject.Service.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await _appUserRepository.GetFilteredFirstOrDefault(
                select: x => new UpdateProfileDTO
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    UserName = x.UserName,
                    Email = x.Email
                },
                where: x => x.Id == id && x.Status != Status.Passive);
            return user;
        }

        public async Task<SignInResult> LogIn(LogInDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            var user = await _appUserRepository.GetDefault(x => x.Id == model.Id);
            if (user != null)
            {
                user.FullName = model.FullName;
                _appUserRepository.Update(user);

                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }
                if (model.Email != null)
                {
                    await _userManager.SetEmailAsync(user, model.Email);
                }
                if (model.UserName != null)
                {
                    await _userManager.SetUserNameAsync(user, model.UserName);
                    await _signInManager.SignInAsync(user, false);
                }
            }
        }
    }
}
