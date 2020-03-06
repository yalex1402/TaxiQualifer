﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TaxiQualifer.Common.Enums;
using TaxiQualifer.Web.Data.Entities;
using TaxiQualifer.Web.Models;

namespace TaxiQualifer.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserHelper(
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserEntity> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserEntity user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(UserEntity user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
            model.Username,
            model.Password,
            model.RememberMe,
            false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserEntity> AddUserAsync(AddUserViewModel model, string path)
        {
            UserEntity userEntity = new UserEntity
            {
                Address = model.Address,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PicturePath = path,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username,
                UserType = model.UserTypeId == 1 ? UserType.Driver : UserType.User
            };

            IdentityResult result = await _userManager.CreateAsync(userEntity, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            UserEntity newUser = await GetUserByEmailAsync(model.Username);
            await AddUserToRoleAsync(newUser, userEntity.UserType.ToString());
            return newUser;
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserAsync(UserEntity user)
        {
            return await _userManager.UpdateAsync(user);
        }


    }
}
