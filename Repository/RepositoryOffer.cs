using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public class RepositoryOffer : IRepositoryOffer
    {
        private VinciMarketContext _context;

        public RepositoryOffer(VinciMarketContext context)
        {
            _context = context;
        }

        public void AddOffer(Offer offer)
        {
            _context.Add(offer);
            _context.SaveChanges();
        }

        public void DeleteOffer(int id)
        {
            Offer offer = _context.Offers.Find(id);
            offer.Deleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Offer> GetAll()
        {
            return _context.Offers.ToArray();
        }

        public IEnumerable<Offer> GetByCategory(int id)
        {
            List<Category> listCategories = new List<Category>();
            listCategories.Add(_context.Categories.Find(id));
            listCategories.AddRange(listCategories.First().ChildCategories);
            List<Offer> listOffers = new List<Offer>();
            foreach (Category category in listCategories)
            {
                listOffers.AddRange(_context.Offers.Where(o => o.CategoryId == category.Id).ToList());
            }
            return listOffers.DistinctBy(o => o.Id).ToArray();
        }

        // TODO Exception si deleted ou states != Published
        public Offer GetById(int id)
        {
            return _context.Offers.Find(id);
        }

        public IEnumerable<Offer> GetByPrice(Double? minPrice, Double? maxPrice)
        {
            return _context.Offers.Where(o => o.Price >= (minPrice ?? Double.MinValue) && o.Price <= (maxPrice ?? Double.MaxValue) && o.Deleted == false && o.State == States.Published);
        }

        public void AddReportOffer(int id)
        {
            Offer offerReported = _context.Offers.Find(id);
            offerReported.CountReport += 1;
            _context.SaveChanges();
        }

        public void UpdateReportOffer(int id)
        {
            Offer offerReported = _context.Offers.Find(id);
            offerReported.CountReport = 0;
            _context.SaveChanges();
        }

        public Offer GetMyById(int id, string value)
        {
            throw new NotImplementedException();
        }

        public void UpdateOffer(Offer offer, string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetMy(string value)
        {
            throw new NotImplementedException();
        }
    }
}
