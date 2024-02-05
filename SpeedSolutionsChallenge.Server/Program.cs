using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.DBContext;
using SpeedSolutionsChallenge.Data.Repositories.DispenserRepository;
using SpeedSolutionsChallenge.Data.Repositories.HoseRepository;
using SpeedSolutionsChallenge.Data.Repositories.PriceRepository;
using SpeedSolutionsChallenge.Data.Repositories.ProductRepository;
using SpeedSolutionsChallenge.Server.Services.DispenserService;
using SpeedSolutionsChallenge.Server.Services.HoseService;
using SpeedSolutionsChallenge.Server.Services.PriceService;
using SpeedSolutionsChallenge.Server.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<IDispenserRepository, DispenserRepository>();
builder.Services.AddScoped<IHoseRepository, HoseRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<IDispenserService, DispenserService>();
builder.Services.AddScoped<IHoseService, HoseService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
