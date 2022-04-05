Console.WriteLine("Search: ");
var input = Console.ReadLine();
Searcher(input);



static void Searcher(string input)
{
    User.Input = input;

    Predicate<Person> predicateByName = new Predicate<Person>(Person.Exists);
    Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);
    Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetByDate);

    List<Person> people = new List<Person>()
    {
        new Person() { Name = "Gildardo", Age = 27 , Birthday= new DateTime(1995,6,25)},
        new Person() { Name = "Rene", Age = 31, Birthday= new DateTime(1991,1,25) },
        new Person() { Name = "Alejandra", Age = 27, Birthday= new DateTime(1995,2,25) }
    };

     if (people.Exists(predicateByName))
        Console.WriteLine("The user exists");
    else
    {
        var result = people.FindAll(predicateByAge);
        var result2 = people.FindAll(predicateByBirthday);
        if (result2.Any())
        {
            Console.WriteLine("Fechas que coinciden: ");
            foreach(var item in result)
            {
                Console.WriteLine(item.Name + " cumple en el "+item.Birthday + ".");
            }
        }
        //if (result.Any())
        //{
        //    Console.WriteLine("We found these names:");
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item.Name+"  "+item.Birthday);
        //    }
        //}
        else
            Console.WriteLine("We didn't find any name with that age.");
    }
}
class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public static bool Exists(Person person)
    {
        return person.Name.Equals(User.Input);
        
    }
    public static bool GetByAge(Person person)
    {
        var isNumber = Int32.TryParse(User.Input, out var age);
        if (isNumber)
            return person.Age.Equals(age);
        else
            return false;
    }

    public static bool GetByDate(Person person)
    {
        var isDate = DateTime.TryParse(User.Input, out DateTime date);
        if (isDate)
        {
            return person.Birthday.Equals(date);
        }
        else
        {
            return false;
        }
    }
}

class User
{
    public static string Input { get; set; }
}