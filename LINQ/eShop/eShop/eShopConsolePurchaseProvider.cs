using Business.Services;
using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{

    //Crear la clase parcial para las ordenes de compra
    //registrar una orden de compra donde se pida un proveedor y el listado de producto con su stock a comprar
    public partial class eShopConsole
    {

        private void MenuDeOrdenesDeCompra()
        {
            Console.WriteLine("Que opción deseas hacer?");
            Console.WriteLine("1. Añadir stock a un producto");
            Console.WriteLine("2. Ver las ordenes de compra");
            Console.WriteLine("3. Cambiar estatus");
            Console.WriteLine("4. Ordenes de compra Query");
            string decision = Console.ReadLine();
            switch (decision)
            {
                case "1":
                    AddStock();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Las compras que se hicieron: ");
                    ShowOrders();
                    break;
                case "3":
                    CambiarEstatusOrdenCompra();
                    break;
                case "4":
                    OrdenesQueryMenu();
                    break;
            }
        }

        private void ShowOrders()
        {
            var x = _purchaseOrderService.GetPurchaseOrders();
            foreach (var p in x)
            {
                foreach (var prod in p.PurchasedProducts)
                {
                    Console.WriteLine($" Producto: {prod.Name} Cantidad: {prod.Stock}");
                }
                Console.WriteLine($"Id: {p.Id} Proveedor: {p.Provider.Name} PrecioTotal: {p.Total} En el dia: {p.PurchaseDate} status:{p.Status.ToString().ToUpper()}");
            }
            Console.ReadLine();
        }
        private void AddStock()
        {
            var providers = TestData.GetProviders();
            bool otro = true;
            do
            {

                Console.WriteLine("A que proveedor le quieres comprar?");
                foreach (var prov in providers)
                {
                    Console.WriteLine($"{prov.Id}. {prov.Name}");
                }
                string id = Console.ReadLine();
                int idInt = ConvertToInt(id);

                var proveedor = providers.FirstOrDefault(prov => prov.Id == idInt);
                if (proveedor != null)
                {
                    Console.WriteLine($"Elegiste a {proveedor.Name}");
                    Console.WriteLine("\nEstos son los productos disponibles:");
                    ConsultarProductos();

                    Console.WriteLine("\nQue producto deseas comprar mas:");
                    var prodId = Console.ReadLine();
                    int prodIdint = ConvertToInt(prodId);

                    var producto = _productService.GetProduct(prodIdint);
                    Console.WriteLine($"\n{producto.Name} tiene {producto.Stock} unidades.");

                    Console.WriteLine("Cuanto stock quieres agregar?");
                    var stock = Console.ReadLine();
                    int stockInt = ConvertToInt(stock);

                    Product product2 = new Product(producto.Name, producto.Price, producto.Description, producto.Brand, producto.Id, producto.Sku, stockInt);
                    List<Product> purchased = new List<Product>();
                    purchased.Add(product2);

                    var purchasedProduct = new PurchaseOrder(proveedor, purchased, DateTime.Now);
                    _purchaseOrderService.AddPurchaseOrder(purchasedProduct);
                    Console.WriteLine("Se ha añadido el stock");
                    //ConsultarProductos();
                    Console.WriteLine("Quiere añadir otra orden?");
                    if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Console.WriteLine();
                        otro = false;
                        ShowOrders();
                    }
                    Console.WriteLine();
       
                }
                else
                {
                    Console.WriteLine("Ese proveedor no existe.");
                }
            } while (otro);
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("Ordenes actuales:");
            ShowOrders();
            Console.WriteLine("¿A qué orden quieres cambiarle el estatus?");
            var poId = Console.ReadLine();
            int poIdInt = ConvertToInt(poId);
            Console.WriteLine("\n¿A qué estatus quieres cambiarlo?");
            int iter = 0;
            foreach(var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                
                Console.WriteLine($"{iter}. {status}");
                iter++;
            }
            Console.WriteLine("Escribe el status:");
            var statusAux = Console.ReadLine();
            var didParse = Enum.TryParse(statusAux, out PurchaseOrderStatus newStatus);
            if (didParse)
            {
                var po = _purchaseOrderService.ChangeStatus(poIdInt, newStatus);
                if (po.Status == PurchaseOrderStatus.Paid)
                {
                    foreach(var orden in po.PurchasedProducts)
                    {
                        var producto = _productService.GetProducts().Find(c => c.Id == orden.Id);
                        var productUpdate = new Product(producto.Name, producto.Price, producto.Description, producto.Brand, producto.Id, producto.Sku, producto.Stock + orden.Stock);
                        _productService.UpdateProduct(productUpdate);
                        ShowOrders();
                        _productService.GetProducts();

                    }
                }

                if (newStatus == PurchaseOrderStatus.Paid)
                {

                }
                Console.WriteLine("Orden de compra actualizada correctamente");
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe.");
            }

        }

        private void OrdenesQueryMenu()
        {
            Console.WriteLine("Ingrese que desea obtener:");
            Console.WriteLine("1. Compras pagados en los ultimos 7 dias");
            Console.WriteLine("2. Compras que abastecieron un producto");
            Console.WriteLine("3. Compras pendientes de un proveedor");
            Console.WriteLine("4. Producto con unidades mas compradas");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Ultimos7Dias();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("¿Que producto desea encontrar?");
                    string inputx = Console.ReadLine();
                    AbastecerProducto(inputx);
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Escriba el proveedor:");
                    string prov = Console.ReadLine();
                    PendientePagarLevis(prov);
                    Console.ReadLine();
                    break;
                case "4":
                    UnidadesMasCompradas();
                    Console.ReadLine();
                    break;
            }
        }
        private void Ultimos7Dias()
        {
            var listaorden = _purchaseOrderService.GetPurchaseOrders();
            foreach(var orden in listaorden)
            {
                if (orden.PurchaseDate >= DateTime.Now.AddDays(-7) && orden.Status == PurchaseOrderStatus.Paid)
                {
                    Console.WriteLine($"Esta orden es reciente {orden.Id}");
                    foreach(var prod in orden.PurchasedProducts)
                    {
                        Console.WriteLine($"{prod.Name} {prod.Stock}");
                    }
                }
            }
        }

        private void AbastecerProducto(string productoAbastecido)
        {
            var listaorden = _purchaseOrderService.GetPurchaseOrders();
            foreach(var orden in listaorden)
            {
                foreach(var prod in orden.PurchasedProducts)
                {
                    if (prod.Name == productoAbastecido)
                    {
                        Console.WriteLine($"Id:{orden.Id} Fecha:{orden.PurchaseDate} Proveedor:{orden.Provider.Name}");
                    }
                }
            }
        }

        private void PendientePagarLevis(string name)
        {
            var listaorden = _purchaseOrderService.GetPurchaseOrders();
            foreach(var orden in listaorden)
            {
                if (orden.Provider.Name == name && orden.Status == PurchaseOrderStatus.Pending)
                {
                    Console.WriteLine($"A {name} tiene estas ordenes pendientes:");
                    Console.WriteLine($"{orden.Id}");
                    foreach(var prod in orden.PurchasedProducts)
                    {
                        Console.WriteLine($"Producto:{prod.Name} Unidades:{prod.Stock}");
                    }
                }
            }

        }

        private void UnidadesMasCompradas()
        {
            var data = _reportService.GetUnidadesMasCompradas(_purchaseOrderService.GetPurchaseOrders());
            Console.WriteLine($"El producto mas solicitado es: {data.Name}");
        }


    }
}
