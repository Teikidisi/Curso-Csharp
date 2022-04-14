using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services.Implementations;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        
        private void MenuDeReportes()
        {
            Console.WriteLine("1. Top 5 de productos más caros ordenados por precio más alto");
            Console.WriteLine("2. Productos con 5 unidades o menos ordenados por unidades");
            Console.WriteLine("3. Nombre de productos por marcas ordenados por nombre");
            Console.WriteLine("4. Agrupación de departamentos con subdepartamentos y nombres de productos");
            Console.WriteLine("5. Regresar");
            var ListaDeProductos = _productService.GetProducts();
            switch (Console.ReadLine())
            {
                case "1":
                    Top5ProductosMasCaros();
                    //var Top5Caros = ListaDeProductos.OrderByDescending(producto => producto.Price).Take(5);
                    //foreach (var top in Top5Caros)
                    //{
                    //    Console.WriteLine($"{top.Name} cuesta {top.Price}");
                    //}
                    Console.ReadLine();
                    break;
                case "2":
                    ProductosConPocasUnidades();
                    //var PocasUnidades = ListaDeProductos.Where(producto => producto.Stock < 5)
                    //    .OrderBy(producto => producto.Stock);
                    //foreach (var unit in PocasUnidades)
                    //{
                    //    Console.WriteLine($"{unit.Name} cuenta con {unit.Stock} unidades.");
                    //}
                    Console.ReadLine();
                    break;
                case "3":
                    MarcasYProductos();
                    //var MarcasQuery = ListaDeProductos.OrderBy(producto => producto.Brand).ThenBy(producto => producto.Name);
                    //foreach (var unit in MarcasQuery)
                    //{
                    //    Console.WriteLine($"La marca {unit.Brand} tiene el producto: {unit.Name}");
                    //}
                    Console.ReadLine();
                    break;
                case "4":
                    var ListaDepartamentos = _departmentService.GetDepartments();
                    var AgrupacionDepasQuery = ListaDepartamentos
                        .OrderBy(depa => depa.Name);

                    foreach (var depa in AgrupacionDepasQuery)
                    {
                        Console.WriteLine($"{depa.Name}");
                        var subdepas = _departmentService.GetSubdepartments(depa.Name);
                        //foreach(var subdepa in subdepas)
                        //{
                        //    Console.WriteLine($"{subdepa.Name}");
                        //    foreach(var prod in subdepa.Products)
                        //    {
                        //        Console.WriteLine(prod.ToString());
                        //    }
                        //}
                        for (int i = 0; i < depa.Subdepartments.Count; i++)
                        {
                            Console.WriteLine($"{depa.Subdepartments[i]}");
                            foreach (var prod in depa.Subdepartments[i].Products)
                            {
                                Console.WriteLine(prod.Name);
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
            }

        }

        //crear funciones individuales de cada reporte
        private void Top5ProductosMasCaros()
        {
            var data = _reportService.GetTop5ProductosMasCaros();

            foreach(var dto in data)
            {
                Console.WriteLine($"{dto.Name} {dto.Price}");
            }
        }

        private void ProductosConPocasUnidades()
        {
            var data = _reportService.GetProductosConPocasUnidades();
            foreach(var dto in data)
            {
                Console.WriteLine($"{dto.Name} {dto.Stock}");
            }
        }

        private void MarcasYProductos()
        {
            var data = _reportService.GetMarcasyProductos();
            foreach (var dto in data)
            {
                Console.WriteLine($"{dto.Brand} {dto.Name}");
            }
        }

        private void DepartamentosSubsProductos()
        {
            var data = _reportService.GetDepartamentosSubsProductos();
        }

    }
}
