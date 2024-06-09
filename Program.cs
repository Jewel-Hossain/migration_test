//In the name of Allah

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContextPool<ApplicationDbContext>(options => options
.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.MapGet("/", (ApplicationDbContext ctx) => ctx.Set<Part>().FromSqlRaw("SELECT * FROM Parts"));
app.MapPost("/add",(Part part, ApplicationDbContext ctx)=> ctx.Set<Part>().FromSql($"insert into parts (branchid,\"time\") values ({1},{DateTime.UtcNow});"));

app.Run();

