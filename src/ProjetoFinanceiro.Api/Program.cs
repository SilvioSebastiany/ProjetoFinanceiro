using ProjetoFinanceiro.Infrastructure.Data;
using ProjetoFinanceiro.Application.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Months.Commands;
using ProjetoFinanceiro.Application.Months.Queries;
using ProjetoFinanceiro.Application.Transactions.Commands;
using ProjetoFinanceiro.Application.Transactions.Queries;
using MediatR;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FinanceiroDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFinanceiroDbContext>(sp =>
    sp.GetRequiredService<FinanceiroDbContext>());

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateMonthCommandHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/months", async (
    CreateMonthCommand command,
    IMediator mediator) =>
{
    var result = await mediator.Send(command);
    return Results.Created($"/months/{result.Id}", result);
});

app.MapGet("/months", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetMonthsQuery());
    return Results.Ok(result);
});

app.MapPost("/transactions", async (
    CreateTransactionCommand command,
    IMediator mediator) =>
{
    var result = await mediator.Send(command);
    return Results.Created($"/transactions/{result.Id}", result);
});

app.MapGet("/months/{monthId}/transactions", async (
    Guid monthId,
    IMediator mediator) =>
{
    var result = await mediator.Send(new GetTransactionsByMonthQuery(monthId));
    return Results.Ok(result);
});

app.Run();
