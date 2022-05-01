var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/Customer", async () =>
{
    int latency = new Random().Next(1000);
    await Task.Delay(latency);

    if (latency > 750)
    {
        return Results.Problem();
    }

    return Results.Ok();
});

app.Run();