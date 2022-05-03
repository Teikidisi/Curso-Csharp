using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeSop
{
    public class eShopConsole
    {
        public eShopConsole()
        {

        }

        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Eres cliente o admin?");
            Console.WriteLine("1.Cliente\n2.Admin");
            Console.Write("Opcion:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Hola cliente que deseas hacer?");
                    break;
                case "2":
                    Console.WriteLine("Hola admin");
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
