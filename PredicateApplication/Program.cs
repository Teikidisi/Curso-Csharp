Console.WriteLine("filtros: 1-id, 2-nombre, 3-color, 4-fecha Nacimiento, 5-fecha compra, 6-hombre");
var input = Console.ReadLine();
switch (input)
{
    case "1":
        Console.WriteLine("id");
         var input1 = Console.ReadLine();
        Searcher(input1, "1");
        break;
    case "2":
        Console.WriteLine("name");
         var input2 = Console.ReadLine();
        Searcher(input2, "2");
        break;
    case "3":
        var input3 = Console.ReadLine();
        Searcher(input3, "3");
        break;
    case "4":
        var input4 = Console.ReadLine();
        Searcher(input4, "4");
        break;
    case "5":
        var input5 = Console.ReadLine();
        Searcher(input5, "5");
        break;
    case "6":
        var input6 = Console.ReadLine();
        Searcher(input6, "6");
        break;
}

static void Searcher(string input, string param)
{
    User.Input = input;
    Predicate<Person> predicateByName = new Predicate<Person>(Person.GetName);
    Predicate<Person> predicateById = new Predicate<Person>(Person.GetId);
    Predicate<Person> predicateByColor = new Predicate<Person>(Person.GetColor);
    Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetBirthday);
    Predicate<Person> predicateByBirthdayRange = new Predicate<Person>(Person.GetBirthdayRange);
    Predicate<Person> predicateByCompraDate = new Predicate<Person>(Person.GetCompraDate);
    Predicate<Person> predicateByCompraRange = new Predicate<Person>(Person.GetCompraRange);
    Predicate<Person> predicateByHombre = new Predicate<Person>(Person.GetHombre);

    List<Person> people = new List<Person>()
    {
        new Person() { Name = "Rodrigo", Id=1, Color="blanco", Birthday= new DateTime(1999,06,11),CompraDate=new DateTime(2020,8,10),Hombre=true},
        new Person() { Name = "Gibrain", Id=2, Color="verde", Birthday= new DateTime(1999,5,4),CompraDate=new DateTime(2020,8,10),Hombre=true},
        new Person() { Name = "Ernesto", Id=3, Color="negro", Birthday= new DateTime(1990,5,8),CompraDate=new DateTime(1998,5,19),Hombre=true},
        new Person() { Name = "Martin", Id=4, Color="morado", Birthday= new DateTime(1998,5,19),CompraDate=new DateTime(2005,11,21),Hombre=true},
        new Person() { Name = "Mario", Id=5, Color="amarillo", Birthday= new DateTime(2005,11,21),CompraDate=new DateTime(1974,4,28),Hombre=true},
        new Person() { Name = "Alan", Id=6, Color="rojo", Birthday= new DateTime(1999,06,11),CompraDate=new DateTime(1986,8,23),Hombre=true},
        new Person() { Name = "Rafael", Id=7, Color="rojo", Birthday= new DateTime(1986,8,23),CompraDate=new DateTime(2004,10,12),Hombre=true},
        new Person() { Name = "Pedro", Id=8, Color="verde", Birthday= new DateTime(2004,10,12),CompraDate=new DateTime(2010,2,3),Hombre=true},
        new Person() { Name = "Jorge", Id=9, Color="amarillo", Birthday= new DateTime(2010,2,3),CompraDate=new DateTime(1990,2,10),Hombre=true},
        new Person() { Name = "Juan", Id=10, Color="oro", Birthday= new DateTime(1990,2,10),CompraDate=new DateTime(2020,9,15),Hombre=true},
        new Person() { Name = "Carlos", Id=11, Color="azul", Birthday= new DateTime(2020,9,15),CompraDate=new DateTime(2020,8,10),Hombre=true},
        new Person() { Name = "Annette", Id=12, Color="rosa", Birthday= new DateTime(2020,8,10),CompraDate=new DateTime(1980,7,4),Hombre=false},
        new Person() { Name = "Maria", Id=13, Color="azul", Birthday= new DateTime(1980,7,4),CompraDate=new DateTime(1930,5,4),Hombre=false},
        new Person() { Name = "Ana", Id=14, Color="negro", Birthday= new DateTime(1930,5,4),CompraDate=new DateTime(1860,5,4),Hombre=false},
        new Person() { Name = "Anel", Id=15, Color="gris", Birthday= new DateTime(1860,5,4),CompraDate=new DateTime(1999,6,2),Hombre=false},
        new Person() { Name = "Julia", Id=16, Color="cafe", Birthday= new DateTime(1999,6,2),CompraDate=new DateTime(2009,8,7),Hombre=false},
        new Person() { Name = "Carla", Id=17, Color="rosa", Birthday= new DateTime(2009,8,7),CompraDate=new DateTime(2000,5,7),Hombre=false},
        new Person() { Name = "Karla", Id=18, Color="verde", Birthday= new DateTime(2000,5,7),CompraDate=new DateTime(2010,4,8),Hombre=false},
        new Person() { Name = "Victor", Id=19, Color="morado", Birthday= new DateTime(2010,4,8),CompraDate=new DateTime(2010,7,10),Hombre=false},
        new Person() { Name = "Victoria", Id=20, Color="negro", Birthday= new DateTime(2010,7,10),CompraDate=new DateTime(1999,6,11),Hombre=false},
    };

    if (param == "1")
    {
        if (people.Exists(predicateById))
        {
            var result = people.FindAll(predicateById);
            Console.WriteLine("La persona con el id " + input + " es: ");
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
    if (param == "2")
    {
        if (people.Exists(predicateByName))
        {
            var result = people.FindAll(predicateByName);
            foreach (var item in result)
            {
                Console.WriteLine($"Se encontró Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
    if (param == "3")
    {
        if (people.Exists(predicateByColor))
        {
            var result = people.FindAll(predicateByColor);
            Console.WriteLine("A estos les gusta el color " + input);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
    if (param == "4")
    {
        if (input.Contains("-"))
        {
            Console.WriteLine("rango de cumpleaños");
            var result = people.FindAll(predicateByBirthdayRange);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }


        else if (people.Exists(predicateByBirthday))
        {
            Console.WriteLine("Las personas que tienen " + input + " de nacimiento son: ");
            var result = people.FindAll(predicateByBirthday);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
    if (param == "5")
    {
        if (input.Contains("-"))
        {
            Console.WriteLine("rango de compras");
            var result = people.FindAll(predicateByCompraRange);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
        else if (people.Exists(predicateByCompraDate))
        {
            Console.WriteLine("Las personas que compraron en " + input + " fecha son: ");
            var result = people.FindAll(predicateByCompraDate);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
    if (param == "6")
    {
        if (people.Exists(predicateByHombre))
        {
            Console.WriteLine("Las personas que son "+input+" hombre es: ");
            var result = people.FindAll(predicateByHombre);
            foreach (var item in result)
            {
                Console.WriteLine($"Nombre:{item.Name} Id:{item.Id} Color:{item.Color} Birthday:{item.Birthday} CompraDate:{item.CompraDate} Hombre:{item.Hombre} ");
            }
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Color { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CompraDate { get; set; }
    public bool Hombre { get; set; }

    public static bool GetName(Person person)
    {
        return person.Name.Equals(User.Input);
    }
    public static bool GetId(Person person)
    {
        var isNumber = Int32.TryParse(User.Input, out var id);
        if (isNumber)
        {
            return person.Id.Equals(id);
        }
        else
        {
            return false;
        }
    }
    public static bool GetColor(Person person)
    {
        return person.Color.Equals(User.Input);
    }
    public static bool GetBirthday(Person person)
    {
        var isDate = DateTime.TryParse(User.Input, out DateTime Birthday);
        if (isDate)
        {
            return person.Birthday.Equals(Birthday);
        }
        else
        {
            return false;
        }
    }
    public static bool GetBirthdayRange(Person person)
    {
        string[] rango = User.Input.Split("-");
        var isDate1 = DateTime.TryParse(rango[0], out DateTime Birthday1);
        var isDate2 = DateTime.TryParse(rango[1], out DateTime Birthday2);
        if (isDate1 && isDate2)
        {
            if (person.Birthday.CompareTo(Birthday1) > 0)
            {
                if (person.Birthday.CompareTo(Birthday2) < 0)
                {
                    return true;
                } else { return false; }
            } else { return false; }
        }
        else
        {
            return false;
        }
    }
    public static bool GetCompraDate(Person person)
    {
        var isDate = DateTime.TryParse(User.Input, out DateTime Compra);
        if (isDate)
        {
            return person.CompraDate.Equals(Compra);
        }
        else
        {
            return false;
        }
    }
    public static bool GetCompraRange(Person person)
    {
        string[] rango = User.Input.Split("-");
        var isDate1 = DateTime.TryParse(rango[0], out DateTime Compra1);
        var isDate2 = DateTime.TryParse(rango[1], out DateTime Compra2);
        if (isDate1 && isDate2)
        {
            if (person.CompraDate.CompareTo(Compra1) > 0)
            {
                if (person.CompraDate.CompareTo(Compra2) < 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        else
        {
            return false;
        }
    }
    public static bool GetHombre(Person person)
    {
        Boolean myBool;
        if (Boolean.TryParse(User.Input, out myBool))
        {
            return person.Hombre.Equals(myBool);
        }
        else
            return false;
    }
}

class User
{
    public static string? Input { get; set; }
}