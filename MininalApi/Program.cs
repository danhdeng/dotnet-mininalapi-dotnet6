using MininalApi.Models;
using MininalApi.Services;

var builder = WebApplication.CreateBuilder(args);

//register the services

builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/create", 
    (CoffeeModel coffee, ICoffeeService service) => {
        var result = service.Create(coffee);
        return Results.Ok(result);
    });

app.MapGet("/get",
    (int id, ICoffeeService service) =>
    {
        var coffee=service.Get(id);
        if (coffee is null) return Results.NotFound("Coffee is not found");
        return Results.Ok(coffee);
    });

app.MapGet("/list",
    (ICoffeeService service) =>
    {
        var coffees = service.List();
        if (coffees is null) return Results.NotFound("No Coffee is found");
        return Results.Ok(coffees);
    });

app.MapPut("/update",
    (CoffeeModel newCoffee, ICoffeeService service) =>
    {
        var updateCoffee = service.Update(newCoffee);
        if (updateCoffee is null) return Results.NotFound("Coffee is not found");
        return Results.Ok(updateCoffee);
    });

app.MapDelete("/delete",
    (int id, ICoffeeService service) =>
    {
        var deleteResult = service.Delete(id);
        if (!deleteResult) return Results.BadRequest("Something went wronng in service call");
        return Results.Ok(deleteResult);
    });



app.Run();
