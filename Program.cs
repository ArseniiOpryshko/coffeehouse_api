using coffeehouse_api.Data.ProductRepos;
using coffeehouse_api.Data.UserRepos;
using Microsoft.EntityFrameworkCore;
using Museum.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoffeeHouseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeHouseContext")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
   .SetIsOriginAllowed(_ => true)
   .AllowAnyMethod()
   .AllowAnyHeader()
   .AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
