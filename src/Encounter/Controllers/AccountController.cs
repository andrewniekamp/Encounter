using Encounter.Entities;
using Encounter.Services;
using Encounter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Encounter.Controllers
{
    public class AccountController : Controller
    {
        private IApplicationUserData _applicationUserData;
        private IGameData _gameData;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (
            IApplicationUserData applicationUserData,
            IGameData gameData,
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _applicationUserData = applicationUserData;
            _gameData = gameData;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            
            return View(currentUser);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Email != null && model.AvatarUrl != null && model.PlayerName != null)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Authorized = false,
                    AvatarUrl = model.AvatarUrl,
                    PlayerName = model.PlayerName,
                    DateCreated = DateTime.Now
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    Microsoft.AspNetCore.Identity.SignInResult nextResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    return View();
                }
                return View();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult GetHash(string email)
        {
            if (email != null)
            {
                string hash = CreateMD5(email.ToLower());
                string urlString = "http://unicornify.appspot.com/avatar/" + hash + "?s=128";
                return Json(urlString);
            }
            return Json("/img/unicorn.svg");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.Email != null || model.Password != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        
        public IActionResult UserDeleteGame(int id)
        {
            _applicationUserData.DeleteGame(id);
            return Json(true);
        }

        internal string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
