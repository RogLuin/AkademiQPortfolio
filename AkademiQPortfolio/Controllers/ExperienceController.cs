using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

public class ExperienceController : Controller
{
    private readonly AppDbContext _context;

    public ExperienceController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Experiences.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateExperience()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateExperience(Experience experience)
    {
        if (!ModelState.IsValid)
        {
            return View(experience);
        }

        _context.Experiences.Add(experience);
        _context.SaveChanges();
        return RedirectToAction("index");
    }

    [HttpGet]
    public IActionResult UpdateExperience(int id)
    {
        var experience = _context.Experiences
            .FirstOrDefault(x => x.ExperianceId == id);

        if (experience == null)
        {
            return NotFound();
        }

        return View(experience);
    }

    [HttpPost]
    public IActionResult UpdateExperience(Experience experience)
    {
        if (!ModelState.IsValid)
        {
            return View(experience);
        }

        var existing = _context.Experiences
            .FirstOrDefault(x => x.ExperianceId == experience.ExperianceId);

        if (existing == null)
        {
            return NotFound();
        }

        existing.Title = experience.Title;
        existing.CompanyName = experience.CompanyName;
        existing.WorkDate = experience.WorkDate;
        existing.Description = experience.Description;

        _context.SaveChanges();

        return RedirectToAction("index");
    }

    public IActionResult DeleteExperience(int id)
    {
        var experience = _context.Experiences.Find(id);

        if (experience == null)
        {
            return NotFound();
        }

        _context.Experiences.Remove(experience);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
