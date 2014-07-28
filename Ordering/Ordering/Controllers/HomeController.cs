using System.Collections.Generic;
using System.Web.Mvc;
using Ordering.Enums;
using Ordering.Models;
using Ef;

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
            var orderRepository = new OrderRepository();
           // model.ProductList =orderRepository.GetAllProducts();
            return View(model);
        }
        public JsonResult GetProducts()
        {
            var orderRepository = new OrderRepository();
            var productList = orderRepository.GetAllProducts();

            return Json(productList, JsonRequestBehavior.AllowGet);
        }

    }
}

