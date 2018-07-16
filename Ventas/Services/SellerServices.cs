using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventas.Models;

namespace Ventas.Services
{
    public interface ISellerServices
    {
        void Create(Seller _seller);
        void Update(Seller _seller);
        void Delete(int ID);
        Seller Find(int? ID);
        List<Seller> SellerList();
    }
    public class SellerServices : ISellerServices
    {

        private readonly GlobalDbContext _context;
        public SellerServices(GlobalDbContext context)
        {
            _context = context;
        }
        public void Create(Seller _seller)
        {
            Seller seller = new Seller()
            {
                ID = _seller.ID,
                Name = _seller.Name,
                LastName = _seller.LastName,
                Addres = _seller.Addres,
                Phone = _seller.Phone
            };
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            Seller sellerSelect = _context.Seller.Where(x => x.ID == ID).FirstOrDefault();
            _context.Seller.Remove(sellerSelect);
            _context.SaveChanges();
        }

        public Seller Find(int? ID)
        {
            Seller sellerSelect = _context.Seller.Where(x => x.ID == ID).FirstOrDefault();
            return sellerSelect;
        }

        public List<Seller> SellerList()
        {
            var selletList = _context.Seller;
            return selletList.ToList();
        }

        public void Update(Seller _seller)
        {
            Seller seller = _context.Seller.Where(x => x.ID == _seller.ID).FirstOrDefault();
            seller.ID = _seller.ID;
            seller.Name = seller.Name;
            seller.LastName = _seller.LastName;
            seller.Addres = _seller.Addres;
            seller.Phone = _seller.Phone;

            _context.SaveChanges();
        }
    }
}