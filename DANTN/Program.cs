using DANTN.Data.EF;
using DANTN.Extensions;
using DANTN.Utils.FileStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultDb") ?? throw new InvalidOperationException("Connection string 'DefaultDb' not found."),
    providerOptions => providerOptions.EnableRetryOnFailure())
);
services.AddCors(options =>
      {
        options.AddPolicy("MyPolicy", builder =>
          {
             //"http://127.0.0.1:5500", "https://localhost:5500", "http://127.0.0.1:5173", "http://localhost:5173"
              builder.WithOrigins()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
          });
      });

builder.Services.AddTransient<IFileStorageService, FileStorageService>();

services.Configure<ApiBehaviorOptions>(options =>
{
  options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.
services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Canary", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization(); // Add it here

app.UseSwagger();

app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Canary V1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
