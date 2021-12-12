using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public interface IRepositoryOffer
    {
        IEnumerable<Offer> GetAll();

        Offer GetById(int id);

        Offer GetMyById(int id, string value);

        int CountOffer();

        IEnumerable<Offer> GetByCategory(int id);

        IEnumerable<Offer> GetByPrice(Double? minPrice, Double? maxPrice);

        void UpdateOffer(Offer offer, string value);

        void AddOffer(Offer offer);

        void DeleteOffer(int id);

        void AddReportOffer(int id);

        void UpdateReportOffer(int id);
        IEnumerable<Offer> GetMy(string value);
        void DeleteMyOffer(int id, string v);
    }
}
