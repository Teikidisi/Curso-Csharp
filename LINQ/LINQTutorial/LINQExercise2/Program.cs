// C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
// C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
// C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };


//C.1
//var sorteado = arr1.OrderBy(x => x).Distinct().ToArray();
var sorteado = arr1.GroupBy(c => c).Select(group => new
{
    Number = group.Key,
    Frequency = group.Count()
});

foreach(var num in sorteado)
{
    //int count = 0;
    //foreach(var num2 in arr1)
    //{
    //    if(num2 == num)
    //    {
    //        count++;
    //    }
    //}
    Console.WriteLine($"El num {num.Number} ha aparecido {num.Frequency}");
}

//C.2
var SinRepetir = arr1.Distinct();
Console.WriteLine("\nlista sin repetir: ");
foreach (var num in SinRepetir)
{
    Console.Write(num+" ");
}

Console.WriteLine("\n");
//c.3
var sorteado2 = arr1.GroupBy(c => c).Select(group => new
{
    Number = group.Key,
    Frequency = group.Count(),
    Multiply = group.Key * group.Count()
});
//var sorteado2 = arr1.OrderBy(x => x).Distinct().ToArray();
foreach (var num in sorteado2)
{
    //int count = 0;
    //foreach (var num2 in arr1)
    //{
        
    //    if (num2 == num)
    //        count++;
    //}
    Console.WriteLine($"El num {num.Number} ha aparecido {num.Frequency}, y su multiplicacion es {num.Multiply}");
}

// D.1 Get the top student of the list making an average of their scores.
// D.2 Get the student with the lowest average score.
// D.3 Get the last name of the student that has the ID 117
// D.4 Get the first name of the students that have any score more than 90

//d1 y d2
List<Student> students = new List<Student>
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
Console.WriteLine("\n");
var topStudent = students
    .OrderByDescending(student => student.Scores.Average())
    .Select(top => new
    {
        Student = top.FirstName+" "+top.LastName,
        Score = top.Scores.Average()
    });
var x = topStudent.ToArray();
Console.WriteLine(x[0].Student+"es el mejor con promedio de"+x[0].Score);
Console.WriteLine(x[x.Length-1].Student + "es el peor con promedio de" + x[x.Length-1].Score);

//d3
Console.WriteLine("\nSu id es 117: ");
var studentID = students
    .Find(student => student.ID == 117);
Console.WriteLine(studentID.FirstName + " " + studentID.LastName);

Console.WriteLine("\nEstos tienen una calif mayor a 90");
var mas90 = students.Where(student => student.Scores.Any(score => score > 90));
foreach(var student in mas90)
{
    Console.WriteLine($"{student.FirstName} {student.LastName}");
}
class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public List<int> Scores { get; set; }

}