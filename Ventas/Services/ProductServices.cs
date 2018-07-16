
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventas.Models;

namespace Ventas.Services
{
    public interface IProductServices
    {
        int Create(Product _product);
        void Update(Product _product);
        void Delete(int ID);
        Product Find(int? ID);
        List<Product> _productList();


        List<Product> _productName(string term);

    }
    public class ProductServices : IProductServices
    {
        private readonly GlobalDbContext _context;

        public ProductServices(GlobalDbContext context)
        {
            _context = context;
        }

        public int Create(Product _product)
        {
            Product product = new Product()
            {
                ID=_product.ID,
                Name=_product.Name,
                Price=_product.Price,
                Image=_product.ID+".jpg",
                CategoryID=_product.CategoryID,
                Category=_product.Category
                
            };
            _context.Product.Add(product);
            _context.SaveChanges();

            return product.ID;
        }

        public void Delete(int ID)
        {
            Product productSelect = _context.Product.Where(x => x.ID == ID).FirstOrDefault();
            _context.Product.Remove(productSelect);
            _context.SaveChanges();
        }

        public Product Find(int? ID)
        {
            Product productSelect = _context.Product.Where(x => x.ID == ID).FirstOrDefault();
            return productSelect;
        }
    
        public void Update(Product _product)
        {
            Product productSelect = _context.Product.Where(x => x.ID == _product.ID).FirstOrDefault();

            productSelect.ID = _product.ID;
            productSelect.Name = _product.Name;
            productSelect.Price = _product.Price;
            productSelect.CategoryID = _product.CategoryID;
            productSelect.Category = _product.Category;

            _context.SaveChanges();
        }

        public List<Product> _productList()
        {
            var products = _context.Product.Include("Category");

            return products.ToList();
            
            
        }

        public List<Product> _productName(string product)
        {
            var resultado = _context.Product.Where(x => x.Name.Contains(product)).ToList();
            return resultado;
        }
    }
}