using Infrastructure.Contexts;
using Presentation.WebApplicationExtensions;

var builder = WebApplication.CreateBuilder(args).ConfigureApplicationBuilder();

var app = builder.Build().ConfigureApplication();
app.CreateDatabase<GradesDbContext>();

app.Run();