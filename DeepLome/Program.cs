using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var context = new TrashFindersDBContext();
var userRepo = new UsersRepository(context);

// Выключено для работы с Ngrok
//app.UseHttpsRedirection();

app.MapGet("/size_of_trash", () =>
{
    return Math.PI;
})
.WithName("SizeOfTrash");

app.MapGet("/users", () =>
{
    return userRepo.GetAll();
})
.WithName("Users");

app.MapGet("/trash", () =>
{
    return Math.PI;
})
.WithName("Trash");

app.MapGet("/events", () =>
{
    return Math.PI;
})
.WithName("Events");



app.Run();