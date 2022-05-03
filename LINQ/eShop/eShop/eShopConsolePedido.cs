using Business.Services;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool MainMenuCliente(int clientid)
        {
            int clientId = clientid;
            Console.Clear();
            Console.WriteLine($"Hola usuario de ID {clientId}, que quieres hacer?");
            Console.WriteLine("1. Modificar el carrito");
            Console.WriteLine("2. Hacer el pedido del carrito");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ModificarCarrito(clientId);
                    break;
                case "2":
                    HacerPedido();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Otra operación de cliente? (y/n)");
            if (Console.ReadKey().Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


        private void ModificarCarrito(int clientId)
        {
            Console.WriteLine("Que quieres hacer?\n1. Añadir productos al carrito\n2. Eliminar productos del carrito\n3. Ver carrito");
            string input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    AgregarProductoACarrito(clientId);
                    break;
                case "2":
                    ShowCarrito(clientId);
                    Console.WriteLine("Ingrese ID de producto a eliminar del carrito:");
                    string input3 = Console.ReadLine();
                    int inputInt = ConvertToInt(input3);
                    EliminarProductoDeCarrito(inputInt, clientId);
                    break;
                case "3":
                    ShowCarrito(clientId);
                    break;
            }
        }

        private void HacerPedido()
        {
            var carrito = _carritoService.GetCarrito();

            if (carrito.Count > 0)
            {
                Console.WriteLine("Has ordenado los productos del carrito");
                Pedido pedidoHecho = new Pedido(carrito);
                Console.WriteLine($"\nSe hizo el pedido a las {pedidoHecho.FechaCompra} y se compró:");
                foreach(var u in pedidoHecho.ProductosComprados)
                {
                    Console.WriteLine($"{u.productosAComprar.Name} Cantidad:{u.Cantidad} Precio:{u.Precio}");
                }

                Console.WriteLine($"Costando un total de ${pedidoHecho.Total}");
                foreach(Carrito compra in pedidoHecho.ProductosComprados)
                {
                    Product productoOriginal = TestData.ProductList.FirstOrDefault(u => u.Id == compra.productosAComprar.Id);
                    if (productoOriginal != null)
                    {
                        productoOriginal.Stock -= compra.Cantidad;
                        Console.WriteLine($"A {productoOriginal.Name} se le quitó {compra.Cantidad} y le quedan {productoOriginal.Stock} unidades");
                        var final = _productService.GetProduct(productoOriginal.Id);
                        Console.WriteLine(final.ToString());
                    }
                }

                Console.WriteLine("\nVaciando el carrito...");
                _carritoService.EmptyCarrito();
            }
            else
            {
                Console.WriteLine("No puedes hacer un pedido con la lista vacia.");
            }
        }
        private void AgregarProductoACarrito(int clientId)
        {
            Console.WriteLine("Estos son los productos disponibles:");
            ConsultarProductos();
            var actualCarrito = _carritoService.GetCarrito();
            
            Console.WriteLine("\nQué producto deseas añadir al carrito(Id)?");
            string input = Console.ReadLine();
            int inputInt = ConvertToInt(input);

            var productDeseado = _productService.GetProduct(inputInt);
            foreach(var a in actualCarrito)
            {
                if (a.productosAComprar.Id == productDeseado.Id)
                {
                    Console.WriteLine("Ese producto ya se metió al carrito");
                    return;
                }
            }

            Console.WriteLine(productDeseado.Name);
            Console.WriteLine("Cuanto deseas comprar?");
            string compra = Console.ReadLine();
            int compraInt = ConvertToInt(compra);
            if(compraInt > productDeseado.Stock)
            {
                throw new ArgumentOutOfRangeException("No puedes comprar más del disponible.");
            }

            List<Product> productDeseadoList = new List<Product>();
            productDeseadoList.Add(productDeseado);
            var carritoNew = new Carrito(compraInt, productDeseado, clientId);
            _carritoService.AddPurchaseCarrito(carritoNew);

            Console.WriteLine($"Se añadió {productDeseado.Name} unidades: {compraInt} a la cuenta {clientId}.");
            ShowCarrito(clientId);
            
        }
        private void EliminarProductoDeCarrito(int id, int clientId)
        {
            _carritoService.RemovePurchaseCarrito(id);
            ShowCarrito(clientId);
        }

        private void ShowCarrito(int clientId)
        {
            List<Carrito> actual = _carritoService.GetCarrito();
            Console.WriteLine($"\nOrden actual en el carrito para el usuario {clientId}: ");
            foreach (var a in actual)
            {
                Console.WriteLine($"ID:{a.Id} Producto:{a.productosAComprar.Name} Cantidad:{a.Cantidad} Precio:{a.Precio}");

            }
        }
    }
}
