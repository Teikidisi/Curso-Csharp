using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEmpleados
{
    public class Actividades
    {
        public int HorasTrabajadas { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaActividad { get; set; }
        public bool Validado { get; set; }
        public int ID { get; set; }

        public Actividades(int horas, string descripcion, DateTime fecha, bool validar, int id)
        {
            HorasTrabajadas = horas;
            Descripcion = descripcion;
            FechaActividad = fecha;
            Validado = validar;
            ID = id;
        }


    }
}
