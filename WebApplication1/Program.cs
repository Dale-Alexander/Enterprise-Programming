using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryDbContext>();
builder.Services.AddControllersWithViews();

/* Transient - it creates an instance for every call. This means that in the Bookscontroller Create function,
 * the repository will be created twice because you are checking if the book exists and then you are using 
 * it to add the book if it does exist
 * 
 * Singleton - this creates ONE instance for all users, calls, requests etc
 * 
 * Scoped (most commonly used) - it creates ONE instance for every request
 *                               ex: end-user => /Books/create => 1. checks whether books exist 2. adds the book
 */
builder.Services.AddScoped<BooksRepository>();

builder.Services.AddScoped<CategoriesRepository>(); 
//builder.Services.AddScoped(typeof(BooksRepository)); You can do this aswell but the above is easier

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
