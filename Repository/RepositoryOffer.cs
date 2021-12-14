using PFEBackend.Models;
using System.Net;

namespace PFEBackend.Repository
{
    public class RepositoryOffer : IRepositoryOffer
    {
        private VinciMarketContext _context;
        private ILogger<RepositoryOffer> _logger;

        public RepositoryOffer(VinciMarketContext context, ILogger<RepositoryOffer> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Pour tout le monde

        public int CountOffer()
        {
            return _context.Offers.Count();
        }

        public IEnumerable<Offer> GetAll()
        {
            return _context.Offers.Where(o => o.State ==States.Published && o.Deleted == false);
        }

        public IEnumerable<Offer> GetByCategory(int id)
        {
            Category parent = _context.Categories.Find(id) ?? throw new RepositoryException(HttpStatusCode.NotFound, "Catégorie avec l'ID " + id + "n'existe pas.");
            List<Category> listCategories = new();
            ChildsCategories(parent, ref listCategories);
            List<Offer> listOffers = new();
            foreach (Category category in listCategories.DistinctBy(c => c.Id))
            {
                listOffers.AddRange(_context.Offers.Where(o => o.CategoryId == category.Id && o.Deleted == false && o.State == States.Published));
            }
            return listOffers.DistinctBy(o => o.Id);
        }

        private void ChildsCategories(Category parent, ref List<Category> listCategories)
        {
            _context.Entry(parent).Collection(c => c.ChildCategories).Load();
            listCategories.AddRange(parent.ChildCategories ?? Enumerable.Empty<Category>());
            foreach(Category childCategory in parent.ChildCategories ?? Enumerable.Empty<Category>())
            {
                ChildsCategories(childCategory, ref listCategories);
            }
        }

        public Offer GetById(int id)
        {
            return _context.Offers.Where(o => o.Id == id && o.State == States.Published && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Annonce avec l'ID " + id + "n'existe pas.");
        }

        public IEnumerable<Offer> GetByPrice(Double? minPrice, Double? maxPrice)
        {
            if (minPrice > maxPrice)
                throw new RepositoryException(HttpStatusCode.Forbidden, "Le prix minimum ne peut pas être plus grand que le prix maximum.");
            return _context.Offers.Where(o => o.Price >= (minPrice ?? Double.MinValue) && o.Price <= (maxPrice ?? Double.MaxValue) && o.Deleted == false && o.State == States.Published);
        }

        // Pour un user en particulier

        public Offer GetMyById(int id, string seller)
        {
            return _context.Offers.Where((o) => o.Id == id && o.Seller == seller && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "L'annonce n'existe pas ou n'est pas la votre");
        }

        public void UpdateOffer(Offer offer, string seller)
        {
            Offer old = _context.Offers.Where((o) => o.Id == offer.Id && o.Seller == seller && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Offre avec l'ID " + offer.Id + "n'existe pas ou n'est pas la votre.");
            _context.Entry(old).CurrentValues.SetValues(offer);
            _context.SaveChanges();
        }

        public IEnumerable<Offer> GetMy(string seller)
        {
            return _context.Offers.Where(o => o.Seller == seller && o.Deleted == false);
        }

        public void DeleteMyOffer(int id, string seller)
        {
            Offer offer = _context.Offers.Where((o) => o.Id == id && o.Seller == seller && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "L'annonce n'existe pas ou n'est pas la votre");
            offer.Deleted = true;
            _context.SaveChanges();
        }

        // Pour un admin

        public void DeleteOffer(int id)
        {
            Offer offer = _context.Offers.Where(o => o.Id == id && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Annonce avec l'ID " + id + "n'existe pas.");
            offer.Deleted = true;
            _context.SaveChanges();
        }

        // Report
        public void AddReportOffer(int id)
        {
            Offer offerReported = _context.Offers.Where(o => o.Id == id && o.Deleted == false && o.State == States.Published).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Annonce avec l'ID " + id + "n'existe pas.");
            offerReported.CountReport += 1;
            _context.SaveChanges();
        }

        public void UpdateReportOffer(int id)
        {
            Offer offerReported = _context.Offers.Where(o => o.Id == id && o.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Annonce avec l'ID " + id + "n'existe pas.");
            offerReported.CountReport = 0;
            _context.SaveChanges();
        }

        public void AddOffer(Offer offer, IFormFileCollection files)
        {
            if (_context.Offers.Contains(offer))
                throw new RepositoryException(HttpStatusCode.Forbidden, "Cette annonce existe déjà.");
            offer = _context.Add(offer).Entity ;

            if (files.Any(f => f.Length == 0))
            {
                throw new RepositoryException(HttpStatusCode.Forbidden, "Un fichier est vide.");
            }

            foreach (IFormFile? file in files)
            {
                string? fullPath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles"), file.FileName);

                Media media = new();

                media.Path = Path.Combine("StaticFiles", file.FileName);
                media.Offer = offer;

                _context.Media.Add(media);

                using (FileStream? stream = new(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            _context.SaveChanges();
        }
    }
}
