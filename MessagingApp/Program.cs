
using MessagingApp.Data;

using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.WebHost.UseUrls("http://localhost:5263");

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();
app.MapGet("/test", () => "Merge!");
app.MapControllers();
app.Run();

