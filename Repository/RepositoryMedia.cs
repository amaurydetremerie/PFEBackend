using PFEBackend.Models;
using System.Net;

namespace PFEBackend.Repository
{
    public class RepositoryMedia : IRepositoryMedia
    {
        private VinciMarketContext _context;

        public RepositoryMedia(VinciMarketContext context)
        {
            _context = context;
        }

        public IEnumerable<Media> GetAll()
        {
            return _context.Media.ToList();
        }

        public Media GetById(int id)
        {
            return _context.Media.Where(m => m.Id == id && m.Offer.Deleted == false && m.Offer.State == States.Published).First() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Media avec l'ID " + id + "n'existe pas.");
        }

        public IEnumerable<Media> GetByOffer(int id)
        {
            Offer offer = _context.Offers.Where(o => o.Id == id && o.Deleted == false && o.State == States.Published).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "L'annonce avec l'ID " + id + "n'existe pas.");
            return _context.Media.Where(m => m.OfferId == offer.Id).ToList();
        }

        public IEnumerable<Media> GetMyByOffer(int id, string seller)
        {
            Offer offer = _context.Offers.Where(o => o.Id == id && o.Deleted == false && o.Seller == seller).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "L'annonce avec l'ID " + id + "n'existe pas ou n'est pas la votre.");
            return _context.Media.Where(m => m.OfferId == offer.Id).ToList();
        }

        public void AddMedia(Media media, string seller)
        {
            if (_context.Media.Contains(media))
                throw new RepositoryException(HttpStatusCode.Forbidden, "Ce media existe déjà.");
            if(_context.Offers.Where(o => o.Id != media.OfferId && o.Seller != seller && o.Deleted != false).FirstOrDefault() == null)
                throw new RepositoryException(HttpStatusCode.NotFound, "L'annonce avec l'ID " + media.OfferId + "n'existe pas ou n'est pas la votre.");
            _context.Media.Add(media);
            _context.SaveChanges();
        }

        public void UpdateMedia(Media media, string seller)
        {
            Media old = _context.Media.Where(m => m.Id == media.Id && m.Offer.Deleted == false && m.Offer.State != States.Sold && m.Offer.Seller == seller).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Media avec l'ID " + media.Id + "n'existe pas ou n'est pas le votre.");
            _context.Entry(old).CurrentValues.SetValues(media);
            _context.SaveChanges();
        }

        public void DeleteMyMedia(int id, string seller)
        {
            Media media = _context.Media.Where(m => m.Id == id && m.Offer.Deleted == false && m.Offer.Seller == seller).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Media avec l'ID " + id + "n'existe pas ou n'est pas le votre.");
            _context.Media.Remove(media);
            _context.SaveChanges();
        }

        public void DeleteMedia(int id)
        {
            Media media = _context.Media.Where(m => m.Id == id && m.Offer.Deleted == false).FirstOrDefault() ?? throw new RepositoryException(HttpStatusCode.NotFound, "Media avec l'ID " + id + "n'existe pas.");
            _context.Media.Remove(media);
            _context.SaveChanges();
        }
    }
}
