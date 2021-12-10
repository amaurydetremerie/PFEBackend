using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;
using Microsoft.Identity.Web;

namespace PFEBackend.Controllers
{
    //_httpContext.User.FindFirst("name").Value

    [ApiController]
    [AllowAnonymous]
    [Route("offers")]
    public class OfferController
    {
       private IRepositoryOffer _repositoryOffer;

        public OfferController(IRepositoryOffer repository)
        {
            _repositoryOffer = repository;
        }

        // Pour tout le monde

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
        [Route("category/{id}")]
        public IEnumerable<Offer> GetByCategory(int id)
        {
            return _repositoryOffer.GetByCategory(id);
        }

        [HttpPost]
        public void AddOffer(Offer offer)
        {
            offer.Seller = "";
            _repositoryOffer.AddOffer(offer);
        }


        // Pour un user en particulier

        [HttpGet]
        [Route("me/{id}")]
        public Offer GetMyById(int id)
        {
            return _repositoryOffer.GetMyById(id, "");
        }

        [HttpGet]
        [Route("me")]
        public IEnumerable<Offer> GetMy()
        {
            return _repositoryOffer.GetMy("");
        }

        [HttpPut]
        public void UpdateOffer(Offer offer)
        {
            _repositoryOffer.UpdateOffer(offer, "");
        }

        [HttpDelete]
        [Route("me/{id}")]
        public void DeleteMyOffer(int id)
        {
            _repositoryOffer.DeleteMyOffer(id, "");
        }

        // Pour un admin

        [HttpDelete]
        [Route("{id}")]
        public void DeleteOffer(int id)
        {
            _repositoryOffer.DeleteOffer(id);
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
