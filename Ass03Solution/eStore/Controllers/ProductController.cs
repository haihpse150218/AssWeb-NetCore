using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository proRep = new ProductRepository(Program.ConnectionString);

       


        // GET: ProductController
        public ActionResult Index()
        {
            var proList = proRep.GetAllProducts();
            return View(proList);
        }

        public ActionResult SearchPro()
        {
            string value = Request.Form["txtsearch"];
            string type = Request.Form["txttype"];
            var proList = new List<Product>();
            if (type.Equals("name"))
            {
                proList = proRep.GetProductByName(value);
            }
            else
            {
                try
                {
                    decimal unitPrice = decimal.Parse(value);
                    proList = proRep.GetProductByUnitPrice(unitPrice);
                }
                catch (Exception ex)
                {
                   
                }

               
               
            }

            return View("Index", proList);

        }


        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pro = proRep.GetProductByID(id.Value);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // GET: ProductController/Create
        public ActionResult Create() => View();

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proID = proRep.GetProductByID(pro.ProductId);
                    if (proID != null)
                    {
                        TempData["error"] = "ID already exists";
                        return View("Create");
                    }
                    proRep.InsertProduct(pro);
                }
                TempData["complete"] = "Completed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(pro);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pro = proRep.GetProductByID(id.Value);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                if (id != pro.ProductId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    proRep.UpdateProduct(pro);
                }
                TempData["complete"] = "Completed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag["Message"] = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pro = proRep.GetProductByID(id.Value);
            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                proRep.DeleteProduct(id);
                TempData["complete"] = "Completed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}

