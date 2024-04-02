using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        public static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = new Guid("037c4e72-e72f-40ee-af7c-06a7734c41d7"),
                Name = "IPhone X",
                Description = "This phone is the best",
                ImageFile = "product.png",
                Price = 950.00M,
                Category = new List<string> {"Smart Phone"}
            },
             new Product()
            {
                Id = new Guid("41b502c1-948a-48ae-921c-5231f9f55c4a"),
                Name = "Samsung",
                Description = "This phone is the best",
                ImageFile = "product2.png",
                Price = 950.00M,
                Category = new List<string> {"Smart Phone"}
            }

        };
    }
}
