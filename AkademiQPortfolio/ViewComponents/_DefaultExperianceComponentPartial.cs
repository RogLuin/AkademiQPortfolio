using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultExperianceComponentPartial: ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultExperianceComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var experianceList = _context.Experiences.ToList();
            return View(experianceList);
        }
    }
}
