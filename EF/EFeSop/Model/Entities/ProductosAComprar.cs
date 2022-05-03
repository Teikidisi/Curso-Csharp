using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ProductosAComprar
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int PurchaseOrdrID { get; set; }
        public int Cantidad { get; set; }
        public virtual PurchaseOrdr PurchaseOrdr { get; set; }
        public virtual Product Product { get; set; }

        public ProductosAComprar() { }

    }
}
