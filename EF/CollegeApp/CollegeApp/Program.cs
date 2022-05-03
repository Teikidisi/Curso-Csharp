﻿
using CollegeApp;
using Model;

using (var context = new AppDbContext())
{
    try
    {
        await AppDbContextSeed.SeedAsync(context);
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

var menu = new Menu();
var showMenu = true;

while (showMenu)
{
    showMenu = menu.Show();
}