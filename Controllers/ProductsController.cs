using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEka2019.Models;

namespace WebAppEka2019.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            northwindEntities db = new northwindEntities();
            List<Products> tuotteet = db.Products.ToList();
            db.Dispose();
            return View(tuotteet);
        }
    }
}