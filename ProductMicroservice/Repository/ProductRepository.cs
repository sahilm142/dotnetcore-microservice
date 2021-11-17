using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMicroservice.Models;
using ProductMicroservice.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();

        }
        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
