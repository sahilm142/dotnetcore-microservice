using System.Collections.Generic;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}
