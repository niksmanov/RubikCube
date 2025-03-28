using Microsoft.AspNetCore.Diagnostics;
using RubikCube.Application.Services;
using Swashbuckle.AspNetCore.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.ExampleFilters();
});

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddSwaggerExamplesFromAssemblies(assembly);
    builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(assembly));
}

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

//Services
builder.Services.AddScoped<IProcessCubeService, ProcessCubeService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(exceptionFeature?.Error.Message ?? "Bad Request: Invalid input");
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
