using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFront", policy =>
    {
        policy.WithOrigins(
            "http://ambulatorial.gearhostpreview.com",
            "https://ambulatorial.gearhostpreview.com")
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirFront");
app.MapControllers();
app.Run();