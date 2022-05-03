using Business.Models;
using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ReportService : IReportService
    {
        private List<Product> ProductList = TestData.ProductList; 
        private List<Department> DepartmentsList = TestData.DepartmentList;
        private List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();

        public List<ProductReportDTO> GetTop5ProductosMasCaros()
        {
            return ProductList.OrderByDescending(c => c.Price).Take(5).Select(c => new ProductReportDTO
            {
                Name = c.Name,
                Price = c.Price
            }).ToList();
        }

        public List<ProductReportDTOStock> GetProductosConPocasUnidades()
        {
            return ProductList.Where(producto => producto.Stock < 5)
                        .OrderBy(producto => producto.Stock).Select(c => new ProductReportDTOStock
                        {
                            Name = c.Name,
                            Stock = c.Stock
                        }).ToList();
        }
        public List<ProductReportDTOBrand> GetMarcasyProductos()
        {
            return ProductList
                .OrderBy(producto => producto.Brand)
                .ThenBy(producto => producto.Name).Select(c => new ProductReportDTOBrand
                {
                    Brand = c.Brand,
                    Name = c.Name
                }).ToList();

        }
        public List<ProductReportDTODepa> GetDepartamentosSubsProductos()
        {
            return DepartmentsList.OrderBy(depa => depa.Name)
                .Select(c => new ProductReportDTODepa
                {
                    Depa = c.Name,
                    Subdepas = (List<Subdepartment>)c.Subdepartments
                }).ToList();
            //foreach(var depa in AgrupacionQuery)
            //{
            //    new ProductReportDTODepa
            //    {
            //        Depa = depa.Name,
            //        Subdepas = depa.Subdepartments
            //    };
            //}


        }
        //public List<PurchaseOrder7Days> GetUltimos7Dias()
        //{
        //    //return _purchaseOrders
        //    //    .Where(c => c.PurchaseDate >= DateTime.Now.AddDays(-7))
        //    //    .OrderBy(c => c.Provider)
        //    //    .Select(unit => new PurchaseOrder7Days
        //    //    {
        //    //        Provider => unit.Provider.Name,
        //    //        Order => unit.PurchasedProducts
        //    //    }).ToList();
        //}

        //public List<PurchaseOrderAbastecidoDTO> GetAbastecerProducto()
        //{

        //}

        //public List<PurchaseOrderPendienteDTO> GetPendientePagarLevis()
        //{

        //}

        public Product GetUnidadesMasCompradas(List<PurchaseOrder> purchaseOrders)
        {

            return purchaseOrders.Where(c => c.Status == Data.Enums.PurchaseOrderStatus.Paid)
                .SelectMany(c => c.PurchasedProducts)
                .GroupBy(c => c.Id)
                .Select(c => new { c.Key, Product = c.First(), Sum = c.Sum(d => d.Stock)})
                .OrderByDescending(c => c.Sum)
                .FirstOrDefault()?.Product;
        }
    }
}
