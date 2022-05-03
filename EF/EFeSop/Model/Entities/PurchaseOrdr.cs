using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrdr
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }
        //public List<Product> PurchasedProducts { get; set; }
        public virtual ICollection<ProductosAComprar> ProductosAComprars { get; set; }
        public PurchaseOrderStatus Status { get; set; }

        private static int consecutiveNumber = 1;

        public PurchaseOrdr() { }
    }
}
