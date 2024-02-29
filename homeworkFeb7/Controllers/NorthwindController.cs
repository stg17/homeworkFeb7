using homeworkFeb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homeworkFeb7.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchProducts()
        {
            NorthwindDBManager manager = new NorthwindDBManager(Properties.Settings.Default.ConStr);
            return View(new ProductsViewModel { products = manager.GetProducts()});
        }

        public ActionResult SearchResults(int min, int max)
        {
            NorthwindDBManager manager = new NorthwindDBManager(Properties.Settings.Default.ConStr);
            return View(new SearchResultsViewModel { products = manager.GetProducts(min, max), min = min, max = max});
        }
    }
}