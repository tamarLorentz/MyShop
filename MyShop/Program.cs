using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Resources;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiManagerContext>(options => options.UseSqlServer
("Data Source = SRV2\\PUPILS; Initial Catalog = API_manager; Integrated Security = True;TrustServerCertificate=True"));

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserResources, UserResources>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
