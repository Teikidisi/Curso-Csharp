using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IReportService
    {
        public List<ProductReportDTO> GetTop5ProductosMasCaros();
        public List<ProductReportDTOStock> GetProductosConPocasUnidades();
        public List<ProductReportDTOBrand> GetMarcasyProductos();
        public List<ProductReportDTODepa> GetDepartamentosSubsProductos();
        //public List<PurchaseOrder7Days> GetUltimos7Dias();
        //public List<PurchaseOrderAbastecidoDTO> GetAbastecerProducto();
        //public List<PurchaseOrderPendienteDTO> GetPendientePagarLevis();
        public Product GetUnidadesMasCompradas(List<PurchaseOrder> purchaseOrders);
    }
}
