using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Pedido
    {
        public DateTime FechaCompra { get;private set; } = DateTime.Now;
        public decimal Total { get;private set; }
        public List<Carrito> ProductosComprados { get; private set; }

        public Pedido(List<Carrito> carritoLista, DateTime? fechacompra = null)
        {
            FechaCompra = fechacompra ?? DateTime.Now;
            Total = carritoLista.Sum(c => c.Precio);
            ProductosComprados = carritoLista;
        }
    }
}
