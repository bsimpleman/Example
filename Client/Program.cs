global using BlazorApp1.DTOs.DTOs;
global using BlazorApp1.WebClient.Pages;
using BlazorApp1.WebClient;
using BlazorApp1.WebClient.Services.Car;
using BlazorApp1.WebClient.Services.CarOwner;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Client Services
builder.Services.AddScoped<ICarClient, CarClient>();
builder.Services.AddScoped<IOwnerClient, OwnerClient>();

await builder.Build().RunAsync();
