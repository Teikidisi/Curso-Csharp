class Program
{
    private static List<Student> students = new List<Student>
{
    new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
    new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
};

    //Codigo placeholder usado en CNET5.0 y abajo
    static void Main(string[] args)
    {
        int[] scores = { 97, 76, 95, 67, 45 };

        IEnumerable<int> scoreQuery = from score in scores
                         where score > 70
                         select score * score; //almacena todo en una IEnumerable scoreQuery, debes iterarla para encontrar el valor
                                               //se pueden hacer operaciones, y cadenas de texto que regresar $"{}"

        //foreach(var i in scoreQuery)
        //{
        //    Console.WriteLine(i+" ");
        //}
        //USANDO LINQ y Lambda para hacer los querys
        var scoreQueryLambda = scores
            .Where(score => score > 70)
            .Select(score => score * score);

        //seleccionando valores y usando orden que se desea ver
        //Var = IOrderedEnumerable
        var studentQuery = from student in students
                           where student.Scores[0] > 90 && student.Scores[3] < 80
                           orderby student.Scores[0] descending
                           select student;
        foreach(var student in studentQuery)
        {
        string calific = "";
            foreach(var score in student.Scores)
            {
                calific += score + " ";
            }
            Console.WriteLine(student.LastName + " " + student.FirstName + " " + calific);
        }
        //El order by se ejecuta por medio de metodos distintos
        var studentQueryLambda = students
            .Where(student => student.Scores[0] > 90 && student.Scores[3] < 80)
            .OrderByDescending(student => student.Scores[0]);

        //agrupando los elementos usando group by 
        var studentQuery2 = from student in students
                            group student by student.LastName[0]
                            into studentGroup
                            orderby studentGroup.Key
                            select studentGroup;
        foreach(var studentGroup in studentQuery2)
        {
            Console.WriteLine(studentGroup.Key);
            foreach(var student in studentGroup)
            {
                Console.WriteLine($"Nombre: {student.LastName} Apellido: {student.FirstName}");
            }
        }

        var studentQueryLambda2 = students
            .GroupBy(student => student.LastName[0])
            .OrderBy(group => group.Key);

        //se puede utilizar linq para realizar operaciones dentro de la comparacion y ademas regresar el
        //valor deseado ya formateado
        var studentQuery3 = from student in students
                            let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                            where totalScore / 4 < student.Scores[0]
                            select $"{student.FirstName} {student.LastName}";
        //foreach(var student in studentQuery3)
        //{
        //    Console.WriteLine(student);
        //}

        var studentQueryLambda3 = students
            .Where(student => (student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]) /4 < student.Scores[0])
            .Select(student => $"{student.FirstName} {student.LastName}");

        //Invocar metodos SUM() en vez de tener que sumar todo manualmente en el let
        var studentQuery4 = from student in students
                            let totalScore = student.Scores.Sum()
                            where totalScore / 4 < student.Scores[0]
                            select $"{student.FirstName} {student.LastName}";
        //foreach (var student in studentQuery4)
        //{
        //    Console.WriteLine(student);
        //}

        var studentQueryLambda4 = students
            .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
            .Select(student => $"{student.FirstName} {student.LastName}");


        var studentQuery5 = from student in students
                            let totalScore = student.Scores.Average()
                            where totalScore < student.Scores[0]
                            select $"{student.FirstName} {student.LastName}";
        //foreach (var student in studentQuery5)
        //{
        //    Console.WriteLine(student);
        //}

        var studentQueryLambda5 = students
            .Where(student => student.Scores.Average() < student.Scores[0])
            .Select(student => $"{student.FirstName} {student.LastName}");

        //sacar el promedio general de toda la clase
        var promedio = students.Average(student => student.Scores.Average());

        //tambien se pueden hacer consultas LINQ con variables externas a ellas
        var lastName = "Garcia";
        var studentQuery6 = from student in students
                            where student.LastName.Equals(lastName)
                            select student.FirstName;
        Console.WriteLine("\nTodos los Garcias de las clases son: ");
        Console.WriteLine(String.Join(",\t", studentQuery6));

        var studentQueryLambda6 = students
            .Where(student => student.LastName.Equals(lastName))
            .Select(student => student.FirstName);
        

        //Crear tambien nuevos objetos a partir de nuestra consulta
        //En este te regresa la gente que su promedio individual sea mayor al promedio de la clase entera
        //Crea un nuevo objeto con el ID y el Score
        var studentQuery7 = from student in students
                            let totalScore = student.Scores.Average()
                            where totalScore > promedio
                            select new { ID = student.ID, Score = totalScore };
        Console.WriteLine($"promedio de clase: {promedio}");
        foreach(var item in studentQuery7)
        {
            Console.Write($"Student ID: {item.ID} Score: {item.Score}");
            var IDName = students.SingleOrDefault(student => student.ID == item.ID);
            Console.WriteLine($" Last Name: {IDName.LastName}");
        }

        var studentQueryLambda7 = students
            .Where(student => student.Scores.Average() > promedio)
            .Select(student => new
            {
                ID = student.ID,
                Score = student.Scores.Average()
            });

        
        //Conseguir estudiantes donde cada valor de SCORES sea mayor a 80
        var studentQueryLambda8 = students
            .Where(student => student.Scores.All(score => score > 80))
            //Regresa donde se cumpla la condicion en todos los scores
            .OrderByDescending(student => student.Scores[0]);
        foreach (var student in studentQueryLambda8)
        {
            Console.WriteLine(student.FirstName);
        }

        var primerEstudianteFiltrado = studentQueryLambda8.FirstOrDefault();
        Student primerEstudianteFiltradoSinResultados = studentQueryLambda8
            .Where(c => c.ID > 1000)
            .FirstOrDefault();
        Student primerEstudianteFiltradoSinResultadosReducido = studentQueryLambda8
            .FirstOrDefault(c => c.ID > 1000);
        Student single = studentQueryLambda8
            .SingleOrDefault(c => c.ID == 101);
        Console.WriteLine(primerEstudianteFiltradoSinResultados == null ? "es nulo" : primerEstudianteFiltradoSinResultados.FirstName);

        var ultimoEstudianteFiltrado = studentQueryLambda8.Last();

    }
    //Aqui van nuevos metodos aparte de MAIN
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public List<int> Scores { get; set; }

}