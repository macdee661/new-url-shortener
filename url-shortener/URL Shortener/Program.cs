using urlshorterner.Services;  // <-- Add this line


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<URLMappingDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddControllers();
builder.Services.AddScoped<URLMappingService>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapControllerRoute(name: "create", pattern: "{controller=Create}/{action=Index}/{longUrl?}");

app.MapControllerRoute(name: "retrive", pattern: "{controller=Retrive}/{action=Index}/{shortUrl?}");


app.Run();