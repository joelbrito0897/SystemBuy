using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventas.Models;

namespace Ventas.Services
{
    public interface ICategoryServices
    {
        void create(Category _category);
        void update(Category _category);
        void Delete(int ID);
        Category Details(int? ID);
        List<Category> _categoryList();
    }
    public class CategoryServices : ICategoryServices
    {
        private readonly GlobalDbContext _context;

        public CategoryServices(GlobalDbContext context)
        {
            _context = context;
        }
        public void create(Category _category)
        {
            Category category = new Category()
            {
                ID = _category.ID,
                Name = _category.Name,
                Description = _category.Description
            };

            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            Category categorySelect = _context.Category.Where(x => x.ID == ID).FirstOrDefault();

            _context.Category.Remove(categorySelect);
            _context.SaveChanges();
        }

        public Category Details(int? ID)
        {
            Category categorySelect = _context.Category.Where(x => x.ID == ID).FirstOrDefault();

            return categorySelect;
        }

        public void update(Category _category)
        {
            Category categorySelect = _context.Category.Where(x => x.ID == _category.ID).FirstOrDefault();

            categorySelect.ID = _category.ID;
            categorySelect.Name = _category.Name;
            categorySelect.Description = _category.Description;
            
        }
        public List<Category> _categoryList()
        {

            var category = _context.Category;

            return category.ToList();


        }
    }
}