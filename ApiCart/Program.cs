using ApiCart.Models;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

//instanciando o repositório em memória.
var repositorio = new Repositorio();

app.MapPost("/AdicionarItem/{idCarrinho}", (int idCarrinho, Item item) => {

    var results = repositorio.AdicionarItem(idCarrinho, item);

    return results != null ? Results.Ok(results) : Results.NotFound();
});

app.MapGet("/ListarTodosCarrinhos",() => {

    var results = repositorio.ListarTodosCarrinho();

    return results != null ? Results.Ok(results) : Results.NotFound();
});

app.MapGet("/ListarItensCarrinho/{idCarrinho}",(int idCarrinho) => {
    
    var results = repositorio.ListarItensCarrinho(idCarrinho);

    return results != null ? Results.Ok(results) : Results.NotFound();
});

app.MapDelete("/DeletarItemCarrinho/{idCarrinho}/{idItem}", (int idCarrinho, Guid idItem) => {

    var results = repositorio.DeleteItensCarrinho(idCarrinho, idItem);

    return results != false ? Results.Ok(results) : Results.NotFound();
});

app.MapDelete("DeletarCarrinho/{idCarrinho}", (int idCarrinho) =>{

    var results =  repositorio.DeleteCarrinho(idCarrinho);

    return results != false ? Results.Ok(results) : Results.NotFound();
});

app.MapGet("/FinalizarCarrinho/{idCarrinho}", (int idCarrinho) =>{

    var results = repositorio.FinalizarCarrinho(idCarrinho);

    return results != null ? Results.Ok(results) : Results.NotFound();
});

app.Run();
