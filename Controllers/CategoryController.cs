using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;

namespace PFEBackend.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private IRepositoryCategory _repositoryCategory;

        public CategoryController(IRepositoryCategory repository)
        {
            _repositoryCategory = repository;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _repositoryCategory.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Category GetById(int id)
        {
            return _repositoryCategory.GetById(id);
        }

        [HttpGet]
        [Route("childs/{id}")]
        public IEnumerable<Category> GetChilds(int id)
        {
            return _repositoryCategory.GetChilds(id);
        }

        [HttpGet]
        [Route("parents")]
        public IEnumerable<Category> GetParents()
        {
            return _repositoryCategory.GetParents();
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public void AddCategory(Category category)
        {
            _repositoryCategory.AddCategory(category);
        }

        [Authorize(Roles = "administrator")]
        [HttpDelete]
        [Route("{id}")]
        public void DeleteCategory(int id)
        {
            _repositoryCategory.DeleteCategory(id);
        }

        [Authorize(Roles = "administrator")]
        [HttpPut]
        public void UpdateCategory(Category category)
        {
            _repositoryCategory.UpdateCategory(category);
        }
    }
}
