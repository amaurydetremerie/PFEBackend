using PFEBackend.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PFEBackend.Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {

        private VinciMarketContext _context;

        public RepositoryCategory(VinciMarketContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            if (_context.Categories.Contains(category))
                throw new RepositoryException(HttpStatusCode.Forbidden, "Cette catégorie existe déjà.");
            _context.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id) ?? throw new RepositoryException(HttpStatusCode.NotFound, "Catégorie avec l'ID " + id + "n'existe pas.");
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
            return _context.Categories.Where(c => c.Id == id).Select(c => new Category { Id = c.Id, Name = c.Name, ParentId = c.ParentId }).First() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Catégorie avec l'ID " + id + "n'existe pas."); ;
        }

        public IEnumerable<Category> GetChilds(int id)
        {
            Category parent = _context.Categories.Find(id) ?? throw new RepositoryException(HttpStatusCode.NotFound, "Catégorie avec l'ID " + id + "n'existe pas.");
            _context.Entry(parent).Collection(c => c.ChildCategories).Load();
            return parent.ChildCategories.Select(c => new Category { Id = c.Id, Name = c.Name, ParentId = c.ParentId }) ?? Enumerable.Empty<Category>();
        }

        public void UpdateCategory(Category category)
        {
            if (category.Id != category.ParentId)
            {
                IList l = new List<Category>(GetChilds(category.Id));
                if(!GetChilds(category.Id).Any(c => c.Id == category.Id || c.Id == category.ParentId))
                {
                    Category old = _context.Categories.Find(category.Id) ?? throw new RepositoryException(HttpStatusCode.NotFound, "Catégorie avec l'ID " + category.Id + "n'existe pas.");
                    _context.Entry(old).CurrentValues.SetValues(category);
                    _context.SaveChanges();
                    return;
                }
                throw new RepositoryException(HttpStatusCode.Forbidden, "Boucle parent/enfant détectée.");
            }
            throw new RepositoryException(HttpStatusCode.Forbidden, "Une catégorie ne peut pas être son parent.");
        }

        public IEnumerable<Category> GetParents()
        {
            return _context.Categories.Where(c => c.ParentId == null).Select(c => new Category { Id = c.Id, Name = c.Name, ParentId = c.ParentId, ChildCategories = c.ChildCategories }).ToList();
        }
    }
}
