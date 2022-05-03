using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PurchaseOrder
    {
        public decimal Total { get;  set; }
        public DateTime PurchaseDate { get;  set; } = DateTime.Now; //declarar un valor default
        public int ProviderID { get; set; }
        public virtual Provider Provider { get;  set; }
        public virtual List<Product> PurchasedProducts { get; set; }
        public PurchaseOrderStatus Status { get;  set; }
        public virtual ICollection<ProductosAComprar> ProductosAComprars { get; set; }
        public int Id { get;private set; }

        private static int consecutiveNumber = 1;

        public PurchaseOrder() { }
        public PurchaseOrder( Provider provider, List<Product> purchasedProducts, DateTime? purchaseDate = null)
        {
            
            if (provider == null)
                throw new ArgumentNullException("El proveedor no puede estar vacío.");
            if (purchasedProducts == null || !purchasedProducts.Any())
                throw new ArgumentNullException("Hay que agregar productos a la orden");

            Total = purchasedProducts.Sum(c => c.Price * c.Stock);
            PurchaseDate = purchaseDate ?? DateTime.Now;
            PurchasedProducts = purchasedProducts;
            Provider = provider;
            Id = consecutiveNumber++;
            Status = PurchaseOrderStatus.Pending;
        }


        public void ChangeStatus(PurchaseOrderStatus status)
        {
            Status = status;
        }

        //public override string ToString()
        //{
        //    var orderString = new StringBuilder();
        //    orderString.Append($"");
        //}
    }
}
