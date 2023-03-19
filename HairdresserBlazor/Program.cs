using HairdresserBlazor.Areas.Identity;
using HairdresserBlazor.Data;
using HairdresserBlazor.DataRepositories;
using HairdresserBlazor.DataRepositories.Contracts;
using HairdresserBlazor.Entities;
using HairdresserBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<SalonDbContext>(options =>
{
	options.UseSqlServer(connectionString);
	options.EnableSensitiveDataLogging();
	options.EnableDetailedErrors();
});


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<User>()
	.AddRoles<UserRole>()
	.AddEntityFrameworkStores<SalonDbContext>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHairdresserRepository, HairdresserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<DateStateContainer>();
builder.Services.AddScoped<IUserHandler, UserHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

// Maybe watch more of Tim Corey
// Maybe watch Blazor TDD https://www.youtube.com/watch?v=37r7l0wxOq4&list=PLQB-TSatJvw632cR-hAtL-MYXTEWwvUuk&index=5
