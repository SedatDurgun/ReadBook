using ApplicationLayer.AutoMapper;
using ApplicationLayer.Services.BookService;
using ApplicationLayer.Services.CategoryService;
using ApplicationLayer.Services.CornerService;
using ApplicationLayer.Services.UserService;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Infrastructure;
using Infrastructure.Repositories.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//DATABASE

builder.Services.AddDbContext<LibraryContext>(x=>x.UseSqlServer());

//IDENTITY

builder.Services.AddIdentity<User,Role>(x=>x.SignIn.RequireConfirmedAccount=false)
    .AddEntityFrameworkStores<LibraryContext>()
    .AddRoles<Role>();

//AUTOMAPPER
builder.Services.AddAutoMapper(x=>x.AddProfile(typeof(LibraryProjeMapper)));

//REPOSITORIES

builder.Services.AddTransient<IBookRepository,BookRepository>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICornerRepository,CornerRepository>();


//SERVICES

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBookService,BookService>();
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICornerService,CornerService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(

        name: "areas",
        pattern: "{area:exists}/{controller=Panel}/{action=Index}/{id?}"



        );


});





app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
