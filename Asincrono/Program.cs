
using System.Diagnostics;

Console.WriteLine("Loading...");

//Asynchronous.WaitForIt(); //al no tener await se ejecuta el WaitForIt2 al instante, porque no espera que termine el anterior
//await Asynchronous.WaitForIt2();//este tardará solo 5s en aparecer en vez de 10 despues del resultado del WaitForIt
                                //para hacer que tarde 10 al terminar el primero, poner await en el primero tambien
var timeElapsed = await Parallelism.Main();
Console.WriteLine("Both processes finished after {0} seconds",timeElapsed/1000m); 
public class Asynchronous{
    public static async Task WaitForIt()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine("Five seconds complete");
    }

    public static async Task WaitForIt2()
    {
        await Task.Delay(10000);
        Console.WriteLine("Ten seconds complete");
    }
}

public class Parallelism
{
    public static async Task<long> Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        //await Process1();
        //Process2();

        var task1 = Process1();
        var task2 = Process2();

        await Task.WhenAll(task1, task2);

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    public static async Task Process1()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(4000);
        });
    }

    public static async Task Process2()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(1000);
        });
    }
}