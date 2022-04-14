namespace LinqExercises;
using static LINQProductList.Product;
using static LINQProductList.Products;
class Program
{
    static void Main(string[] args)
    {
        PrimerElementoSeafood();
        PrecioXCategoria();
        Cantidad();
        PromedioStockBarato();
        MasCaros();
        MasBaratos();
        NombreLargo();
        SumaStock();
        ProductoID80();
        CategoriaPrecio();
        MayorPalabras();



        PrecioMayorTotal();

    }
    // primer elemento de la categoria Seafood
    public static void PrimerElementoSeafood()
    {
        var primerElemento = ProductList
            .Where(element => element.Category == "Seafood").FirstOrDefault();
        Console.WriteLine("Primer Elemento de la categoria Seafood");
        Console.WriteLine($"{primerElemento.ToString()}");
    }
    // Precio promedio de productos por categoria
    public static void PrecioXCategoria()
    {
        var PromedioCategoria = ProductList
            .GroupBy(element => element.Category)
            .Select(group => new
            {
                Categoria = group.Key,
                Total = group.Sum(element => element.UnitPrice),
                Promedio = group.Average(element => element.UnitPrice)
            });
        Console.WriteLine("\nPrecio promedio de productos por categoria");
        foreach(var product in PromedioCategoria)
        {
            Console.WriteLine($"Category: {product.Categoria} Total Price: {product.Promedio}");
        }
    }
    // cantidad de productos
    public static void Cantidad()
    {
        int CantidadProductos = ProductList
            .Select(element => element).Count();
        Console.WriteLine("\nCantidad de productos");
        Console.WriteLine($"Hay {CantidadProductos} productos en total.");
    }
    // stock promedio de los productos que cuestan menos de 12 ordenados por el mas barato
    public static void PromedioStockBarato()
    {
        var PromedioStockBarato = ProductList
            .Where(product => product.UnitPrice < 12)
            .OrderBy(product => product.UnitPrice);
        Console.WriteLine("\nstock promedio de los productos que cuestan menos de 12 ordenados por el mas barato ");
        foreach(var unit in PromedioStockBarato)
        {
            Console.WriteLine($"{unit.ToString()}");
        }
    }
    // top 3 de productos más caros
    public static void MasCaros()
    {
        var MasCaros = ProductList
            .OrderByDescending(product => product.UnitPrice).Take(3);
        Console.WriteLine("\nTop 3 productos mas caros");
        foreach(var unit in MasCaros)
        {
            Console.WriteLine($"{unit.ToString()}");
        }
    }
    // top 3 de productos más baratos
    public static void MasBaratos()
    {
        var MasBaratos = ProductList
            .OrderBy(product => product.UnitPrice).Take(3);
        Console.WriteLine("\nTop 3 productos mas baratos");
        foreach (var unit in MasBaratos)
        {
            Console.WriteLine($"{unit.ToString()}");
        }
    }
    // el producto con el nombre mas largo
    public static void NombreLargo()
    {
        var NombreLargo = ProductList
            .OrderByDescending(name => name.ProductName.Length).Take(1);
        Console.WriteLine("\nEl producto con el nombre mas largo");
        Console.WriteLine($"{NombreLargo.First().ToString()}");
    }
    // suma de stock general
    public static void SumaStock()
    {
        var sumaStock = ProductList
            .Sum(element => element.UnitsInStock);
        Console.WriteLine("\nSuma de Stock en general");
        Console.WriteLine($"El total de stock es {sumaStock}");
    }
    // traer el nombre del producto con el id 80
    public static void ProductoID80()
    {
        var ID80 = ProductList
            .Where(element => element.ProductID == 80).Select(element => element.ProductName).FirstOrDefault();
        Console.WriteLine("\nTraer el nombre del producto con el id 80");
        Console.WriteLine($"El producto con ID 80 es {ID80}");
    }
    // listado ordenado por la categoria y luego por el precio
    public static void CategoriaPrecio()
    {
        var categoriaPrecio = ProductList
            .OrderBy(unit => unit.UnitPrice)
        .GroupBy(element => element.Category)
        .OrderBy(group => group.Key);
        // o usar orderby Category y luego thenby unitprice
        Console.WriteLine("\nOrdenado por categoria y precio");
        foreach(var unit in categoriaPrecio)
        {
            Console.WriteLine($"{unit.Key}");
            foreach (var a in unit)
            {
                Console.WriteLine($"{a}");
            }
        }
    }

    // el producto con mayor cantidad de palabras
    public static void MayorPalabras()
    {
        var MayorPalabras = ProductList
            .OrderByDescending(name => name.ProductName.Split(" ").Length).Take(1);
        Console.WriteLine("\nEl producto con la mayor cantidad de palabras");
        foreach(var producto in MayorPalabras)
        {
            Console.WriteLine($"{producto.ToString()}");
        }
    }

    // el producto que su precio total sea el mayor multiplicando su precio unitario por la cantidad en stock
    public static void PrecioMayorTotal()
    {
        var preciomayor = ProductList
            .OrderByDescending(unit => unit.UnitPrice * unit.UnitsInStock)
            .Select(unit => new
            {
                Name = unit.ProductName,
                Total = unit.UnitPrice * unit.UnitsInStock
            }).FirstOrDefault();
        Console.WriteLine("\nProducto con mayor ganancia actual posible");
        Console.WriteLine($"{preciomayor.Name} + {preciomayor.Total}");
    }

}

























