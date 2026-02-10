/*
    dotnet ef dbcontext scaffold \
    "Host=localhost;Port=5434;Database=college-schedule-db;Username=admin69;Password=admin69" \
    Npgsql.EntityFrameworkCore.PostgreSQL \
    --output-dir Models \
    --context CollegeScheduleContext \
    --context-dir Data \
    --use-database-names \
    --force
*/

var builder = WebApplication.CreateBuilder(args);

// Controllers only
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
