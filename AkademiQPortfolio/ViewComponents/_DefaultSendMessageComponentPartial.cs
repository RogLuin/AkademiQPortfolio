using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents
{
    public class _DefaultSendMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new Message();
            return View();
        }
    }
}
