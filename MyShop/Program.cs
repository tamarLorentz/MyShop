using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyShop.Middlewares;
using NLog.Web;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<ApiManagerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchooleConnection")));
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRatingServices, RatingServices>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Host.UseNLog();
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
app.UseErrorHandlingMiddleware();
app.UseRatingMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();




