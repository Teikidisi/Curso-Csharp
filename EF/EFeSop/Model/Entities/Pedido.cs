using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        //public List<Carrito> ProductosComprados { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<ProductosAComprar> ProductosAComprars { get; set; }

        public Pedido() { }
    }
}
