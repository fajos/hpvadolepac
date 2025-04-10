using HPV_ADOLEPAC_6._0.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    // get the service providers
    var service = scope.ServiceProvider;
    try
    {
        var serviceProvider = service.GetRequiredService<IServiceProvider>();
        // get the Config object for the appsettings.json file 
        var config = service.GetRequiredService<IConfiguration>();

        // Calling the static method created by us
        // pass the service proiders and the config object to CreateRoles()
        SeedRoles.CreateRoles(serviceProvider, config).Wait();
    }
    catch (Exception exception)
    {
        var logger = service.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occurred while creating roles");
    }
}
app.Run();


