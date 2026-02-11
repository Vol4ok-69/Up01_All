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

using CollegeSchedule.Data;
using CollegeSchedule.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollegeScheduleContext>(options =>
    options.UseNpgsql(
        "Host=college-schedule-postgres;Port=5432;Database=college-schedule-db;Username=admin69;Password=admin69"
    )
);

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();


