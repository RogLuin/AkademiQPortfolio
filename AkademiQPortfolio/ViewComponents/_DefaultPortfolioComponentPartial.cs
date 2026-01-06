using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultPortfolioComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var workList = _context.Works.ToList();
            return View(workList);
        }
    }
}