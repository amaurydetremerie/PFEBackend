using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public interface IRepositoryOffer
    {
        IEnumerable<Offer> GetAll();

        Offer GetById(int id);

        IEnumerable<Offer> GetByCategory(int id_category);

        IEnumerable<Offer> GetByPrice(double minPrice, double maxPrice);

        void UpdateOffer(Offer offer);

        void AddOffer(Offer offer);

        void DeleteOffer(int id);

        void AddReportOffer(int id_offer);

        void UpdateReportOffer(Offer offer);
    }
}
