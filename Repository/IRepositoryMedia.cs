using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public interface IRepositoryMedia
    {
        IEnumerable<Media> GetAll();

        Media GetById(int id);

        IEnumerable<Media> GetByOffer(int id);

        IEnumerable<Media> GetMyByOffer(int id, string seller);

        void AddMedia(Media media, string seller);

        void UpdateMedia(Media media, string seller);

        void DeleteMyMedia(int id, string seller);
        void DeleteMedia(int id);
    }
}
