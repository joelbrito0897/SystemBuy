using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ventas.Models;
using Ventas.Services;

namespace Ventas.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private GlobalDbContext db = new GlobalDbContext();

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET: Products
        public ActionResult Index()
        {

            var product = _productServices._productList();
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productServices.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var valor = db.Category;
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int productId = _productServices.Create(product);

                var detinationFileName = Path.Combine(Server.MapPath("/Content/images/product/"), productId + ".jpg");
                
                var sourceFileName = Path.Combine(Path.GetTempPath(), product.Image);
                System.IO.File.Copy(
                   sourceFileName,
                   detinationFileName
                   );


                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productServices.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productServices.Update(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productServices.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("products/upload")]
        public JsonResult Upload()
        {
            if (Request.Files != null && Request.Files.Count > 0) { }

            //get first file
            HttpPostedFileBase file = Request.Files[0];

            //generate temp file name
            string fileServer = Path.GetTempFileName();

            //save the file from the client
            file.SaveAs(fileServer);

            //return the file name generated back to the client
            return new JsonResult() { Data = Path.GetFileName(fileServer) };
        }

        public JsonResult nameProProductsList()
        {
            var result = _productServices._productList();
            return new JsonResult() { Data=result};
        }
        public JsonResult nameProduct(string product)
        {
            var result = _productServices._productName(product);

            return new JsonResult() { Data = result };
        }

        public JsonResult ProductName(int id)
        {
            var result = _productServices.Find(id);
            return new JsonResult() { Data = result };
        }
    }
}
