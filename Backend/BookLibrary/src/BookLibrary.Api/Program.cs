using BookLibrary.Api.EndpointsDefinition;
using BookLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApiEndpoints>();
builder.Services.AddSingleton<IBookService, BookService>();

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