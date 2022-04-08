using DesafioEmpleados;

List<General> usuarios = new List<General>();
List<Admin> admins = new List<Admin>();


var usuario2 = new General("1", "Jorge", new DateTime(2020,02,02), false);
var usuario3 = new General("2", "Ernesto", new DateTime(2021,05,12), false);
var usuario4 = new General("3", "Diego", new DateTime(2018,10,04), false);

var admin1 = new Admin("1a", "Rodrigo", new DateTime(2021, 04, 08));
var admin2 = new Admin("2a", "Ana", new DateTime(2007, 03, 23));

admins.Add(admin1);
admins.Add(admin2);

usuarios.Add(usuario2);
usuarios.Add(usuario3);
usuarios.Add(usuario4);

usuario2.AddActividades(10, "uber   ", new DateTime(2020, 05, 01), false,1);
usuario2.AddActividades(4,  "lyft    ", new DateTime(2019, 05, 02), true,2);
usuario2.AddActividades(1, "rappi  ", new DateTime(2020, 12, 15), false,3);
usuario2.AddActividades(10, "uber eats", new DateTime(2020, 08, 23), false,4);
usuario3.AddActividades(8, "Vender flores", new DateTime(2020, 08, 23), false, 1);

foreach (var item in usuarios)
{
    item.Aniversario();
}
foreach (var item in admins)
{
    item.Aniversario();

}

int usar = 0;
while (usar == 0)
{
    Console.WriteLine("Ingresa tu id: ");
    string id = Console.ReadLine();
    while (id == "")
    {
        Console.WriteLine("Ingresa tu id: ");
        id = Console.ReadLine();
    }

    if (id.Contains("a"))
    {
        var adminUsado = admins.SingleOrDefault(x => x.ID == id);
        if (adminUsado != null)
        {
            Console.WriteLine($"Hola admin {adminUsado.Name} ¿Qué quieres hacer?");
            Console.WriteLine("¿Validar actividades de empleados(1) o ver listas de empleados?(2)");
            string decision = Console.ReadLine();
            while (decision == "")
            {
                Console.WriteLine("¿Validar actividades de empleados(1) o ver listas de empleados?(2)");
                decision = Console.ReadLine();
            }

            if (decision == "1")
            {
                Console.WriteLine("ingrese el id del usuario");
                string decisionid = Console.ReadLine();
                while (decisionid == "")
                {
                    Console.WriteLine("ingrese el id del usuario");
                    decisionid = Console.ReadLine();
                }
                var usuario = usuarios.SingleOrDefault(x => x.ID == decisionid);
                if (usuario != null)
                {
                    adminUsado.VerActividades(usuario.ID, usuarios, usuario.actividades);
                }
                else
                {
                    Console.WriteLine("No ingresó ID existente");
                }
            }

            else if (decision == "2")
            {
                Admin.VerEmpleados(usuarios);
                Console.WriteLine("Que opción deseas hacer?\n\r1.Añadir empleado\n\r2.Editar empleado\n\r3.Eliminar empleado");
                string decisionEmpleados = Console.ReadLine();
                switch (decisionEmpleados)
                {
                    case "1":
                        string[] inputs = Admin.NuevosInputs();

                        var usuarioIDOcupado = usuarios.SingleOrDefault(x => x.ID == inputs[1]);
                        if (usuarioIDOcupado != null)
                        {
                            Console.WriteLine($"El ID {inputs[1]} no puede ser asignado.");
                        }
                        else
                        {
                            if (DateTime.TryParseExact(inputs[2], "yyyy,MM,dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaingreso))
                            {
                                usuarios.Add(new General(inputs[1], inputs[0], fechaingreso, false));
                                Admin.VerEmpleados(usuarios);
                            }
                            else
                            {
                                Console.WriteLine("Esa fecha no es válida.");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ingresar el ID de quien modificar:");
                        string modificado = Console.ReadLine().Trim();
                        while (modificado == "")
                        {
                            Console.WriteLine("Ingresar el ID de quien modificar:");
                            modificado = Console.ReadLine().Trim();
                        }

                        var usuarioModificar = usuarios.SingleOrDefault(x => x.ID == modificado);
                        if (usuarioModificar != null)
                        {
                            string[] inputs2 = Admin.NuevosInputs();

                            if (DateTime.TryParseExact(inputs2[2], "yyyy,MM,dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaingreso2))
                            {
                                if (usuarioModificar.ID == inputs2[1])
                                {
                                    usuarioModificar.Name = inputs2[0];
                                    usuarioModificar.ID = inputs2[1];
                                    usuarioModificar.FechaIngreso = fechaingreso2;
                                }
                                else
                                {
                                    string oldID = usuarioModificar.ID;
                                    usuarioModificar.ID = inputs2[1];
                                    int counter = 0;
                                    foreach (var usuarioCheckID in usuarios)
                                    {
                                        if (inputs2[1] == usuarioCheckID.ID)
                                        {
                                            counter++;
                                        }
                                    }
                                    if (counter >= 2)
                                    {
                                        usuarioModificar.ID = oldID;
                                        Console.WriteLine("Ese ID ya existe en la base de datos para otro usuario");
                                    }
                                    else
                                    {
                                        usuarioModificar.Name = inputs2[0];
                                        usuarioModificar.FechaIngreso = fechaingreso2;
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Esa fecha no es válida.");
                            }
                            Admin.VerEmpleados(usuarios);
                        }
                        else
                            Console.WriteLine("No ingresó ID existente");
                        break;
                    case "3":
                        Console.WriteLine("Ingresar el ID de quien eliminar: ");
                        string eliminado = Console.ReadLine();
                        var usuarioMuerto = usuarios.SingleOrDefault(x => x.ID == eliminado);

                        if (usuarioMuerto != null)
                        {
                            usuarios.Remove(usuarioMuerto);
                            Admin.VerEmpleados(usuarios);
                        }
                        else
                        {
                            Console.WriteLine("No ingresó ID existente");
                        }
                        break;
                    default:
                        Console.WriteLine("Ninguna opcion, saliendo.");
                        break;
                }
            }
            else
                Console.WriteLine("No ingresaste una opción correcta.");
        }
    }
    else
    {
        var usuarioUsado = usuarios.SingleOrDefault(x => x.ID == id);
        if (usuarioUsado != null)
        {
            Console.WriteLine($"Bienvenido al portal {usuarioUsado.Name}");
            Console.WriteLine("Ingresar nueva entrada al log(1) o ver actividades(2)?: ");
            string decision = Console.ReadLine();
            if (decision == "1")
                usuarioUsado.NuevasActividades();
            else if (decision == "2")
                usuarioUsado.VerActividades();
            else
                Console.WriteLine("No ingresaste una opción.");
        }
    }
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Quieres salir de la app? Presiona \"y\" para salir");
    var salida = Console.ReadKey();
    if (salida.Key == ConsoleKey.Y)
        usar++;
    else
        Console.WriteLine("-----------------------------------------------");
}




