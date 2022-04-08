using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEmpleados
{
    public class Admin:  General
    {
        public Admin(string id, string name, DateTime fecha) :base(id, name, fecha)
        {

        }

        public override void VerActividades(string usuarioID, List<General> usuarios, List<Actividades> actividades)
        {
            if(actividades.Count != 0)
            {
                Console.WriteLine("Estas actividades faltan de ser validadas: ");
                Console.WriteLine($"ID\tDescripcion\tHoras Trabajadas\tFecha");
            }
            else
            {
                Console.WriteLine("Ya no hay actividades por validar.");
            }
                foreach (var activ in actividades)
                {
                    if (activ.Validado == false)
                    {
                        Console.WriteLine($"{activ.ID}\t{activ.Descripcion}\t\t\t{activ.HorasTrabajadas}\t\t{activ.FechaActividad.ToShortDateString()}");
                    }
                }

            Console.WriteLine("Validar cual tarea?(ID): ");
            string validarID = Console.ReadLine();
            while (validarID == "")
            {
                Console.WriteLine("Validar cual tarea?(ID): ");
                validarID = Console.ReadLine();
            }
            bool isNumber = Int32.TryParse(validarID, out int validadoID);
            if (isNumber)
            {
                var tarea = actividades.SingleOrDefault(x => x.ID == validadoID);
                if (tarea != null)
                {
                    tarea.Validado = true;
                    var usuario = usuarios.SingleOrDefault(x => x.ID == usuarioID);
                    usuario.VerActividades();
                }
                else
                {
                    Console.WriteLine("No existe esa actividad o ingresó dato erroneo");
                }
            }
            else
                Console.WriteLine("El ID debe ser un numero");
        }

        public static string[] NuevosInputs()
        {
            Console.WriteLine("\nIngresar Nombre:");
            string nombreInput = Console.ReadLine().Trim();
            while(nombreInput == "")
            {
                Console.WriteLine("Ingresar Nombre:");
                nombreInput = Console.ReadLine().Trim();
            }
            Console.WriteLine("\nIngresar ID:");
            string idInput = Console.ReadLine().Trim();
            while(idInput == "")
            {
                Console.WriteLine("Ingresar ID:");
                idInput = Console.ReadLine().Trim();
            }
            Console.WriteLine("\nIngresar Fecha Ingreso:");
            string fechaInput = Console.ReadLine().Trim();
            while(fechaInput == "")
            {
                Console.WriteLine("Ingresar Fecha Ingreso:");
                fechaInput = Console.ReadLine().Trim();
            }
            if (nombreInput != "" && idInput != "" && fechaInput != ""){
                return new string[3] { nombreInput, idInput, fechaInput };
            }
            else
            {
                throw new Exception("Un campo estaba en blanco.");
            }
        }

        public static void VerEmpleados(List<General> usuarios)
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Nombre: {usuario.Name}\tID: {usuario.ID}\tFecha de Ingreso: {usuario.FechaIngreso}");
            }
        }


    }
}
