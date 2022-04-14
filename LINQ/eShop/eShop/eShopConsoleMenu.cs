using Business.Services.Abstractions;
using Business.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly IReportService _reportService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly ICarritoService _carritoService;

        public eShopConsole()
        {
            _productService = new ProductService();
            _departmentService = new DepartmentService();
            _reportService = new ReportService();
            _purchaseOrderService = new PurchaseOrderService();
            _carritoService = new CarritoService();
        }

            int clientid = 0;
        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Eres cliente o Admin?");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Administrador");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    bool showMenuCliente = true;
                    clientid++;
                    while (showMenuCliente)
                    {
                        showMenuCliente = MainMenuCliente(clientid);
                    }
                    break;
                case "2":
                    bool showMenuAdmin = true;
                    while (showMenuAdmin)
                    {
                        showMenuAdmin = MainMenuAdmin();

                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
