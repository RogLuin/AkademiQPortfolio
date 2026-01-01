using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDbContext _context;

        public EducationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        public IActionResult CreateEducation() => View();

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Educations.Add(education);
                _context.SaveChanges();
                TempData["Create"] = "Bilgiler başarıyla eklendi!";
                return RedirectToAction("Index");
            }
            return View(education);
        }

        public IActionResult DeleteEducation(int id)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Educations.Find(id);
                _context.Educations.Remove(values);
                _context.SaveChanges();
                TempData["Delete"] = "Bilgiler başarıyla silindi!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateEducation(int id)
        {
            var values = _context.Educations.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Educations.Find(education.EducationId);
                values.Department = education.Department;
                values.Title = education.Title;
                values.EducationDate = education.EducationDate;
                _context.SaveChanges();
                TempData["Update"] = "Bilgiler başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            return View(education);

        }
    }
}
