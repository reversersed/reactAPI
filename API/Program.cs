using API.BLL;
using API.BLL.Interfaces;
using API.DAL.DataAccess;
using API.DAL.DataAccess.Interfaces;
using API.DAL.DataAccess.Repositories;
using API.DAL.Models;
using API.DAL.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(b => b.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod()));
// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(Program));
//Business layer
builder.Services.AddScoped<IMovieManager, MovieManager>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
//Data layer
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using(var scope =  app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    await DataContextSeed.SeedAsync(dataContext);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
