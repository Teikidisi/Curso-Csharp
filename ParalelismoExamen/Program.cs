
using System.Diagnostics;

Console.WriteLine("Bienvenido a tu examen final, tienes 15 segundos para contestar 3 preguntas, enter para iniciar");
while(Console.ReadKey().Key != ConsoleKey.Enter)
{

}
var tiempoTotal = await Preguntados.ExamenGeneral();


public class Preguntados
{
    public static async Task<long> ExamenGeneral()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();      
        
        var taskPreguntas =  Preguntas();
        var task4 =  Tiempo();
        await Task.WhenAny(task4, taskPreguntas);
        stopwatch.Stop();
        
        Console.WriteLine($"El tiempo transcurrido fue {stopwatch.ElapsedMilliseconds / 1000m}");

        return stopwatch.ElapsedMilliseconds;
    }

    public static async Task Preguntas()
    {
         await Task.Run(() =>
        {
        Console.WriteLine("1. ¿De qué color son las mangas del chaleco blanco de Napoleon?");
        Console.WriteLine("a. Blancas\nb. Negras\nc. Verdes\nd. No tiene");
        string respuesta1 = Console.ReadLine();
        Console.WriteLine("2. ¿En qué temporada hace más frío en el hemisferio norte?");
        Console.WriteLine("a. Verano\nb. Invierno\nc. Otoño\nd. Primavera");
        string respuesta2 = Console.ReadLine();
        Console.WriteLine("3. ¿Qué licor te puedes hacer con una papa?");
        Console.WriteLine("a. Vodka\nb. Tequila\nc. Whiskey\nd. Ron");
        string respuesta3 = Console.ReadLine();
        
        long correcto = 0;
        if (respuesta1 == "d")
        {
                correcto++;
        }
        if (respuesta2 == "b")
        {
                correcto++;
        }
        if (respuesta3 == "a")
        {
                correcto++;
        }
        Console.WriteLine($"Tu resultado es {correcto}/3 aciertos");
        return correcto;
        });

    }
    public static async Task Tiempo()
    {
        await Task.Run(() => {
            Thread.Sleep(15000);
            Console.WriteLine("-----------------------------------\nSe acabó el tiempo");
    });
    }
}