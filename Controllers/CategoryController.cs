using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;

namespace PFEBackend.Controllers
{
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
        [AllowAnonymous]
        public IEnumerable<Category> GetAll()
        {
            return _repositoryCategory.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public Category GetById(int id)
        {
            return _repositoryCategory.GetById(id);
        }

        [HttpGet]
        [Route("childs/{id}")]
        [AllowAnonymous]
        public IEnumerable<Category> GetChilds(int id)
        {
            return _repositoryCategory.GetChilds(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public void AddCategory(Category category)
        {
            _repositoryCategory.AddCategory(category);
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public void DeleteCategory(int id)
        {
            _repositoryCategory.DeleteCategory(id);
        }

        [HttpPut]
        [AllowAnonymous]
        public void UpdateCategory(Category category)
        {
            _repositoryCategory.UpdateCategory(category);
        }
    }
}
