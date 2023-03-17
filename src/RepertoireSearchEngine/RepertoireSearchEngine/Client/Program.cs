using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RepertoireSearchEngine.Client;
using RepertoireSearchEngine.Client.Helpers;
using RepertoireSearchEngine.Client.Services;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<IAlertService, AlertService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();

// configure http client
builder.Services.AddScoped(x => {
    var apiUrl = new Uri(builder.Configuration["apiUrl"]);

    // use fake backend if "fakeBackend" is "true" in appsettings.json
    if (builder.Configuration["fakeBackend"] == "true")
    {
        var fakeBackendHandler = new FakeBackendHandler(x.GetService<ILocalStorageService>());
        return new HttpClient(fakeBackendHandler) { BaseAddress = apiUrl };
    }

    return new HttpClient() { BaseAddress = apiUrl };
});

var host = builder.Build();

var accountService = host.Services.GetRequiredService<IAccountService>();
await accountService.Initialize();

await builder.Build().RunAsync();
