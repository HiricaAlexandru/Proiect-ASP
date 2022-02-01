using lab210.BLL.Interfaces;
using lab210.BLL.Models;
using lab210.DAL.Entitati;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Manager
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<Utilizatori> _userManager;
        private readonly SignInManager<Utilizatori> _signInManager;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(UserManager<Utilizatori> userManager,
            SignInManager<Utilizatori> signInManager,
            ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new LoginResult
                {
                    Success = false
                };
            else
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await _tokenHelper.CreateAccessToken(user);
                    var refreshToken = _tokenHelper.CreateRefreshToken();

                    user.RefreshToken = refreshToken;
                    await _userManager.UpdateAsync(user);

                    return new LoginResult
                    {
                        Success = true,
                        AccesToken = token,
                        RefreshToken = refreshToken
                    };
                }
                else
                    return new LoginResult
                    {
                        Success = false

                    };
            }

        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new Utilizatori
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Refresh(RefreshModel refreshModel)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(refreshModel.AccessToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(username);

            if (user.RefreshToken != refreshModel.RefreshToken)
                return "Bad Refresh";

            var newJwtToken = await _tokenHelper.CreateAccessToken(user);

            return newJwtToken;
        }


    }
}
