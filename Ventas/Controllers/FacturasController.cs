using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Models;
using Ventas.Services;

namespace Ventas.Controllers
{
    public class FacturasController : Controller
    {
        GlobalDbContext db = new GlobalDbContext();
        private readonly IFacturaServices _facturaServices;

        private readonly ICustomerServices _customerServices;
        private readonly GlobalDbContext _context;
        public FacturasController(IFacturaServices facturaServices, ICustomerServices customerServices, GlobalDbContext context)
        {
            _customerServices = customerServices;
            _facturaServices = facturaServices;
            _context = context;
        }
        // GET: Facturas
        public ActionResult Index()
        {
            var facturaList = _facturaServices.FacturaList();
            return View(facturaList);
        }
        [HttpGet]
        public ActionResult NuevaFactura()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevaFactura(Factura factura)
        {
            if (ModelState.IsValid)
            {
                _facturaServices.Create(factura);
                return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }
        public ActionResult Eliminar(int ID)
        {
            _facturaServices.Delete(ID);
            return RedirectToAction(nameof(Index));
        }


        //public ActionResult Index()
        //{
        //    return View("NuevaFactura");
        //}

        public JsonResult ListaCliente()
        {
            var listClient = db.Customer.ToList();

            return new JsonResult() { Data = listClient };
        }

       public JsonResult ClienteName(int id)
        {
            var cliente = db.Customer.SingleOrDefault(x => x.ID == id);

            return new JsonResult() { Data = cliente };
        }

        public ActionResult ObtenerClientes()
        {
            List<Customer> lista = _customerServices.CustomerList();
            return View(lista);
        }

    }
}