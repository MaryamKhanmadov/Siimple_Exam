using Microsoft.AspNetCore.Mvc;
using Siimple_Template_Exam.Data;
using Siimple_Template_Exam.Models;

namespace Siimple_Template_Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            List<Card> cards = _dataContext.Cards.ToList(); 
            return View(cards);
        }

    }
}