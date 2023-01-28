using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siimple_Template_Exam.Data;
using Siimple_Template_Exam.Helpers;
using Siimple_Template_Exam.Models;

namespace Siimple_Template_Exam.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class CardController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public CardController(DataContext dataContext , IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Card> cards = _dataContext.Cards.ToList();
            return View(cards);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Card card)
        {
            if (!ModelState.IsValid) return View();

            if (card.ImageFile.ContentType != "image/png" && card.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "You can upload image type png or jpeg");
                return View();
            }
            if(card.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "You can upload image size than lower 2mb");
                return View();
            }

            card.ImageUrl = card.ImageFile.SaveFile(_env.WebRootPath, "uploads/card");

            _dataContext.Cards.Add(card);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Card card = _dataContext.Cards.Find(id);
            if (card is null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Card card)
        {
            if (!ModelState.IsValid) return View();

            Card existCard = _dataContext.Cards.FirstOrDefault(x=>x.Id == card.Id);
            if(existCard is null) return NotFound();

            if(card.ImageFile is not null)
            {
                existCard.ImageUrl.DeleteOld(_env.WebRootPath, "uploads/card");

                if (card.ImageFile.ContentType != "image/png" && card.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "You can upload image type png or jpeg");
                    return View();
                }
                if (card.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "You can upload image size than lower 2mb");
                    return View();
                }
                existCard.ImageUrl = card.ImageFile.SaveFile(_env.WebRootPath, "uploads/card");
            }
            existCard.Title = card.Title;
            existCard.Descreption = card.Descreption;
            existCard.IconUrl = card.IconUrl;

            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Card card = _dataContext.Cards.FirstOrDefault(x=>x.Id == id);
            if (card is null) return NotFound();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\card", card.ImageUrl);
            System.IO.File.Delete(path);

            _dataContext.Cards.Remove(card);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
