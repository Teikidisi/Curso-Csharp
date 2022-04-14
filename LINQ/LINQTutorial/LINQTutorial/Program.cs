//Func recibe y regresa valores. El regreso es el ultimo parametro
Func<int, int> square = x => x * x;
//Action solo recibe valores, es metodo void
Action<string> action = x => Console.WriteLine(x);

Console.WriteLine(square(5));
action("Hola mundo");

int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
var squaredNumbers = numbers.Select(square);
Console.WriteLine(String.Join(",",squaredNumbers));

Action line = () => Console.WriteLine("Hola");
line();

Func<int, int, string> IsTooLong = (x, y) =>  x > y ? "es mayor" : "es menor";
//Funcion superior usando {} para mostrar varias lineas de codigo, pero mejor usar la funcion ternaria
Func<int, int, string> IsTooLong2 = (x, y) =>
{
    if (x > y)
        return "es mayor";
    else
        return "es menor";
};
//metodo con cuerpo de expresion
static string IsTooLong3(int x, int y) => x > y ? "es mayor" : "es menor";

Console.WriteLine(IsTooLong(4, 5));
Console.WriteLine(IsTooLong3(20,15));

//Tu funcion te regresará dos valores en vez de declarar solo uno.

static (bool EsCorrecto, string Mensaje) MisTuplas()
{
    return (true, "mensaje de prueba");
}
//las tuplas te regresan los valores en variables genericas llamadas Item(n)
//Si le asignas un nombre a la variable como arriba entonces si puedes accesar esa variable,
//esto es para que esté mas facil la lectura del codigo. A partir de C#7
var tupas = MisTuplas();
Console.WriteLine(tupas.Item1+ " Mensaje: "+tupas.Item2);
Console.WriteLine(tupas.EsCorrecto + " Mensaje: " + tupas.Mensaje);

//Es mejor instaurar una clase con los valores, pero se eligen tuplas si es algo chiquito no importante, algo que solo se usará una vez
//public class MiClaseTuplas
//{
//    public bool Resultado { get; set; }
//    public string Mensaje { get; set; }
//}


//La funcion acepta una tupla como resultado 
Func<int, int, (bool Comparacion, string Mensaje)> MiFunc = (x, y) => (x > y, "Mi mensaje");
var aux = MiFunc(1, 2);
Console.WriteLine(aux.Comparacion+" : "+aux.Mensaje);

//Param descartado C#9
Func<int, int, int> constante = (_, _) => 42;
Action<int, int> constant2 = (_, _) => Console.WriteLine(43);

//un action con serie de declaraciones
Action<int> miAccionAsincrona = miParametro =>
 {
     Task.Delay(2000);
     Console.WriteLine("Me esperé 2 segundos");
 };


//Action con metodo asincrono
Action<int> miAccionASincrona2 = async parametro => await DelayConImpresion(parametro);

static async Task DelayConImpresion(int x)
{
    await Task.Delay(2000);
    Console.WriteLine("Me esperé 2000 ms e imprimi " + x);
}