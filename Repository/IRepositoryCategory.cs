using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public interface IRepositoryCategory
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        IEnumerable<Category> GetByParent(int id);

        void UpdateCategory(Category category);

        void AddCategory(Category category);

        void DeleteCategory(int id);
    }
}
