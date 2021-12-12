using PFEBackend.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PFEBackend.Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {

        private VinciMarketContext _context;
        private readonly ILogger<RepositoryCategory> _logger;

        public RepositoryCategory(VinciMarketContext context, ILogger<RepositoryCategory> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id);
            DeleteChilds(category);
        }

        private void DeleteChilds(Category parent)
        {
            IEnumerable<Category> childs = _context.Categories.Where(c => c.ParentId == parent.Id).ToList();
            foreach (Category child in childs)
            {
                DeleteChilds(child);
            }
            _context.Categories.Remove(parent);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Select(c => new Category {Id = c.Id, Name = c.Name, ParentId = c.ParentId}).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Where(c => c.Id == id).Select(c => new Category { Id = c.Id, Name = c.Name, ParentId = c.ParentId }).First();
        }

        public IEnumerable<Category> GetChilds(int id)
        {
            Category parent = _context.Categories.Find(id) ?? new Category();
            _context.Entry(parent).Collection(c => c.ChildCategories).Load();
            return parent.ChildCategories;
        }

        public void UpdateCategory(Category category)
        {
            if (category.Id != category.ParentId)
            {
                IList l = new List<Category>(GetChilds(category.Id));
                if(!GetChilds(category.Id).Any(c => c.Id == category.Id || c.Id == category.ParentId))
                {
                    _context.Categories.Update(category);
                    _context.SaveChanges();
                }
            }
            // ERREUR
        }
    }
}
