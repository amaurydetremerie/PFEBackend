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

        [HttpPost]
        [HttpDelete]
        [HttpPut]
    }
}
