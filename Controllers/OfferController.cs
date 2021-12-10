using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;
using Microsoft.Identity.Web;

namespace PFEBackend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("offers")]
    public class OfferController
    {
       private IRepositoryOffer _repositoryOffer;
       private HttpContext _httpContext;

        public OfferController(IRepositoryOffer repository, HttpContext httpContext)
        {
            _repositoryOffer = repository;
            _httpContext = httpContext;
        }

        [HttpGet]
        public IEnumerable<Offer> GetByPrice(Double? minPrice, Double? maxPrice)
        {
            return _repositoryOffer.GetByPrice(minPrice,maxPrice);
        }

        [HttpGet]
        [Route("{id}")]
        public Offer GetById(int id)
        {
            return _repositoryOffer.GetById(id);
        }

        [HttpGet]
        [Route("me/{id}")]
        public Offer GetMyById(int id)
        {
            return _repositoryOffer.GetMyById(id, _httpContext.User.FindFirst("name").Value);
        }

        [HttpGet]
        [Route("me")]
        public IEnumerable<Offer> GetMy()
        {
            return _repositoryOffer.GetMy(_httpContext.User.FindFirst("name").Value);
        }

        [HttpGet]
        [Route("category/{id}")]
        public IEnumerable<Offer> GetByCategory(int id)
        {
            return _repositoryOffer.GetByCategory(id);
        }

        [HttpPost]
        public void AddOffer(Offer offer)
        {
            offer.Seller = _httpContext.User.FindFirst("name").Value;
            _repositoryOffer.AddOffer(offer);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteOffer(int id)
        {
            _repositoryOffer.DeleteOffer(id);
        }

        [HttpPut]
        public void UpdateOffer(Offer offer)
        {
            _repositoryOffer.UpdateOffer(offer, _httpContext.User.FindFirst("name").Value);
        }

        /*Report*/
        
        [HttpPost]
        [Route("report/{id}")]
        public void AddReportOffer(int id)
        {
            _repositoryOffer.AddReportOffer(id);
        }

        [HttpPut]
        [Route("report/{id}")]
        public void UpdateReportOffer(int id)
        {
            _repositoryOffer.UpdateReportOffer(id);
        }

    }
}
