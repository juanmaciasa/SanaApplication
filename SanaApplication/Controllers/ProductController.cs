using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;

namespace SanaApplication.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ProductBLO blo = new ProductBLO();
            return View(blo.GetProducts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            string error = "";
            ProductBLO blo = new ProductBLO();
            if (blo.CreateProduct(p.Product_title, (long)p.Product_price, ref error))
            {
                CategoryBLO cBlo = new CategoryBLO();
                int idProduct = Convert.ToInt32(error);
                string[] idCategories = Request["Categories"].ToString().Split(',');
                foreach (var item in idCategories)
                {
                    cBlo.CreateProductCategory(idProduct, Convert.ToInt32(item));
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public PartialViewResult _Categories()
        {
            CategoryBLO blo = new CategoryBLO();
            return PartialView(blo.GetCategories());
        }
    }
}