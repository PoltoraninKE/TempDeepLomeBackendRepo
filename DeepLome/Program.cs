using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using DeepLome.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Выключать для работы с Ngrok
// app.UseHttpsRedirection();

#region This things should be in DI
var context = new TrashFindersDBContext();
var _userRepository = new UsersRepository(context);
var _eventRepository = new EventRepository(context);
var _trashRepository = new TrashRepository(context);
var _sizeRepository = new SizeRepository(context);
//var _userService = new UserService(_userRepository);
#endregion

#region HealthCheck
app.MapGet("/health_check", () =>
{
    return Results.Ok();
})
.WithName("HealthCheck");
#endregion

#region Size of trashes
app.MapGet("/size_of_trash", () =>
{
    try 
    {
        return Results.Ok(_sizeRepository.GetAll());
    }
    catch(Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
.WithName("Get all sizes of trash");
#endregion

#region Users
app.MapPost("/add_user", ([FromBody] User user) =>
{
    try
    {
        _userRepository.Add(user);
        return Results.Ok("User was added");
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Add new user");

// Пока временное решение, там дальше будем посмотреть
app.MapDelete("/delete_user", ([FromBody] User user) => 
{
    try 
    {
        _userRepository.Delete(user);
        return Results.Ok("User was deleted");
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Delete user");

app.MapPut("/update_user", ([FromBody] User user) =>
{
    try
    {
        _userRepository.Update(user);
        return Results.Ok("User was updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Update existing user");

app.MapGet("/get_all_users", () =>
{
    return _userRepository.GetAll();
})
.WithName("Get all users");

app.MapGet("/get_user/{id:int}", (int id) =>
{
    try
    {
        return Results.Ok(_userRepository.GetById(id));
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Get user by id");

app.MapGet("/get_user/{name}", (string name) =>
{
    try
    {
        return Results.Ok(_userRepository.GetByName(name));
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
  .WithName("Get user by FirstName");


app.MapGet("/is_user_registered/{id:int}", (int id) =>
{
    return Results.Ok();
    //_userService.IsUserRegistered(id);
})
  .WithName("Check is user registered in system");

#endregion

#region Trashes

app.MapGet("/add_trash", ([FromBody] Trash trash) =>
{
    try
    {
        _trashRepository.Add(trash);
        return Results.Ok("Trash was added");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
.WithName("Add trash");

app.MapDelete("/delete_trash", ([FromBody] Trash trash) =>
{
    try 
    {
        _trashRepository.Delete(trash);
        return Results.Ok("Trash was deleted");
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Delete trash");

app.MapPut("/update_trash", ([FromBody] Trash trash) =>
{
    try 
    {
        _trashRepository.Update(trash);
        return Results.Ok("Trash was updated");
    }
    catch(Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Update trash");

app.MapGet("/get_all_trash", () => 
{
    try
    {
        return Results.Ok(_trashRepository.GetAll());
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Get all trashes");

app.MapGet("/get_trash/{id}", (int id) =>
{
    try
    {
        return Results.Ok(_trashRepository.GetById(id));
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Get trash by id");

#endregion

#region Events
app.MapGet("/add_event", ([FromBody] Event event_) =>
{
    try
    {
        _eventRepository.Add(event_);
        return Results.Ok("Event was added");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
.WithName("Add Event");

app.MapDelete("/delete_event", ([FromBody] Event event_) =>
{
    try
    {
        _eventRepository.Delete(event_);
        return Results.Ok("Event was deleted");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Delete event");

app.MapPut("/update_event", ([FromBody] Event event_) =>
{
    try
    {
        _eventRepository.Update(event_);
        return Results.Ok("Event was updated");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Update event");

app.MapGet("/get_all_event", () =>
{
    try
    {
        return Results.Ok(_eventRepository.GetAll());
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Get all events");

app.MapGet("/get_event/{id}", (int id) =>
{
    try
    {
        return Results.Ok(_eventRepository.GetById(id));
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
 .WithName("Get event by id");
#endregion

app.MapPost("/try_in_photo", ([FromBody] byte[] photoAsByteArray) => 
{
    try
    {
        ImageConverter.SaveImage(photoAsByteArray);
    }
    catch (Exception ex) 
    {
        throw new Exception(ex.Message);
    }
})
 .WithName("Convert image");

app.Run();