using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;

namespace PFEBackend.Controllers
{
    [ApiController]
    [Route("offers")]
    public class OfferController
    {
        private IRepositoryOffer _repositoryOffer;

        public OfferController(IRepositoryOffer repository)
        {
            _repositoryOffer = repository;
        }

        [HttpGet]
        public IEnumerable<Offer> GetAll([FromQuery] double minPrice = -1.0, [FromQuery] double maxPrice = -1.0)
        {
            return _repositoryOffer.GetByPrice(minPrice,maxPrice);
        }

        [HttpGet]
        [Route("/{id}")]
        public Offer GetById(int id)
        {
            return _repositoryOffer.GetById(id);
        }

        [HttpGet]
        [Route("/{id_category}")]
        public IEnumerable<Offer> GetByCategory(int id_category)
        {
            return _repositoryOffer.GetByCategory(id_category);
        }

        [HttpPost]
        public void AddOffer([FromBody]Offer offer)
        {
            _repositoryOffer.AddOffer(offer);
        }

        [HttpDelete]
        [Route("/{id}")]
        public void DeleteOffer(int id_offer)
        {
            _repositoryOffer.DeleteOffer(id_offer);
        }

        [HttpPut]
        public void UpdateOffer([FromBody] Offer offer)
        {
            _repositoryOffer.UpdateOffer(offer);
        }

        /*Report*/

        [HttpPost]
        [Route("/report/{id}")]
        public void AddReportOffer(int id_offer)
        {
            _repositoryOffer.AddReportOffer(id_offer);
        }

        [HttpPut]
        [Route("/report")]
        public void UpdateReportOffer([FromBody] Offer offer)
        {
            _repositoryOffer.UpdateReportOffer(offer);
        }

    }
}
