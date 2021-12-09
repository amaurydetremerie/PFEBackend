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
        public IEnumerable<Category> GetAll()
        {
            return _repositoryCategory.GetAll();
        }

        [HttpGet]
        [Route("/{id}")]
        public Category GetById(int id)
        {
            return _repositoryCategory.GetById(id);
        }

        [HttpGet]
        [Route("/parent/{id}")]
        public IEnumerable<Category> GetByParent(int id)
        {
            return _repositoryCategory.GetByParent(id);
        }

        [HttpPost]
        public void AddCategory([FromBody] Category category)
        {
            _repositoryCategory.AddCategory(category);
        }

        [HttpDelete]
        [Route("/{id}")]
        public void DeleteCategory(int id_category)
        {
            _repositoryCategory.DeleteCategory(id_category);
        }

        [HttpPut]
        [Route("/{id}")]
        public void UpdateCategory([FromBody] Category category)
        {
            _repositoryCategory.UpdateCategory(category);
        }
    }
}
