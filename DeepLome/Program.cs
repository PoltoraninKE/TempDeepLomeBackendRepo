using System.Text.Json;
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

builder.Services.AddDbContext<TrashFindersContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("TrashFinderDBConnection"));
});

// ��� �������� ������, � ������� ���� byteArray

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

// ��������� ��� ������ � Ngrok
// app.UseHttpsRedirection();

#region This things should be in DI
var context = new TrashFindersContext();
//var _userService = new UserService(_userRepository);
#endregion

app.Run();