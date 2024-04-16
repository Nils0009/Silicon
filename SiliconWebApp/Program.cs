using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiliconWebApp.Helpers.Middlewares;
using SiliconWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDatabase")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<UserCourseRegistrationRepository>();
builder.Services.AddScoped<CourseHttpService>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryHttpService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<NewsletterRepository>();
builder.Services.AddScoped<SubscriberService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddHttpClient();

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
})  
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
    x.LogoutPath = "/auth/signout";
    x.AccessDeniedPath = "/error";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;

    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});

builder.Services.AddAuthentication().AddFacebook(x =>
{
    x.AppId = "1199911974753399";
    x.AppSecret = "9ab9a88d9cd2c14754d7d4c8d13d48f4";
    x.Fields.Add("first_name");
    x.Fields.Add("last_name");
})
    .AddGoogle(GoogleOptions =>
{
    GoogleOptions.ClientId = "522712166664-b53jdb2a3vhve2gs5rkrq5v7rds17vv7.apps.googleusercontent.com";
    GoogleOptions.ClientSecret = "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";
});


var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseUserSessionValidation();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = ["Admin", "User"];
    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }      
    }
}


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
