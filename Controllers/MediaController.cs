using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;

namespace PFEBackend.Controllers
{
    [ApiController]
    [Route("medias")]
    [AllowAnonymous]
    public class MediaController : ControllerBase
    {
        private IRepositoryMedia _repositoryMedia;

        public MediaController(IRepositoryMedia repository)
        {
            _repositoryMedia = repository;
        }

        [HttpGet]
        public IEnumerable<Media> GetAll()
        {
            return _repositoryMedia.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Media GetById(int id)
        {
            return _repositoryMedia.GetById(id);
        }

        [HttpGet]
        [Route("offer/me/{id}")]
        public IEnumerable<Media> GetMyByOffer(int id)
        {
            return _repositoryMedia.GetMyByOffer(id, User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value);
        }

        [HttpGet]
        [Route("offer/{id}")]
        public IEnumerable<Media> GetByOffer(int id)
        {
            return _repositoryMedia.GetByOffer(id);
        }

        [HttpPost]
        public void AddMedia(Media media)
        {
            _repositoryMedia.AddMedia(media);
        }

        [HttpPut]
        public void UpdateMedia(Media media)
        {
            _repositoryMedia.UpdateMedia(media);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteMedia(int id)
        {
            _repositoryMedia.DeleteMedia(id);
        }
    }
}
