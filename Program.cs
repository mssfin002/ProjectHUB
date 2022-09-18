using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHUB.Areas.Identity.Data;
using ProjectHUB.Core.iRepo;
using ProjectHUB.Core.Repo;
using ProjectHUB.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjectHUBContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjectHUBContextConnection' not found.");

builder.Services.AddDbContext<ProjectHUBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ProjectHUBUser>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ProjectHUBContext>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

#region Services Added
builder.Services.AddScoped<iAOKRepo, AOKRepo>();
builder.Services.AddScoped<iRoleRepo, RoleRepo>();
builder.Services.AddScoped<iThemeRepo, ThemeRepo>();
builder.Services.AddScoped<iTopicRepo, TopicRepo>();
builder.Services.AddScoped<iUnitofWork, UnitOfWork>();
builder.Services.AddScoped<iUserRepo, UserRepo>();
#endregion


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
