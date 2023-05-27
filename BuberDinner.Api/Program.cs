using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Api.Middleware;
using BuberDinner.Api.Fillters;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Error 2
// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAplication()
                .AddInfrastructure(builder.Configuration);

// Error 3
// builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

// Error 4 --> ErrorController

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Error 1
// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

// Minimal Error endpoint
app.Map("/error", (HttpContext httpContext) =>
{
    Exception exception = httpContext.Features.Get<Exception>();

return Results.Problem(statusCode: 400);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
