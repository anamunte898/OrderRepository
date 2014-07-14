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
        public ActionResult Index(bool isAdmin = true)
        {
            var model = new OrderModel
            {
                IsAdmin = isAdmin,
                OrderList = new List<Order> {new Order() {Price = 10, ProductName = "ceva", Status = StatusEnum.New}}
            };
            return View(model);
        }

        public void Process(Order item)
        {
            
        }
    }
}

