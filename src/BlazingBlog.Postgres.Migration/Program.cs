using BlazingBlog.Domain.Constants;
using BlazingBlog.Infrastructure;
using BlazingBlog.Postgres.Migration;

using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

//builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<ApplicationDbContext>(
		options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// builder.Services.AddOpenTelemetry()
// 		.WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

var host = builder.Build();

host.Run();