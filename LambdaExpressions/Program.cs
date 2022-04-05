
while (Console.ReadKey().Key != ConsoleKey.F)
{
    Console.WriteLine("Welcome to Lambda Calculator");
    Console.WriteLine("Please insert a number 1: ");
    var inputX = Console.ReadLine();
    Console.WriteLine("Multiply(*)\tAdd(+)\tSubstract(-)\tDivide(/)\tSin(sin)\tCos(cos) ");
    var inputChoice = Console.ReadLine();
    if (inputChoice == "sin" || inputChoice == "cos")
    {
        if (Double.TryParse(inputX, out double x))
        {
            DelegateCalculator.Operate(x,0, inputChoice);
            FunctionCalculator.Lambda(x, 0, inputChoice);
            
        }
        else
        {
            Console.WriteLine("Please insert a valid number");
        }

    }
    if (inputChoice == "sin" || inputChoice == "cos")
    {
        continue;
    }
    else
    {
        Console.WriteLine("Please insert a number 2: ");
        var inputY = Console.ReadLine();
        if (inputChoice == "+" || inputChoice == "-" || inputChoice == "/" || inputChoice == "*")
        {
            if (Double.TryParse(inputX, out double x) && Double.TryParse(inputY, out double y))
            {
                DelegateCalculator.Operate(x, y, inputChoice);
                FunctionCalculator.Lambda(x, y, inputChoice);
            }
            else
            {
                Console.WriteLine("Please insert a valid number");
            }
        }
        else { Console.WriteLine("Please put a valid operation"); }
    }
    Console.WriteLine("press F to exit.");
   
    Console.WriteLine("-------------------------------------");
}
class DelegateCalculator
{
    public delegate double SelfOperator(double x);
    public delegate double Operator(double x, double y);

    public static void Operate(double num, double num2, string choice)
    {
        SelfOperator square = new SelfOperator(x => x * x);
        Operator multiplication = new Operator((x, y) => x * y);
        Operator addition = new Operator((x,y) => x + y);
        SelfOperator sine = new SelfOperator(x => Math.Sin(x));
        SelfOperator cosine = new SelfOperator(x => Math.Cos(x));
        Operator substraction = new Operator((x, y) => x - y);
        Operator division = new Operator((x, y) => x / y);

        if (choice == "*")
        {
            Console.WriteLine("The multiplication is: " + multiplication(num, num2));
        }
        else if (choice == "+")
        {
            Console.WriteLine("The addition is: " + addition(num, num2));
        }
        else if (choice == "-")
        {
            Console.WriteLine("The substraction is: " + substraction(num, num2));
        }
        else if (choice == "sin")
        {
            Console.WriteLine("The sine is: " + sine(num));
        }
        else if (choice == "cos")
        {
            Console.WriteLine("The cosine is: " + cosine(num));
        }
        //Console.WriteLine("The square is: " + square(num));
        else if (choice == "/")
        {
        if (num2 != 0)
        {
            Console.WriteLine("The division is: " + division(num, num2));
        }
        else { Console.WriteLine("Can't divide by 0"); }
        }
    }
}

class FunctionCalculator
{
    public static void Lambda(double x, double y, string choice)
    {
        Func<double, double, double> addition = (x, y) => x + y;
        Func<double, double, double> multiplication = (x, y) => x * y;
        Func<double, double, double> substraction = (x, y) => x - y;
        Func<double, double, double> divide = (x, y) => x / y;
        Func<double, double> sin = x => Math.Sin(x);
        Func<double,double> cos = x => Math.Cos(x);
    
        if (choice == "*")
        {
            Console.WriteLine($"Lambda style:{ multiplication(x, y)}");
        }
        else if (choice == "+")
        {
            Console.WriteLine($"Lambda style: {addition(x, y)}");
        }
        else if (choice == "-")
        {
            Console.WriteLine($"Lambda style: {substraction(x, y)}");
        }
        else if (choice == "/")
        {
                if (y != 0)
                {
                    Console.WriteLine($"Lambda style: {divide(x, y)}");
                }
                else
                {
                    Console.Write("Syntax Error");
                }
        }
        else if (choice == "sin")
        {
            Console.WriteLine($"Lambda style: {sin(x)}");
        }
        else if (choice == "cos")
        {
            Console.WriteLine($"Lambda style: {cos(x)}");
        }
        }
}

class ActionCalculator
{
    public static void Lambda(double x, double y)
    {
        //Action es como el Func<> pero no tiene un parametro de salida
        //No regresa nada, es void, asi que debes ejecutarlo directamente al declararlo
        Action<double, double> addition = (x, y) =>
         {
             Console.WriteLine(x + y);
         };
        addition(x, y);
    }
}