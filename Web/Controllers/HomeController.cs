using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.MessageService;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            MessageServiceClient serviceClient = new MessageServiceClient();
            var allMessages = serviceClient.GetAllMessages();

            View(new MessageModel
            {
                Messages = allMessages.ToList()
            });

            return View();
        }
    }
}