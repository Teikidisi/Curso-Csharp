using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProductService : IProductService
    {

        private List<Product> ProductList = TestData.ProductList;
        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

        public void DeleteProduct(int id)
        {
            Product productFound = ProductList.FirstOrDefault(product => product.Id == id);
            if (productFound != null)
                ProductList.Remove(productFound);
            else
                throw new ArgumentNullException("Ese id no corresponde con algun producto.");
        }

        public Product GetProduct(int id)
        {
            return ProductList.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetProducts()
        {
            return ProductList;
        }

        public void UpdateProduct(Product product)
        {
            int productFound = ProductList.FindIndex(existente => existente.Id == product.Id);
            if (productFound != -1)
                ProductList[productFound] = product;
            else
            {
                throw new ApplicationException("El producto no fue encontrado.");
            }
        }

        
    }
}
