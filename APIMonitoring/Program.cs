var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/Customer", async () =>
{
    int delay = new Random().Next(1000);
    await Task.Delay(delay);

    if (delay > 750)
    {
        return Results.Problem();
    }

    return Results.Ok();
});

app.Run();