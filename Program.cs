using JoseRivera_Ap1_p1.Components;
using JoseRivera_Ap1_p1.DAL;
using JoseRivera_Ap1_p1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//La Inyectar el contexto
var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(o => o.UseSqlite(ConStr));

//La inyeccion del services
builder.Services.AddScoped<PrestamosServices>();

//La inyeccion del services
builder.Services.AddScoped<CobrosServices>();

builder.Services.AddScoped<DeudoresServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
