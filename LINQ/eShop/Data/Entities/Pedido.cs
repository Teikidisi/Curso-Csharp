using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public virtual ICollection<Carrito> ProductosComprados { get; set; }
        public virtual ICollection<ProductosAComprar> ProductosAComprars { get; set; }

        public Pedido() { }
        public Pedido(ICollection<Carrito> carritoLista, DateTime? fechacompra = null)
        {
            FechaCompra = fechacompra ?? DateTime.Now;
            Total = carritoLista.Sum(c => c.Precio);
            ProductosComprados = carritoLista;
        }
    }
}
