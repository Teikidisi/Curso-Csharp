using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void DeleteProduct(int id);
        public void UpdateProduct(Product product);


    }
}
