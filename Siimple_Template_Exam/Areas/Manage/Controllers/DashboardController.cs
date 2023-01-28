using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Siimple_Template_Exam.Models;
using System.Data;

namespace Siimple_Template_Exam.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        Fullname = "Super Admin"
        //    };
        //    await _userManager.CreateAsync(appUser, "Admin123");
        //    return Ok(appUser);
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role = new IdentityRole("SuperAdmin");
        //    await _roleManager.CreateAsync(role);
        //    return Ok("Create Role");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
        //    return Ok("Role Added");
        //}
    }
}
