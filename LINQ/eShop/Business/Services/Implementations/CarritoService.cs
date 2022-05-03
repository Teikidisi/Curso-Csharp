using Business.Services.Abstractions;
using Data.DataApp;
using Data.Entities;

namespace Business.Services.Implementations
{
    public class CarritoService :ICarritoService
    {
        List<Carrito> _carritoList = new List<Carrito>();

        private readonly AppDbContext _context;
        public CarritoService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPurchaseCarrito(Carrito productCarrito)
        {
            _carritoList.Add(productCarrito);
        }

        public List<Carrito> GetCarrito()
        {
            return _carritoList;
        }

        public void RemovePurchaseCarrito(int id)
        {
            Carrito carrito = _carritoList.FirstOrDefault(product => product.Id == id);
            if (carrito != null)
                _carritoList.Remove(carrito);
            else
                throw new ArgumentNullException("Ese id no corresponde con algun producto.");
        }

        public void EmptyCarrito()
        {
            _carritoList.Clear();
        }

    }
}
