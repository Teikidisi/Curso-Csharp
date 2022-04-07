
var polygon = new Polygon(10,20);
Polygon polygon2 = new Polygon(10);
//polygon.Base = 10; //metodo alternativo cuando no tienes el constructor
//polygon.Height = 20;

var square = new Square(10);
Rectangle rectangle = new Rectangle(10, 30);

Console.WriteLine(polygon.Base);
Console.WriteLine(polygon.GetArea());
Console.WriteLine(rectangle.GetArea());

public class Polygon
{
    public decimal Base { get; set; }
    public decimal Height { get; set; }

    public Polygon(decimal basep, decimal height)
    {
        Base = basep;
        Height = height;
    }

    public Polygon(decimal height) //Crear otro constructor con un solo parametro, por si se necesita trabajar datos distintos
    {
        Height = height;
    }
    public Polygon() { } //constructor que no usa parametros, asi cada clase heredada usa sus propios parametros

    public virtual decimal GetArea()
    {
        return Base * Height;
    }

    public static void Show() //una clase static no necesita que la clase sea instaciada para ejecutarse. Polygon.Show() vs polygon.GetArea()
    {

    }
}

class Square : Polygon
{
    public Square(decimal basep) //Heredar todos los parametros de la clase base, constructor de 0, para no usar los parametros de clase padre
    {
        Base = basep;
        Height = basep;
    }

    //public Square(decimal basep) //this agarra la variable Base de la clase padre y le guarda lo que el hijo dice
    //{
    //    this.Base = basep;
    //}
}

class Rectangle : Polygon
{
    public Rectangle(decimal basep, decimal height) : base(basep,height) //Usar el constructor de dos parametros
    {
        Base = basep;
        Height = height;
    }
}