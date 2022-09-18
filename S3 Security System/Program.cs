using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("S3_Security_SystemContextConnection") ?? throw new InvalidOperationException("Connection string 'S3_Security_SystemContextConnection' not found.");

builder.Services.AddDbContext<S3_Security_SystemContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<S3_Security_SystemUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<S3_Security_SystemContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
