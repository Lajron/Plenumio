using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Plenumio.Application.Extensions;
using Plenumio.Core.Entities;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Extensions;
using Plenumio.Infrastructure.Services;
using Plenumio.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorOptions(options => { options.ViewLocationExpanders.Add(new CustomViewLocationExpander());});

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IImageService>(sp => {
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    return new ImageService(env.WebRootPath);
});

builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
builder.Services.AddApplicationHandlers();
builder.Services.AddApplicationServices();
builder.Services.AddSortStrategyServices();
builder.Services.AddEmailSender();
builder.Services.AddApplicationMapperProfileServices();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Feed}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feed}/{action=Index}/{id?}"
);

app.Run();
