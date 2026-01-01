using AkademiQPortfolio.Data;
using AkademiQPortfolio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{

    public class MessageController : Controller
    {
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 6;
            var values = _context.Messages
                .OrderByDescending(x => x.SendDate);
                

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMessageDetails(int id)
        {
            var value = _context.Messages.Find(id);

            if (value != null)
            {
                if (value.IsRead == false)
                {
                    value.IsRead = true;
                    _context.SaveChanges();
                }
                return Json(new
                {
                    messageId = value.MessageId,
                    senderName = value.SenderName,
                    senderEmail = value.SenderEmail,
                    subject = value.MessageSubject,
                    messageText = value.MessageText,
                    sendDate = value.SendDate.HasValue ? value.SendDate.Value.ToString("dd MMM yyyy") : "",
                    sendTime = value.SendDate.HasValue ? value.SendDate.Value.ToString("HH:mm") : ""
                });
            }

            return NotFound();
        }

        public IActionResult DeleteMessage(int id)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Messages.Find(id);
                _context.Messages.Remove(values);
                _context.SaveChanges();
                TempData["Delete"] = "Mesaj başarıyla silindi!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                message.IsRead = false;
                _context.Messages.Add(message);
                _context.SaveChanges();

                TempData["MessageSent"] = "Mesaj başarıyla gönderildi!";
                return RedirectToAction("Index", "Default");
            }

            return View(message);
        }
    }
}
