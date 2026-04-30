using ProjetoFinanceiro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Months;
using ProjetoFinanceiro.Application.Transactions;
using ProjetoFinanceiro.Domain.Entities;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FinanceiroDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/months", async (
    CreateMonthRequest request,
    FinanceiroDbContext db) =>
{
    var month = new Month(request.Label);

    db.Months.Add(month);
    await db.SaveChangesAsync();

    return Results.Created($"/months/{month.Id}", month);
});

app.MapPost("/transactions", async (
    CreateTransactionRequest request,
    FinanceiroDbContext db) =>
{
    var rule = await db.Rules
        .FirstOrDefaultAsync(r =>
            request.Description.ToLower().Contains(r.Keyword.ToLower()));

    // 👇 aqui está o ajuste correto
    var who = rule?.Who ?? WhoType.Unknown;

    var transaction = new Transaction(
        request.Date,
        request.Description,
        request.Amount,
        who,
        request.MonthId
    );

    db.Transactions.Add(transaction);
    await db.SaveChangesAsync();

    return Results.Created($"/transactions/{transaction.Id}", transaction);
});

app.Run();
