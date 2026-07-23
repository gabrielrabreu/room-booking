using RoomBooking.Api;
using RoomBooking.Bookings;
using RoomBooking.Reporting;
using RoomBooking.Rooms;
using RoomBooking.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
    options.PipelineBehaviors =
    [
        typeof(ValidationBehavior<,>),
    ];
});

builder.Services.AddUsersModuleServices(builder.Configuration);
builder.Services.AddRoomsModuleServices(builder.Configuration);
builder.Services.AddBookingsModuleServices(builder.Configuration);
builder.Services.AddReportingModuleServices(builder.Configuration);

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapRoomsModuleEndpoints();

await app.Services.EnsureUsersModuleDatabaseAsync();
await app.Services.EnsureRoomsModuleDatabaseAsync();
await app.Services.EnsureBookingsModuleDatabaseAsync();
await app.Services.EnsureReportingModuleDatabaseAsync();

app.Run();
