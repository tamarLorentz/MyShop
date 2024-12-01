using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Resources;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiManagerContext>(options => options.UseSqlServer
("Data Source = SRV2\\PUPILS; Initial Catalog = API_manager; Integrated Security = True"));

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserResources, UserResources>();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
