using PFEBackend.Models;

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
            Category category = _context.Categories.First(c => c.Id == id);
            DeleteChilds(category);
        }

        private void DeleteChilds(Category parent)
        {
            foreach(Category child in parent.ChildCategories ?? Enumerable.Empty<Category>())
            {
                _logger.LogInformation("\n\n\n\n\n\n\n Delete child " + child.Name + "\n\n\n\n\n\n\n\n\n\n");
                DeleteChilds(child);
                _context.Categories.Remove(child);
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

        // Ne fonctionne pas pour l'instant
        public IEnumerable<Category> GetChilds(int id)
        {
            return ((_context.Categories.Find(id) ?? new Category()).ChildCategories ?? Enumerable.Empty<Category>()).ToList();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
