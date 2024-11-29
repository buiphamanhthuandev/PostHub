using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PostHub.Areas.Admin.Repositories.Categories;
using PostHub.Areas.Admin.Repositories.CategoryTypes;
using PostHub.Areas.Admin.Repositories.Comments;
using PostHub.Areas.Admin.Repositories.Contacts;
using PostHub.Areas.Admin.Repositories.Posts;
using PostHub.Areas.Admin.Repositories.Subscribes;
using PostHub.Areas.Admin.Repositories.Users;
using PostHub.Data;
using PostHub.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PostHubDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<User, IdentityRole>(opts =>
{
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequiredLength = 8;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireLowercase = false;
    opts.User.RequireUniqueEmail = true;
    opts.SignIn.RequireConfirmedEmail = false;
    opts.SignIn.RequireConfirmedPhoneNumber = false;

}).AddEntityFrameworkStores<PostHubDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICategoryTypeRepository,EFCategoryTypeRepository>();
builder.Services.AddScoped<ICategoryRepository,EFCategoryRepository>();
builder.Services.AddScoped<ISubscribeRepository,EFSubscribeRepository>();
builder.Services.AddScoped<IContactRepository,EFContactRepository>();
builder.Services.AddScoped<ICommentRepository,EFCommentRepository>();
builder.Services.AddScoped<IPostRepository,EFPostRepository>();
builder.Services.AddScoped<IUserRepository,EFUserRepository>();


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

app.MapControllerRoute(
    name:"admin",
    pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
