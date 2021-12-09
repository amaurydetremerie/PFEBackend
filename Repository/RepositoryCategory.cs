using PFEBackend.Models;

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
            _context.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.First(c => c.Id == id);
            _context.Categories.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToArray();
        }

        public Category GetById(int id)
        {
            return _context.Categories.First(c => c.Id == id);
        }

        public IEnumerable<Category> GetByParent(int id)
        {
            return _context.Categories.Find(id).ChildCategories.ToArray();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

        }
    }
}
