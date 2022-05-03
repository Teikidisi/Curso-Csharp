using EFeSop;
using Model;
using Model.Migrations;

using (var context = new AppDbContext())
{
    try
    {
        await AppDbContextSeed.SeedASync(context);
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

var menu = new eShopConsole();
var showMenu = true;
while (showMenu)
{
    showMenu = menu.MainMenu();
}