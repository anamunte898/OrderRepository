using System.Collections.Generic;
using System.Web.Mvc;
using Ordering.Enums;
using Ordering.Models;

namespace Ordering.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Order(bool isAdmin = true)
        {
            var model = new OrderModel();
            return View(model);
        }

    }
}

