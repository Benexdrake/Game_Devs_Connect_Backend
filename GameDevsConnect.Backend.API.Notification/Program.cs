using GameDevsConnect.Backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

var sharedConfiguration = ConfigurationHelper.GetConfiguration();
builder.Configuration.AddConfiguration(sharedConfiguration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NotificationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GDC"));
});

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
