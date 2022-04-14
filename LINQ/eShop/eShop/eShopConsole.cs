using Business.Services.Abstractions;
using Business.Services.Implementations;
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
        

        public  bool MainMenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("Elige una opción: ");
            Console.WriteLine("1. Agregar Producto\n2. Editar Producto\n3. Consultar Productos\n4. Consultar Producto\n5. Eliminar Producto\n6. Reportes\n7. Ordenes de compra\n8. Salir del sistema");

            switch (Console.ReadLine())
            {
                case "1":
                    AgregarProducto();
                    Console.ReadLine();
                    break;
                case "2":
                    EditarProducto();
                    Console.ReadLine();
                    break;
                case "3":
                    ConsultarProductos();
                    Console.ReadLine();
                    break;
                case "4":
                    ConsultarUnProducto();
                    Console.ReadLine();
                    break;
                case "5":
                    EliminarProducto();
                    
                    break;
                case "6":
                    MenuDeReportes();
                    Console.ReadLine();
                    break;
                case "7":
                    MenuDeOrdenesDeCompra();
                    break;

                default:
                    Console.WriteLine("Saliendo");
                    return false;
                    break;
            }
            return true;
        }

        

        private  void EliminarProducto()
        {
            Console.WriteLine("Ingrese el id del producto que quiere eliminar:");
            string id = Console.ReadLine();
            try
            {
                if (Int32.TryParse(id, out int idInt))
                {
                    _productService.DeleteProduct(idInt);
                }
                else
                {
                    throw new ApplicationException("El id está mal ingresado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private  void ConsultarUnProducto()
        {
            Console.WriteLine("Ingrese el id del cual desea más información:");
            string id = Console.ReadLine();
            try
            {
                if (Int32.TryParse(id, out int idInt))
                {
                    var u = _productService.GetProduct(idInt);
                    Console.WriteLine($"ID: {u.Id} Nombre: {u.Name} Descripcion: {u.Description} Marca: {u.Brand} Precio: {u.Price} SKU: {u.Sku} Cantidad: {u.Stock}");
                    
                }
                else
                {
                    throw new ApplicationException("El id está mal ingresado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private  void ConsultarProductos()
        {
            try
            {
                var x = _productService.GetProducts();
                Console.WriteLine($"ID\tProduct:\tBrand:\t\tSKU:\tStock:\tDescription:\t\tPrice:\tSubepartment\tDepartment");
                foreach (var u in x)
                {
                    //Console.WriteLine(u.ToString());
                    Console.WriteLine($"{u.Id}\t{u.Name}\t\t{u.Brand}\t{u.Sku}\t{u.Stock}\t{u.Description}\t{u.Price}\t{u.Subdepartment?.Name}\t{u.Subdepartment?.Department?.Name}");
                }
                    

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private  void EditarProducto()
        {
            Console.WriteLine("Agrega los valores necesarios para editar el producto");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();
            Console.WriteLine("Nombre:");
            var name = Console.ReadLine();
            Console.WriteLine("Precio:");
            var price = Console.ReadLine();
            Console.WriteLine("Descripción del producto:");
            var description = Console.ReadLine();
            Console.WriteLine("Marca:");
            var brand = Console.ReadLine();
            Console.WriteLine("SKU:");
            var sku = Console.ReadLine();
            try
            {
                if (Int32.TryParse(id, out int idInt) && decimal.TryParse(price, out decimal priceInt))
                {
                    var product = new Product(name, priceInt, description, brand, idInt, sku);
                    _productService.UpdateProduct(product);
                    Console.WriteLine("Producto editado correctamente");
                }
                else
                {
                    throw new ApplicationException("El Precio o el ID no se pudieron castear a número.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private  void AgregarProducto()
        {
            Console.WriteLine("Agrega los valores necesarios para registrar un producto");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();
            Console.WriteLine("Nombre:");
            var name = Console.ReadLine();
            Console.WriteLine("Precio:");
            var price = Console.ReadLine();
            Console.WriteLine("Descripción del producto:");
            var description = Console.ReadLine();
            Console.WriteLine("Marca:");
            var brand = Console.ReadLine();
            Console.WriteLine("SKU:");
            var sku = Console.ReadLine();
            Console.WriteLine();

            var SubDepaElegido = ElegirSubdepartment();

            try
            {
                if (Int32.TryParse(id, out int idInt) && decimal.TryParse(price, out decimal priceInt))
                {
                    var product = new Product(name, priceInt, description, brand, idInt, sku);
                    product.AddSubdepartment(SubDepaElegido); //añadir el producto al subdepartamento elegido
                                                              //ya estamos creando jerarquias en el sistema
                    _productService.AddProduct(product);

                    Console.WriteLine("Producto agregado correctamente");
                }
                else
                {
                    throw new ApplicationException("El Precio o el ID no se pudieron castear a número.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private  Subdepartment ElegirSubdepartment()
        {
            var depas = _departmentService.GetDepartments();
            var iter = 1;
            foreach (var d in depas)
            {
                Console.WriteLine(iter + " " + d.ToString());
                iter++;
            }
            Console.WriteLine("\nElige el departamento:");
            string depa = Console.ReadLine();
            if (Int32.TryParse(depa, out int depaInt))
            {
                depaInt -= 1;
                if (depaInt >= iter)
                {
                    Console.WriteLine("Ese departamento no existe");
                    throw new ArgumentOutOfRangeException("Ese Departamento no existe");
                }
                else
                {
                    Console.WriteLine("Elegiste el departamento de " + depas[depaInt].Name);

                }
            }
            //mostrar subdepartamentos
            Console.WriteLine("\nAhora elige el subdepartamento:");
            int iter2 = 1;
            foreach (var sub in depas[depaInt].Subdepartments)
            {
                Console.WriteLine(iter2 + ". " + sub.Name);
                iter2++;
            }
            Console.WriteLine("Elige el subdepartamento:");
            string subdepa = Console.ReadLine();
            if (Int32.TryParse(subdepa, out int subdepaInt))
            {
                subdepaInt -= 1;
                Subdepartment subdepaElegido = depas[depaInt].Subdepartments[subdepaInt];
                Console.WriteLine("Se agregará el producto al Subdepartamento de {0}", subdepaElegido.Name);
                return subdepaElegido;
            }
            return null;
        }
        public int ConvertToInt(string id)
        {
            try
            {
                return Int32.Parse(id);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede convertir a numero");
            }
        }
    }

}
