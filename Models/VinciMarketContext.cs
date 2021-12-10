using Microsoft.EntityFrameworkCore;

namespace PFEBackend.Models
{
    public class VinciMarketContext : DbContext
    {
        public VinciMarketContext(DbContextOptions<VinciMarketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOne(x => x.Parent).WithMany(x => x.ChildCategories).HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Maison et Jardin"},
                new Category { Id = 2, Name = "Outils", ParentId = 1},
                new Category { Id = 3, Name = "Meubles", ParentId = 1},
                new Category { Id = 4, Name = "Pour la maison", ParentId = 1},
                new Category { Id = 5, Name = "Jardin", ParentId = 1},
                new Category { Id = 6, Name = "Electroménager", ParentId = 1},
                
                new Category { Id = 7, Name = "Famille"},
                new Category { Id = 8, Name = "Santé et beauté", ParentId = 7},
                new Category { Id = 9, Name = "Fournitures pour animaux", ParentId = 7},
                new Category { Id = 10, Name = "Puériculture et enfants", ParentId = 7},
                new Category { Id = 11, Name = "Jouets et jeux", ParentId = 7},
                
                new Category { Id = 12, Name = "Vêtements et accessoires"},
                new Category { Id = 13, Name = "Sacs et bagages", ParentId = 12},
                new Category { Id = 14, Name = "Vêtements et chaussures femmes", ParentId = 12},
                new Category { Id = 15, Name = "Vêtements et chaussures hommes", ParentId = 12},
                new Category { Id = 16, Name = "Bijoux et accessoires", ParentId = 12},
                
                new Category { Id = 17, Name = "Loisirs - hobbys"},
                new Category { Id = 18, Name = "Vélos", ParentId = 17},
                new Category { Id = 19, Name = "Loisirs créatifs", ParentId = 17},
                new Category { Id = 20, Name = "Pièces auto", ParentId = 17},
                new Category { Id = 21, Name = "Sports et activités d’extérieures", ParentId = 17},
                new Category { Id = 22, Name = "Jeux vidéo", ParentId = 17},
                new Category { Id = 23, Name = "Livres, films et musique", ParentId = 17},
                new Category { Id = 24, Name = "Instruments de musique", ParentId = 17},
                new Category { Id = 25, Name = "Antiquité et objets de collection", ParentId = 17},
                
                new Category { Id = 26, Name = "Electronique"},
                new Category { Id = 27, Name = "Electronique et ordinateurs", ParentId = 26},
                new Category { Id = 28, Name = "Téléphones mobiles", ParentId = 26},

                new Category { Id = 29, Name = "Autres"}
            );

            modelBuilder.Entity<Offer>().HasData(
                //Tondeuse, catégorie Jardin, Vente, Publiée, 100.01€, Woluwe
                new Offer() { Id = 1, Title = "Tondeuse", Type = Types.Sale, CategoryId = 5, Description = "Tondeuse de luxe automatique", State = States.Published, Price = 100.01, Place = Places.Woluwe, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseDeleted, catégorie Jardin, Vente, Supprimée, 100.01€, Woluwe
                new Offer() { Id = 1, Title = "TondeuseDeleted", Type = Types.Sale, CategoryId = 5, Description = "Tondeuse de luxe automatique", State = States.Published, Price = 100.01, Place = Places.Woluwe, Deleted = true, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseIxelles, catégorie Jardin, Vente, Publiée, 99.99€, Ixelles
                new Offer() { Id = 1, Title = "TondeuseIxelles", Type = Types.Sale, CategoryId = 5, Description = "Tondeuse de luxe automatique", State = States.Published, Price = 99.99, Place = Places.Ixelles, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseCheveux, catégorie Electroménager, Vente, Publiée, 99.99€, Ixelles
                new Offer() { Id = 1, Title = "TondeuseCheveux", Type = Types.Sale, CategoryId = 6, Description = "Tondeuse de luxe automatique", State = States.Published, Price = 99.99, Place = Places.Ixelles, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseIxelles, catégorie Electroménager, Vente, Publiée, 99.99€, Louvain
                new Offer() { Id = 1, Title = "TondeuseCheveux", Type = Types.Sale, CategoryId = 6, Description = "Tondeuse de luxe automatique", State = States.Published, Price = 99.99, Place = Places.Louvain, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseVendue, catégorie Jardin, Vente, Vendue, 99.99€, Ixelles
                new Offer() { Id = 1, Title = "TondeuseVendue", Type = Types.Sale, CategoryId = 5, Description = "Tondeuse de luxe automatique", State = States.Sell, Price = 99.99, Place = Places.Ixelles, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" },
                //TondeuseInvisible, catégorie Jardin, Vente, Vendue, 99.99€, Ixelles
                new Offer() { Id = 1, Title = "TondeuseInvisible", Type = Types.Sale, CategoryId = 5, Description = "Tondeuse de luxe automatique", State = States.Invisible, Price = 99.99, Place = Places.Ixelles, Deleted = false, Seller = "vendeur@pfegrp5.onmicrosoft.com" }
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Media> Media { get; set; }
    }
}
