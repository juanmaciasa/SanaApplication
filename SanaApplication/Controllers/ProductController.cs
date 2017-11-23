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
        public ActionResult Index(int id = 0)
        {
            if (id == 1)
            {
                ViewBag.currentStorage = "";
                List<Product> products = (List<Product>)HttpRuntime.Cache.Get("Products") ?? new List<Product>();
                List<VIEW_PRODUCTS> modelProducts = new List<VIEW_PRODUCTS>();
                foreach (var item in products)
                {
                    modelProducts.Add(new VIEW_PRODUCTS { Product_id = item.Product_id, Product_title = item.Product_title, Product_price = item.Product_price });
                }
                return View(modelProducts.AsEnumerable());
            }
            else
            {
                ViewBag.currentStorage = "checked";
                ProductBLO blo = new ProductBLO();
                return View(blo.GetProducts());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            string error = "";
            var storageOption = Request["storage"] ?? "off";
            if (storageOption == "on")
            {
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
            else
            {
                List<Product> products = (List<Product>)HttpRuntime.Cache.Get("Products") ?? new List<Product>();
                p.Product_id = products.Count + 1;
                products.Add(p);
                HttpRuntime.Cache.Insert("Products", products, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
                return RedirectToAction("Index", new { id = 1 });
            }
        }

        public PartialViewResult _Categories()
        {
            CategoryBLO blo = new CategoryBLO();
            return PartialView(blo.GetCategories());
        }
    }
}