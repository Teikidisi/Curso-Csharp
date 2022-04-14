using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface ICarritoService
    {
        public void AddPurchaseCarrito(Carrito carrito);
        public void RemovePurchaseCarrito(int id);
        public List<Carrito> GetCarrito();
        public void EmptyCarrito();
    }
}
