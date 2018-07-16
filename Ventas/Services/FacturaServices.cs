using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventas.Models;

namespace Ventas.Services
{
    public interface IFacturaServices{
        void Create(Factura _factura);
        void Update(Factura _factura);
        void Delete(int ID);
        Factura Find(int? ID);
        List<Factura> FacturaList();
    }
    public class FacturaServices : IFacturaServices
    {
        private readonly GlobalDbContext _context;
        public FacturaServices(GlobalDbContext context)
        {
            _context = context;
        }
        public void Create(Factura _factura)
        {
            var factura = new Factura()
            {
                ID=_factura.ID,
                ClienteName=_factura.ClienteName,
                ClienteID=_factura.ClienteID,
                Itbis=_factura.Itbis,
                SubTotal=_factura.SubTotal,
                Total=_factura.Total
            };
            _context.Factura.Add(factura);
            _context.SaveChanges();
            
        }

        public void Delete(int ID)
        {
            Factura facturaSelect = _context.Factura.Where(x => x.ID == ID).FirstOrDefault();
            _context.Factura.Remove(facturaSelect);
            _context.SaveChanges();
        }

        public List<Factura> FacturaList()
        {
            var facturaList = _context.Factura;
            return facturaList.ToList();
        }

        public Factura Find(int? ID)
        {
            Factura facturaSelect = _context.Factura.Where(x => x.ID == ID).FirstOrDefault();
            return facturaSelect;
        }

        public void Update(Factura _factura)
        {
            Factura factura = _context.Factura.Where(x => x.ID == _factura.ID).FirstOrDefault();
            
            factura.ID = _factura.ID;
            factura.ClienteName = _factura.ClienteName;
            factura.ClienteID = _factura.ClienteID;
            factura.Itbis = _factura.Itbis;
            factura.SubTotal = _factura.SubTotal;
            factura.Total = _factura.Total;

            _context.SaveChanges();
        }

    }
}