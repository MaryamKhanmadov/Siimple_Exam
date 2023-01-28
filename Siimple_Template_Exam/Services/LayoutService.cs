using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Siimple_Template_Exam.Data;
using Siimple_Template_Exam.Models;

namespace Siimple_Template_Exam.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;

        public LayoutService(UserManager<AppUser> userManager , IHttpContextAccessor httpContextAccessor , DataContext dataContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }
        public async Task<AppUser> GetUser()
        {
            string name = _httpContextAccessor.HttpContext.User.Identity.Name;
            if(name is not null)
            {
                AppUser appUser = await _userManager.FindByNameAsync(name);
                return appUser; 
            }
            return null;
        }
        public async Task<List<Setting>> GetSettings()
        {
            return await _dataContext.Settings.ToListAsync();
        }

    }
}
