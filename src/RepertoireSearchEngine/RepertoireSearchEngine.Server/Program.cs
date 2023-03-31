using Microsoft.Extensions.Options;
using RepertoireSearchEngine.Server;
using RepertoireSearchEngine.Server.Options;
using RepertoireSearchEngine.Server.Services.Interfaces;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ICinemaService, CinemaService>();

builder.Services.Configure<RepertoireServiceOptions>(builder.Configuration.GetSection("RepertoireService"));
builder.Services.AddHttpClient<ICinemaService, CinemaService>((serviceProvider, client) =>
{
    var options = serviceProvider.GetRequiredService<IOptions<RepertoireServiceOptions>>();
    client.BaseAddress = new Uri(options.Value.BaseUrl);
});

builder.Services.AddSingleton(new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true,
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
