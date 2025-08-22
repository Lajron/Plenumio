using Microsoft.EntityFrameworkCore;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Data;
using Plenumio.Infrastructure.Extensions;
using Plenumio.Application.Extensions;
using Plenumio.Contracts.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlenumioDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<PlenumioDbContext>();

builder.Services.AddUnitOfWork();
builder.Services.AddApplicationServices();
builder.Services.AddFeedStrategyServices();

builder.Services.AddAutoMapperProfiles();

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

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Feed}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feed}/{action=Index}/{id?}"
);

app.Run();
