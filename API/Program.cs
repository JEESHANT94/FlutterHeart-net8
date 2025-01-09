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

var app = builder.Build();

app.UseRouting(); 

app.MapControllers();

app.Run();
