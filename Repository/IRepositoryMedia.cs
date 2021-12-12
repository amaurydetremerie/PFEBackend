using PFEBackend.Models;

namespace PFEBackend.Repository
{
    public interface IRepositoryMedia
    {
        IEnumerable<Media> GetAll();

        Media GetById(int id);

        IEnumerable<Media> GetByOffer(int id);

        void AddMedia(Media media);

        void UpdateMedia(Media media);

        void DeleteMedia(int id);
    }
}
