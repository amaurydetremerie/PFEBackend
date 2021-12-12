using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public class RepositoryMedia : IRepositoryMedia
    {
        private VinciMarketContext _context;
        private readonly ILogger<RepositoryMedia> _logger;

        public RepositoryMedia(VinciMarketContext context, ILogger<RepositoryMedia> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Media> GetAll()
        {
            return _context.Media.ToArray();
        }

        public Media GetById(int id)
        {
            return _context.Media.Where(m => m.Id == id).Select(m => new Media { Id = m.Id, Path = m.Path,  OfferId = m.OfferId, Offer = m.Offer}).First(); ;
        }

        public IEnumerable<Media> GetByOffer(int id)
        {
            List<Media> listMedias = new List<Media>();
            listMedias.AddRange(_context.Media.Where(m => m.OfferId == id).ToList());
            return listMedias.ToArray();
        }

        public void AddMedia(Media media)
        {
            _context.Media.Add(media);
            _context.SaveChanges();
        }

        public void UpdateMedia(Media media)
        {
            _context.Media.Update(media);
            _context.SaveChanges();
        }

        public void DeleteMedia(int id)
        {
            Media media = _context.Media.Find(id);
            _context.Media.Remove(media);
            _context.SaveChanges();
        }
    }
}
