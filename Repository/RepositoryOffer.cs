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
            _context.Offers.Remove(offer);
        }

        public IEnumerable<Offer> GetAll()
        {
            return _context.Offers.ToArray();
        }

        public IEnumerable<Offer> GetByCategory(int id_category)
        {
            List<Category> listCategories = new List<Category>();
            listCategories.Add(_context.Categories.Find(id_category));
            listCategories.AddRange(listCategories.First().ChildCategories);
            List<Offer> listOffers = new List<Offer>();
            foreach (Category category in listCategories)
            {
                listOffers.AddRange(_context.Offers.Where(o => o.CategoryId == category.Id).ToList());
            }
            return listOffers.DistinctBy(o => o.Id).ToArray();
        }

        public Offer GetById(int id)
        {
            return _context.Offers.Find(id);
        }

        public IEnumerable<Offer> GetByPrice(double minPrice, double maxPrice)
        {
            IEnumerable<Offer> listOffre;
            if (minPrice != -1.0 && maxPrice != -1.0)
            {
                listOffre = _context.Offers.Where(o => o.Price >= minPrice && o.Price <= maxPrice).ToArray();
            }
            else if (minPrice == -1.0 && maxPrice != -1.0)
            {
                listOffre = _context.Offers.Where(o => o.Price <= maxPrice).ToArray();
            }
            else if (minPrice != -1.0 && maxPrice == -1.0)
            {
                listOffre = _context.Offers.Where(o => o.Price >= minPrice).ToArray();
            }
            else
            {
                listOffre = GetAll();
            }
            return listOffre;
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges();

        }

        public void AddReportOffer(int id)
        {
            Offer offerReported = _context.Offers.Find(id);
            offerReported.count_report =+ 1;
        }

        public void UpdateReportOffer(Offer offer)
        {
            _context.Offers.Update(offer);
        }
    }
}
