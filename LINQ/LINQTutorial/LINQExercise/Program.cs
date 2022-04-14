class Program
{
    static void Main(string[] args)
    {
        // problema 1
        var fruitsQuery = fruits
            .Where(fruit => fruit.StartsWith("L"));
        foreach(var fruit in fruitsQuery)
        {
            Console.WriteLine("Fruta: "+fruit);
        }

        //problema 2
        var multiplesQuery = mixedNumbers
            .Where(number => number % 4 == 0 || number % 6 == 0);
        Console.WriteLine(String.Join(",",multiplesQuery));

        //problema 3
        numbers.Count();
        Console.WriteLine(numbers.Count());

        Console.WriteLine("MIllonarios por cada banco");
        //desplegar cuantos millonarios hay por banco
        var millonariosQuery = customers
            .Where(customer => customer.Balance >= 1000000)
            .GroupBy(customer => customer.Bank)
            .OrderBy(group => group.Key);
        //.Select(bank => new { Bank =  bank.Key, Millonarios = bank.Count()}); 
        //Para evitar tener que iterar en un foreach y poder usar un String.JOIN()
        foreach(var bank in millonariosQuery)
        {
            int count = 0;
            Console.WriteLine(bank.Key);
            foreach(var millonario in bank)
            {
                count++;
                //Console.WriteLine($"Balance: {millonario.Balance} Cliente: {millonario.Name}");
            }
            Console.WriteLine($"Total de millonarios en {bank.Key}: {count}");
        }
        //hay que mostrar a los clientes con balance > 100,000
        var millonariosQuery2 = customers
            .Where(customer => customer.Balance >= 100000)
            .Select(customer => customer.Name);

        Console.WriteLine("\nPersonas con mas de 100,000: ");
        Console.WriteLine(String.Join(",",millonariosQuery2));

        //ordenar a los clientes por su balance
        Console.WriteLine("\nOrdenados por cantidad");
        var ordenadosQuery = customers
            .OrderByDescending(customer => customer.Balance);
        foreach(var ordenado in ordenadosQuery)
        {
            Console.WriteLine($"{ordenado.Name} tiene un balance de: {ordenado.Balance}");
        }

        //sumatoria de riqueza por cada banco
        Console.WriteLine("\nRiqueza de cada banco");
        var riquezaQuery = customers
            .GroupBy(customer => customer.Bank)
            .OrderBy(group => group.Key)
            .Select(customer => new
            {
                Bank = customer.Key,
                Total = customer.Sum(customer => customer.Balance)
            });
        foreach (var banco in riquezaQuery)
        {
            Console.WriteLine($"Banco: {banco.Bank} Total: {banco.Total}");
        }

        //obtener el nombre de los clientes con balance < 100000 y su banco tenga 3 caracteres
        Console.WriteLine("\nBancos de 3 caracteres y clientes de < 100mil");
        var RicosTresQuery = customers
            .Where(customer => customer.Balance < 100000 && customer.Bank.Length == 3)
            .Select(customer => $"{customer.Name}");
        Console.WriteLine($"Clientes pobres: {String.Join(",",RicosTresQuery)}");

        //CIUDADES--------------------------------------------------------------------------------
        //encontrar el que incie y termine con las letras "AM"
        //Ordenarlos en longitud de palabra y luego por orden alfabetico
        //Dividirlos en 3 grupos distintos randoms

        Console.WriteLine("\nCiudad que inicie y termine con AM");
        var LetrasAM = cities
            .Where(city => city.StartsWith("AM") && city.EndsWith("AM"))
            .Select(city => $"{city}");
        Console.WriteLine(String.Join(",",LetrasAM));

        Console.WriteLine("\nOrdenarlos en longitud de palabra y alfabetico");
        var ordenQuery = cities
            .OrderBy(city => city)
            .GroupBy(city => city.Length)
            .OrderBy(lengths => lengths.Key);
        foreach(var length in ordenQuery)
        {
            Console.WriteLine(length.Key);
            foreach(var orden in length)
            {
                Console.WriteLine(orden);
            }
        }

        Console.WriteLine("\nAgrupar random");
        var randomQuery = cities
            .Where(city => city.Length >=6 && city.Contains("A") )
            .GroupBy(city => city.Length)
            .OrderBy(length => length.Key);
        foreach(var city in randomQuery)
        {
            Console.WriteLine(city.Key);
            foreach(var item in city)
            {
                Console.WriteLine(item);
            }
        }


    }

    //Find the words that start with the letter L
    public static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
    //Find multiples of 4 or 6
    public static List<int> mixedNumbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };
    //How many numbers are in the list
    public static List<int> numbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

    public static List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
    public static string[] cities =
            {
                "ROME","ZURICH","NAIROBI","CALIFORNIA","LONDON","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }

}


