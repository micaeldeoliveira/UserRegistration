using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Handlers;
using UserRegistration.Domain.Repositories;
using UserRegistration.Infra.Contexts;
using UserRegistration.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
  builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserHandler>();


var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
