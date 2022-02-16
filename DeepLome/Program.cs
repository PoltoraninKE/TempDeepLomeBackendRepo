using DeepLome.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Выключено для работы с Ngrok
//app.UseHttpsRedirection();

var dbContext = new TrashFindersDBContext();

app.MapGet("/size_of_trash", () =>
{
    return dbContext.Sizes;
})
.WithName("SizeOfTrash");

app.MapGet("/users", () =>
{
    return dbContext.Users;
})
.WithName("Users");

app.MapGet("/trash", () =>
{
    return dbContext.Trashes;
})
.WithName("Trash");

app.MapGet("/events", () =>
{
    return dbContext.Events;
})
.WithName("Events");



app.Run();