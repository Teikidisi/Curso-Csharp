using Business;
using Business.Services.Implementations;
using Data.Entities;
using eShop;

internal class Program
{

    private static void Main(string[] args)
    {
        
        var showMenu = true;
        var console = new eShopConsole();
        while (showMenu)
        {
            showMenu = console.MainMenu();
        }

    }

}


//private static Subdepartment SolicitarSubdepartamento()
//{
//    Console.WriteLine("Elige el departamento");
//    var departments = _productService.GetDepartments();
//    for (int i = 0; i < departments.Count; i++)
//    {
//        Console.WriteLine($"{i+1}. {departments.ElementAt(i)}");
//    }
//    int depaInt = Int32.Parse(Console.ReadLine());
//    depaInt -= 1;
//    var departmentPosition = IntentarObtenerInt(Console.ReadLine()) - 1;
//    var department = departments.ElementAt(departmentPosition);
//    Console.WriteLine($"Elige el subdepartamento de {department.Name}");

//    for (int i = 0; i < department.Subdepartments.Count; i++)
//    {
//        Console.WriteLine($"{i+1}. {department.Subdeparments.ElementAt(i)}");
//    }
//}