using Model.Entities;
using Model.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDbContextSeed
    {
        public static Task SeedASync(AppDbContext context)
        {
            if (!context.Products.Any())
            {
            var seedProducts = new List<Product>
                {
                    new Product() { Name = "Jabon Vainilla", Brand = "Dove", Price = 10, Description = "Jabon de vainilla", SKU = "jv10", Stock = 400, SubdepartmentID = 6},
                    new Product() { Name = "Shampoo Sandia Kids", Brand = "L'Oreal", Price = 85, Description = "Frutifantastico olor", SKU = "ssk10", Stock = 300, SubdepartmentID = 6},
                    new Product() { Name = "XBOX SERIES X", Brand = "Microsoft", Price = 5000, Description = "Consola Next-Gen", SKU = "xb0x", Stock = 20, SubdepartmentID = 4},
                    new Product() { Name = "Playstation 5", Brand = "SONY", Price = 10000, Description = "Rival Next-Gen", SKU = "pl3y", Stock = 30, SubdepartmentID = 4},
                    new Product() { Name = "Xbox 360", Brand = "Microsoft", Price = 10, Description = "Jabon de vainilla", SKU = "jv10", Stock = 400, SubdepartmentID = 4},
                    new Product() { Name = "Suavitel Lavanda Relajante", Brand = "Suavitel", Price = 10, Description = "Jabon de vainilla", SKU = "jv10", Stock = 400, SubdepartmentID = 7},
                    new Product() { Name = "Mr Limpio Blanqueador", Brand = "Mr Limpio", Price = 10, Description = "Jabon de vainilla", SKU = "jv10", Stock = 400, SubdepartmentID = 7},
                    new Product() { Name = "Muslos De Pollo", Brand = "Bachoco", Price = 80, Description = "Muslos con hueso", SKU = "mpb2", Stock = 400 , SubdepartmentID =1 },
                    new Product() { Name = "Nuggets de pollo", Brand = "Bachoco", Price = 45, Description = "Nuggets frescos y buenos", SKU = "ngg4", Stock = 5000, SubdepartmentID = 1},
                    new Product() { Name = "Leche 100 SemiDescremada", Brand = "LALA", Price = 23 , Description = "Leche con calcio extra", SKU = "ll100", Stock = 490, SubdepartmentID = 2},
                    new Product() { Name = "Queso Monterrey Jack", Brand = "Rancho del Tio", Price = 80, Description = "Queso 100% de vaca", SKU = "qmj34", Stock = 890 , SubdepartmentID = 2},
                    new Product() { Name = "Manzana Red Delicious", Brand = "ManzaMex", Price = 10, Description = "Importadas de USA", SKU = "mm2", Stock = 340, SubdepartmentID = 3},
                    new Product() { Name = "SmartTV 60\" 4k", Brand = "HiSense", Price = 2700, Description = "Pantalla nueva a 120Hz", SKU = "hs60", Stock = 40, SubdepartmentID = 5 },
                    new Product() { Name = "Cloro 1L", Brand = "Clorex", Price =  76, Description = "Altamente peligroso", SKU = "clx4", Stock = 500, SubdepartmentID = 8},

                };
                
            if (!context.Departments.Any())
                {
                    var seedDepartments = new List<Department>
                    {
                        new Department() { Name = "Alimentos"},
                        new Department() { Name = "Limpieza"},
                        new Department() { Name = "Electronicos"}
                    };
                }

            if (!context.Subdepartments.Any())
                {
                    var seedSubdepartments = new List<Subdepartment>
                    {
                        new Subdepartment() { Name="Carnes", DepartmentID = 1},
                        new Subdepartment() {Name = "Lacteos", DepartmentID = 1},
                        new Subdepartment() {Name = "FrutasVerduras", DepartmentID = 1},
                        new Subdepartment() {Name = "Videojuegos", DepartmentID = 3},
                        new Subdepartment() {Name = "TVs", DepartmentID = 3},
                        new Subdepartment() {Name = "CuidadoPersonal", DepartmentID = 2},
                        new Subdepartment() {Name = "LimpiezaRopa", DepartmentID = 2},
                        new Subdepartment() {Name = "LimpiezaHogar", DepartmentID = 2}
                    };
                }

            if (!context.Providers.Any())
                {
                    var seedProviders = new List<Provider>
                    {
                        new Provider() { Name ="Carnes Noroeste", Address = "Plaza Carnitas 123", City="Tijuana", EmailAddress="carnitas@noro.com", PhoneNumber="6642341246"},
                        new Provider() { Name ="Cajitas INC.", Address = "Ciudad Industrial Blvd 12", City="Tijuana", EmailAddress="cajitas@inc.com", PhoneNumber="2342345930"},
                        new Provider() { Name ="Surtidora Express", Address = "Circuito Sur 3334", City="Ensenada", EmailAddress="express@productos.com", PhoneNumber="2039403952"},
                        new Provider() { Name ="VOLO", Address = "Chilpancingo 2930", City="Mexicali", EmailAddress="volo@provee.com", PhoneNumber="4561237890"},

                    };
                }

            return Task.CompletedTask;
            }

        }
    }
}
