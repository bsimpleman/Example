using BlazorApp1.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PracticeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeDBContext")));

//Manager Services
builder.Services.AddScoped<BlazorApp1.Services.Contracts.ICarManager,
    BlazorApp1.Services.Managers.CarManager>();

builder.Services.AddScoped<BlazorApp1.Services.Contracts.IOwnerManager,
    BlazorApp1.Services.Managers.OwnerManager>();

//Accessor Services
builder.Services.AddScoped<BlazorApp1.DataAccess.Contracts.IOwnerAccessor,
    BlazorApp1.DataAccess.Accessors.OwnerAccessor>();

builder.Services.AddScoped<BlazorApp1.DataAccess.Contracts.ICarAccessor,
    BlazorApp1.DataAccess.Accessors.CarAccessor>();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwaggerUI();
    app.UseSwagger();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
