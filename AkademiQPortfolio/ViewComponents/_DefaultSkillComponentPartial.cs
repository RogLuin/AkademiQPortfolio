using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultSkillComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultSkillComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skillList = _context.Skills.ToList();
            return View(skillList);
        }
    }
}
