using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEmpleados
{
    public class General
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool isAdmin { get; set; }
        public General(string id, string name, DateTime fecha, bool isadmin )
        {
            ID = id;
            Name = name;
            FechaIngreso = fecha;
            isAdmin = isadmin;
        }

        public General(string id, string name, DateTime fecha)
        {
            ID = id;
            Name = name;
            FechaIngreso = fecha;
        }

        public List<Actividades> actividades = new List<Actividades>();



        public void AddActividades(int horas, string descripcion, DateTime fechaActividad, bool validado, int id)
        {
            var trabajado = new Actividades(horas, descripcion, fechaActividad, validado, id);
            actividades.Add(trabajado);
        }

        public virtual void NuevasActividades()
        {
            Console.WriteLine("Ingresa la fecha a registrar actividad: (yyyy,mm,dd)");
            string fechaInput = Console.ReadLine();
            while(fechaInput == "")
            {
                Console.WriteLine("Ingresa la fecha a registrar actividad: (yyyy,mm,dd)");
                fechaInput = Console.ReadLine();
            }
            if (DateTime.TryParseExact(fechaInput,"yyyy,MM,dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaActividad))
            {
                Console.WriteLine("Ingresa las horas trabajadas: ");
                string horasInput = Console.ReadLine();
                while (horasInput  == "")
                {
                    Console.WriteLine("Ingresa las horas trabajadas: ");
                    horasInput = Console.ReadLine();
                }
                while (Int32.Parse(horasInput) >= 24)
                {
                    Console.WriteLine("No puedes tener mas horas que las que hay en un dia");
                    horasInput = Console.ReadLine();
                }
                if (Int32.TryParse(horasInput, out int horas))
                {
                    Console.WriteLine("Ingresa la descripción de la actividad: ");
                    string descripcionInput = Console.ReadLine();
                    while (descripcionInput == "")
                    {
                        Console.WriteLine("Ingresa la descripción de la actividad: ");
                        descripcionInput = Console.ReadLine();
                    }
                    AddActividades(horas, descripcionInput, fechaActividad, false, actividades.Count+1);
                    VerActividades();
                }
                else
                {
                    Console.WriteLine("Solo ingresar el numero de horas.");
                }
            }
            else
            {
                Console.WriteLine("La fecha está en el formato incorrecto");
            }
        }

        public virtual void VerActividades()
        {
            if (actividades.Count != 0)
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
                    Console.WriteLine($"{activ.ID}\t{activ.Descripcion}\t\t{activ.HorasTrabajadas}\t\t\t{activ.FechaActividad.ToShortDateString()}");
                }
            }
        }

        public virtual void VerActividades(string x, List<General> usuario, List<Actividades> actividades) { }

        public void Aniversario()
        {
            if (DateTime.Now.AddYears(-1).ToShortDateString() == FechaIngreso.ToShortDateString())
            {
                Console.WriteLine($"Feliz aniversario {Name}!");
            }
            else
            {
                return;
            }
        }


    }
}
