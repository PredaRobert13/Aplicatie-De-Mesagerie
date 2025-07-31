
using MessagingApp.Data;

using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.WebHost.UseUrls("http://localhost:5263");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/test", () => "Merge!");
app.MapControllers();
app.Run();

