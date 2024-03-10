using BookLibrary.Api.EndpointsDefinition;
using BookLibrary.Repositories;
using BookLibrary.Repositories.Context;
using BookLibrary.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
    serverOptions.ListenAnyIP(443);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ApiEndpoints>();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                         throw new InvalidOperationException("Connection string is not set.")));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiEndpoints = app.Services.GetRequiredService<ApiEndpoints>();
apiEndpoints.MapEndpoints(app);

app.Run();