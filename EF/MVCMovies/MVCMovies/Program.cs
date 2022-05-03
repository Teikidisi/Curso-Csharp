using Microsoft.EntityFrameworkCore;
using MVCMovies.Data;
using MVCMovies.Services;
using MVCMovies.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using MVCMovies.Models;
using MVCMovies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Pages";
    options.Conventions.AuthorizeFolder("/Pages/Admin");
});
//habilita la lectura de API endpoints y sus descripciones
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();

//ciclo de vida de los servicios
//crear una instancia del servicio cada vez que alguna dependencia lo requiera
//builder.Services.AddScoped<IActorService, ActorService>();
//Crear una instancia para cada petición
builder.Services.AddTransient<IActorService, ActorService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IMovieArticleService, MovieArticleService>();

//Crear una instancia al ejecutar el sistema
//builder.Services.AddSingleton<IActorService, ActorService>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
});

//la cache ayuda a agilizar nuestro sistema con informacion que no es necesaria que este actualizada al momento reduciendo
//las peticiones que se hacen a la base de datos.
builder.Services.AddMemoryCache();

//construir la app, toda la configuracion va arriba del builder
var app = builder.Build();

//solicitaremos una instancia de los servicios necesarios para nuestros datos semilla al proveedor de servicios
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetService<RoleManager<IdentityRole>>();
    await DataSeeder.SeedRolesAsync(roleManager);
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    //dejar que la vista de swagger sea visible solo cuando estemos corriendo el sistema de manera local
    //para evitar que el publico pueda estar viendo los endpoints y probarlos
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies-API v1");
        options.RoutePrefix = "swagger";
    });

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
