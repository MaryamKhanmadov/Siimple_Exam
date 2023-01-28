using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Siimple_Template_Exam.Areas.Manage.ViewModels;
using Siimple_Template_Exam.Models;

namespace Siimple_Template_Exam.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(adminLoginVM.UserName);
            if(appUser is null)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, adminLoginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View();
            }
            return RedirectToAction("index" , "dashboard");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
