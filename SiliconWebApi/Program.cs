using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDatabase")));

builder.Services.AddScoped<SubscriberService>();
builder.Services.AddScoped<NewsletterRepository>();

builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<UserCourseRegistrationRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ServiceRepository>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthorization();
app.MapControllers();
app.Run();
