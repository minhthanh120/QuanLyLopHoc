using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLyLopHoc.Models;
using QuanLyLopHoc.Models.Entities;

using QuanLyLopHoc.Areas.Identity.Data;
using QuanLyLopHoc.Repository;
using QuanLyLopHoc.Repositories;
using QuanLyLopHoc.Services;
using QuanLyLopHoc.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SMContextConnection") ?? throw new InvalidOperationException("Connection string 'SMContextConnection' not found.");
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddDbContext<SMContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SMContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(e => e.MaximumReceiveMessageSize = 102400000);
builder.Services.AddTransient<SMContext>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageSevice, MessageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
{
    //IConfigurationSection FBAuthNSection = builder.Configuration.GetSection("Authentication:FB");
    facebookOptions.AppId = "3390710921258513";
    facebookOptions.AppSecret = "2ee20fc4a69b55e90757b4eb49c5a250";
    facebookOptions.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseEndpoints(enpo);
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<ChatHub>("/chathub");
app.Run();
