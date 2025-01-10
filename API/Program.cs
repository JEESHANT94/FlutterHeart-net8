using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
     opt.EnableSensitiveDataLogging();
}
); // Add your DbContext here

builder.Services.AddCors();
var app = builder.Build();

app.UseRouting(); 
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200")); // Add CORS policy here
app.MapControllers();

app.Run();
