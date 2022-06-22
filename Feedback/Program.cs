using Feedback.Repositories;
using Feedback.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register dependency injection
builder.Services.AddTransient<IFeedbacksRepository, FeedbacksRepository>();
builder.Services.AddTransient<IFeedbacksService, FeedbacksService>();

builder.Services.AddTransient<IApplicationsRepository, ApplicationsRepository>();
builder.Services.AddTransient<IApplicationsService, ApplicationsService>();

builder.Services.AddDbContext<FeedbackMgmtContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
