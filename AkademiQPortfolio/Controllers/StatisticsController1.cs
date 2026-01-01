using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class StatisticsController1 : Controller
    {
        private readonly AppDbContext _context;

        public StatisticsController1(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult StatisticsCard()
        {
            var messageCount = _context.Messages.Count();
            var messageCountByIsReadTrue = _context.Messages.Where(x => x.IsRead == true).Count();
            var messageCountByIsReadFalse = _context.Messages.Where(x => x.IsRead == false).Count();
            var skillCount = _context.Skills.Count();
            var skillAvgValue = _context.Skills.Average(x => x.SkillValue);
            var skillValueBiggerThan70 = _context.Skills.Where(x => x.SkillValue >= 70).Count();

            ViewBag.MessageCount = messageCount;
            ViewBag.SkillCount = skillCount;
            ViewBag.MessageCountByIsReadTrue = messageCountByIsReadTrue;
            ViewBag.messageCountByIsReadFalse = messageCountByIsReadFalse;
            ViewBag.SkillAvgValue = skillAvgValue;
            ViewBag.SkillValueBiggerThan70 = skillValueBiggerThan70;

            var messageSubjectByWorkOffer = _context.Messages.Where(x => x.MessageSubject == "Proje Teklifi & İş Birliği").Count();
            var messageSubjectByApiDevelopment = _context.Messages.Where(x => x.MessageSubject == "Web / API Geliştirme Talebi").Count();
            var messageSubjectByEducationOffer = _context.Messages.Where(x => x.MessageSubject == "Eğitim & Kurumsal Eğitim Talebi").Count();

            ViewBag.MessageSubjectByWorkOffer = messageSubjectByWorkOffer;
            ViewBag.MessageSubjectByApiDevelopment = messageSubjectByApiDevelopment;
            ViewBag.MessageSubjectByEducationOffer = messageSubjectByEducationOffer;

            return View();
        }
    }
}
