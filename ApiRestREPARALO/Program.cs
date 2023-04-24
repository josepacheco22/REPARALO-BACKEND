using Data.REPARALO.ConnectDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Text;



var builder = WebApplication.CreateBuilder(args);



//  cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*")
                   .AllowAnyHeader();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<DBReparalo>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"));
    //options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"));
});




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dataComtext = scope.ServiceProvider.GetRequiredService<DBReparalo>();
    dataComtext.Database.Migrate();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//cors
app.UseCors();

app.MapControllers();

app.Run();
