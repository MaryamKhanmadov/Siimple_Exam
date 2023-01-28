using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siimple_Template_Exam.Data;
using Siimple_Template_Exam.Helpers;
using Siimple_Template_Exam.Models;
using System.Data;

namespace Siimple_Template_Exam.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;

        public SettingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index(int page =1)
        {
            var query = _dataContext.Settings.AsQueryable();
            var paginated = PaginatedList<Setting>.Create(query, 2, page);
            return View(paginated);
        }
        public IActionResult Update(int id)
        {
            Setting setting = _dataContext.Settings.Find(id);
            if (setting is null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {
            if (!ModelState.IsValid) return View();

            Setting existsetting = _dataContext.Settings.FirstOrDefault(x => x.Id == setting.Id);
            if (existsetting is null) return NotFound();

            existsetting.Value = setting.Value;

            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
