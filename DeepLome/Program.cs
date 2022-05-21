using DeepLome.Models.Interfaces;
using DeepLome.Models.Interfaces.Repositories;
using DeepLome.Models.Repositories;
using DeepLome.Services.Services;
using DeepLome.WebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserRepository, UsersRepository>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IEventService, EventService>();

builder.Services.AddDbContext<TrashFindersContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("TrashFinderDBConnection"));
});

// Как получать модель, в которой есть byteArray

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

// Выключать для работы с Ngrok
// app.UseHttpsRedirection();

#region This things should be in DI
var context = new TrashFindersContext();
//var _userService = new UserService(_userRepository);
#endregion

app.Run();