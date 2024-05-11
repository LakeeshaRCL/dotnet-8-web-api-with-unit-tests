using DotnetWebApiUnitTesting;
using DotnetWebApiUnitTesting.Helpers;
using DotnetWebApiUnitTesting.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>();

// read database properties from appsettings file
GlobalAttributesHelper.mySqlConfiguration.connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
GlobalAttributesHelper.mySqlConfiguration.serverVersion = ServerVersion.Parse(builder.Configuration.GetConnectionString("MySqlVersion"));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();



// update database if it is not created
using(IServiceScope serviceScope = app.Services.CreateScope())
{
    DbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapControllers();

app.Run();
