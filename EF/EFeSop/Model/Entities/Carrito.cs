using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Carrito
    {
        public int Id { get; set; }
        //public Product productosAComprar { get; set; }
        public int Cantidad { get; set; }
        private static int IdSeed = 1;
        public decimal Precio { get; set; }
        public int PedidoID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Pedido Pedido { get; set; }

        public Carrito() { }
    }
}
