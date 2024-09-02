using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoDisArq.Persistence;
using ProyectoDisArq.Repositories.Implementations;
using ProyectoDisArq.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebLibreria.Persistence.InitialData;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProyectoDisArq.Utilities;
var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("ProyectoDisArqContext");
builder.Services.AddDbContext<ProyectoDisArqContext>(options =>
    options.UseSqlServer(conectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

//se agregan los repositorios de la unidad de trabajo
builder.Services.AddScoped<IUnitWork, UnitWork>();
////para usar identity con roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddDefaultUI()
        .AddEntityFrameworkStores<ProyectoDisArqContext>();
//se añaden las paginas de razor
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Servicios de datos iniciales
builder.Services.AddScoped<IDbInitialize, DbInitialize>();

var app = builder.Build();

//en caso de tener seeder se agrega esto
using (var scope = app.Services.CreateScope())
{
    //var services = scope.ServiceProvider;
    //SeedData.Initialize(services);
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var inicializar = services.GetRequiredService<IDbInitialize>();
        inicializar.Initialize();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Un erorr ocurrió al ejecutar la migración");
    }
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//indicamos que se usara autenticacion
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Productos}/{action=Home}/{id?}");

app.MapRazorPages();

app.Run();
