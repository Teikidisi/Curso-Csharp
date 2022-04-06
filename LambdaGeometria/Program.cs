var inputX = "";
var inputY = "";
bool ciclo = true;
while (ciclo)
{
    Console.WriteLine("Bienvenido a la calculadora geometrica\n\rIngrese que figura quiere:\n1. Circulo\t2. Cuadrado\t3. Triangulo\t4. Rectangulo");
    var figura = Console.ReadLine().ToLower();
     if (figura == "circulo" || figura == "1")
    {
         figura = "circulo";
        Console.WriteLine("Ingrese el radio");
         inputX = Console.ReadLine();
         inputY = "0";
    }
    else if (figura == "rectangulo" || figura == "4")
    {
         figura = "rectangulo";
        Console.WriteLine("Ingrese el lado 1");
         inputX = Console.ReadLine();
        Console.WriteLine("Ingrese el lado 2");
         inputY = Console.ReadLine();
    }
    else if (figura == "triangulo" || figura == "3")
    {
        figura = "triangulo";
        Console.WriteLine("Ingrese la base");
         inputX = Console.ReadLine();
        Console.WriteLine("Ingrese la altura");
         inputY = Console.ReadLine();

    }
    else if (figura == "cuadrado" || figura == "2")
    {
        figura = "cuadrado";
        Console.WriteLine("Ingrese el lado");
         inputX = Console.ReadLine();
         inputY = "0";
    }
    else
    {
        Console.WriteLine("No escribió bien el nombre de la figura o puso algun numero erroneo");
    }
    if (Double.TryParse(inputX, out double x) && Double.TryParse(inputY, out double y))
    {
        GeometriaDelegate.Operate(x, y, figura);
        GeometriaFunction.Lambda(x, y, figura);
    } else
    {
        Console.WriteLine("Un numero no era numero.");
    }

    Console.WriteLine("\n¿Hacer otro calculo? Presione enter.");
    while(Console.ReadKey().Key != ConsoleKey.Enter)
    {
    //if (figura.ToLower() == "f")
    //{
    //   ciclo = false;
    //}
    }
    Console.WriteLine("------------------------------------------------------");
}

public class GeometriaDelegate
{
    public delegate double DosLados(double x, double y);
    public delegate double UnLado(double x);

    public static void Operate(double x, double y, string input){
        UnLado cuadradoArea = new UnLado(x => x * x);
        UnLado cuadradoPerimetro = new UnLado(x => x * 4);
        UnLado circuloArea = new UnLado(x => Math.PI * Math.Pow(x,2));
        UnLado circuloPerimetro = new UnLado(x => 2 * Math.PI * x);
        DosLados rectanguloArea = new DosLados((x, y) => x * y);
        DosLados rectanguloPerimetro = new DosLados((x, y) => 2 * x + 2 * y);
        DosLados trianguloArea = new DosLados((x, y) => x * y / 2);
        DosLados trianguloPerimetro = new DosLados((x, y) => x + 2 * (y / Math.Sin(Math.Atan(y / (x/2)))));

        Console.WriteLine("Calculo Delegate");
        switch (input)
        {
            case "circulo":
                Console.WriteLine($"El área del circulo es {circuloArea(x)} y su perimetro es {circuloPerimetro(x)}.");
                break;
            case "rectangulo":
                Console.WriteLine($"El área del rectangulo es {rectanguloArea(x,y)} y su perimetro es {rectanguloPerimetro(x,y)}.");
                break;
            case "cuadrado":
                Console.WriteLine($"El área del cuadrado es {cuadradoArea(x)} y su perimetro es {cuadradoPerimetro(x)}.");
                break;
            case "triangulo":
                Console.WriteLine($"El área del triangulo es {trianguloArea(x,y)} y su perimetro es {trianguloPerimetro(x,y)}.");
                break;
        }

    }
}

public class GeometriaFunction
{
    public static void Lambda(double x, double y, string input)
    {
        Func<double, double, double> rectanguloArea = (x, y) => x * y;
        Func<double, double, double> rectanguloPerimetro = (x, y) => 2 * x + 2 * y;
        Func<double, double> cuadradoArea = x => x * x;
        Func<double, double> cuadradoPerimetro = x => 4 * x;
        Func<double, double, double> trianguloArea = (x, y) => x * y / 2;
        Func<double, double, double> trianguloPerimetro = (x, y) => (x  + 2* (y / Math.Sin(Math.Atan(y / (x/2)))));
        Func<double, double> circuloArea = x => Math.PI * Math.Pow(x, 2);
        Func<double, double> circuloPerimetro = x => 2 * x * Math.PI;

        Console.WriteLine("Calculo Lambda");
        switch (input)
        {
            case "circulo":
                Console.WriteLine($"El área del circulo es {circuloArea(x)} y su perimetro es {circuloPerimetro(x)}.");
                break;
            case "rectangulo":
                Console.WriteLine($"El área del rectangulo es {rectanguloArea(x, y)} y su perimetro es {rectanguloPerimetro(x, y)}.");
                break;
            case "cuadrado":
                Console.WriteLine($"El área del cuadrado es {cuadradoArea(x)} y su perimetro es {cuadradoPerimetro(x)}.");
                break;
            case "triangulo":
                Console.WriteLine($"El área del triangulo es {trianguloArea(x, y)} y su perimetro es {trianguloPerimetro(x, y)}.");
                break;
        }
    }
}
