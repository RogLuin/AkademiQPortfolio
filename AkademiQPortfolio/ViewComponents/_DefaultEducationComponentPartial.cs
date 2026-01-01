using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultEducationComponentPartial: ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultEducationComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var educationList = _context.Educations.ToList();
            return View(educationList);
        }
    }
}
