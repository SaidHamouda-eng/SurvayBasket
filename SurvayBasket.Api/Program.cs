
using SurvayBasket.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "My API"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
