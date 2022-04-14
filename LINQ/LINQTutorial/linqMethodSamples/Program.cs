

//distinct traera solo un elemento unico, elimina repetidos
int[] factoriales = { 2, 2, 3, 5, 5 };
int factorialesUnicos = factoriales.Distinct().Count();
Console.WriteLine($"Hay {factorialesUnicos} factoriales unicos");

//suma de elementos
int[] numbers = { 5, 4, 1, 4, 6, 34 };
double numSum = numbers.Sum();
Console.WriteLine($"La suma de elementos es: {numSum}");

//min value y max value
int[] numbers2 = { 5, 4, 1, 4, 6, 34 };
int minNum = numbers.Min();
int maxNum = numbers.Max();

Console.WriteLine($"El numero mas chico es: {minNum}");
Console.WriteLine($"El numero mas grande es: {maxNum}");

//proyecciones en min y max
string[] words = { "cherry", "apple", "banana" };
int shortestWord = words.Min(w => w.Length);
int longestWord = words.Max(w => w.Length);
Console.WriteLine($"La palabra más corta tiene {shortestWord} letras");
Console.WriteLine($"La palabra más larga tiene {longestWord} letras");

//hacer un linq que agarre solo el valor mas chico. OrderBY, y agarrar el valor [0] de la lista

//promedio de un listado
double averageNum = numbers.Average();
Console.WriteLine($"El promedio es {averageNum}");

//proyecciones en average
double averageLength = words.Average(w => w.Length); //se usa lambda porque Length es para enteros, asi que a calcular las letras de cada palabra
Console.WriteLine($"El promedio de caracteres es: {averageLength}");

double[] doubles = { 1.4, 5.3, 5.2, 6.4 };
var sortedDoubles = doubles.OrderBy(d => d);
double[] doublesArray = sortedDoubles.ToArray();

for (int i = 0; i < doublesArray.Length; i++)
{
    Console.Write($" {doublesArray[i]} ");
}
Console.WriteLine();
List<double> doublesList = sortedDoubles.ToList();
foreach(var d in doublesList)
    Console.WriteLine(d);

//conversion a diccionarios
var scoreRecord = new[]
{
    new {Name = "Alice", Score = 50},
    new {Name = "Bob", Score = 40 },
    new {Name = "Cathy", Score = 45}
};
var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);
Console.WriteLine("Bob's score: {0}", scoreRecordDict["Bob"].Score);

//convertir datos obtenidos
object[] numbersObject = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d };
var doublesObjects = numbersObject.OfType<double>();
foreach(var d in doublesObjects)
{
    Console.WriteLine(d);
}

//un elemento del listado
string[] strings = { "zero", "one", "two", "three", "four", "five" };
string theFirstOne = strings.First();
string theOne = strings.First(c => c == "one");
Console.WriteLine($"El primer elemento del array es {theFirstOne}");
Console.WriteLine($"El primer elemento que coincida con 'one' es {theOne}");

//tal vez exista un elemento del listado
string[] strings2 = { };
var maybeTheFirstOne = strings2.FirstOrDefault(one => one == "one");

//si el listado no tiene el valor y se quiere regresar un valor default:
//Si sí lo tiene entonces regresa el First valor que coincida
var FirstOneEmpty = strings2.DefaultIfEmpty("esta vacia la lista").First();

int[] numbers3 = { 5, 4, 1, 4, 6, 34 };
var inPosition = numbers3.ElementAt(2);
Console.WriteLine("Numero en la posicion 2 es: "+inPosition);

//ordenamiento de listados
var sortedStringsAsc = strings.OrderBy(c => c);
var sortedStringsDesc = strings.OrderByDescending(c => c);
var sortedMultipleTimes = strings.OrderBy(c => c[0]) //ordena por alfabetico(nomas primer caracter)
    .ThenBy(c => c.Length);//ya en alfabetico ordena por tamaños
Console.WriteLine("Sorteado alfabetico y luego longitud");
foreach(var a in sortedMultipleTimes)
{
    Console.WriteLine(a);
}
foreach(var b in sortedStringsAsc)
{
    Console.WriteLine("El orden asc es: "+b);
}
foreach(var c in sortedStringsDesc)
{
    Console.WriteLine("El orden desc es :"+c);
}

//ordenar al reves
var sortedReverse = strings.Reverse();
Console.WriteLine("El orden al reves: ");
foreach (var a in sortedReverse)
{
    Console.WriteLine(a);
}

//particiones en una lista
int[] numbers4 = { 5, 4, 1, 4, 6, 4, 8, 9, 0 };
var first3Numbers = numbers4.Take(3);
Console.WriteLine("los primeros 3 numeros: ");
foreach(int a in first3Numbers)
{
    Console.WriteLine(a);
}

//Te esta regresando valores hasta que la condicion no se cumpla,
////los valores que estén despues del primer falso ya no son considerados
// te regresará 5,4
var takeWhile = numbers4.TakeWhile(c => c > 3);
Console.WriteLine("Tomará todos los que tengan la condicion verdadera (num mayor a 3): ");
foreach(var number in takeWhile)
{
    Console.WriteLine(number);
}

var allButFirst4Numbers = numbers4.Skip(4);
Console.WriteLine("Los elementos despues de los primeros 4 son: ");
foreach(int number in allButFirst4Numbers)
{
    Console.WriteLine(number);
}

//Salta e ignora los valores que si cumplan con la condicion, cuando encuentra uno que no cumple,
//te regresa ese valor y todos los que le seguian en la lista a los cuales no alcanzó a llegar
//te regresará  1, 4, 6, 4, 8, 9, 0. Es el inverso del TakeWhile
var skipWhile = numbers4.SkipWhile(c => c > 2);
Console.WriteLine("Los elementos que no cumplieron la condicion ser > a 2 son: ");
foreach(var number in skipWhile)
    Console.WriteLine(number);

//Proyecciones
//Crear un listado a partir de una clase anonima
var selectList = strings.Select(c => new { Length = c.Length, Word = c });
//Creamos un listado a partir de una clase definida
var selectListWithEntity = strings.Select(c => new MyWord { Length = c.Length, Word = c });
foreach(var str in selectListWithEntity)
{
    Console.WriteLine($"La palabra: {str.Word} tiene {str.Length}");
}

//contains
//regresa un booleano si la condicion se cumple
var siExisteZero = strings.Contains("zero");

//ANY se cumple si cualquier elemento es igual a three
var esEqualAThree = strings.Any(c => c.Equals("three"));

//concat
int[] nums1 = { 1, 2, 3 };
int[] nums2 = { 4, 5, 6 };
foreach(var n in nums1.Concat(nums2))
{
    Console.WriteLine(n);
}

internal class MyWord
{
    public int Length { get; set; }
    public string Word { get; set; }
}


