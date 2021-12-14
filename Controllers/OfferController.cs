using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFEBackend.Models;
using PFEBackend.Repository;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace PFEBackend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("offers")]
    public class OfferController : ControllerBase
    {
        private IRepositoryOffer _repositoryOffer;
        private ILogger<OfferController> _logger;

        public OfferController(IRepositoryOffer repository, ILogger<OfferController> logger)
        {
            _repositoryOffer = repository;
            _logger = logger;
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

        [HttpGet]
        [Route("count")]
        public int CountOffer()
        {
            return _repositoryOffer.CountOffer();
        }

        // Prendre un formdata en plus avec les medias
        [HttpPost, DisableRequestSizeLimit]
        public void AddOffer(Offer offer)
        {
            offer.Seller = User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            offer.SellerEMail = User.FindFirst("preferred_username")?.Value;
            _repositoryOffer.AddOffer(offer, Request.Form.Files);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("test")]
        public void AddOfferTest()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string text = reader.ReadToEnd();
                _logger.LogInformation("******************************************************************************\n" + text);
            }
        }

        // Pour un user en particulier

        [HttpGet]
        [Route("me/{id}")]
        public Offer GetMyById(int id)
        {
            return _repositoryOffer.GetMyById(id, User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value);
        }

        [HttpGet]
        [Route("me")]
        public IEnumerable<Offer> GetMy()
        {
            return _repositoryOffer.GetMy(User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value);
        }

        [HttpPut]
        public void UpdateOffer(Offer offer)
        {
            offer.Seller = User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            offer.SellerEMail = User.FindFirst("preferred_username")?.Value;
            _repositoryOffer.UpdateOffer(offer, User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value);
        }

        [HttpDelete]
        [Route("me/{id}")]
        public void DeleteMyOffer(int id)
        {
            _repositoryOffer.DeleteMyOffer(id, User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value);
        }

        // Pour un admin

        [HttpDelete]
        [Route("{id}")]
        public void DeleteOffer(int id)
        {
            _repositoryOffer.DeleteOffer(id);
        }

        // Report
        
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
