using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Carrito
    {
        public int Id { get; private set; }
        public Product productosAComprar { get; private set; }
        public int Cantidad { get; private set; }

        private static int IdSeed = 1;
        public decimal Precio { get;private set; }

        public int ClientId { get; private set; }

        public Carrito(int cantidad, Product producto, int clientid)
        {
            if (cantidad <= 0)
                throw new ApplicationException("La cantidad a comprar debe ser positiva");

            //productosAComprar.Add(producto);
            productosAComprar = producto;
            Id = IdSeed++;
            Cantidad = cantidad;
            ClientId = clientid;
            Precio = cantidad * producto.Price;
        }
    }
}
