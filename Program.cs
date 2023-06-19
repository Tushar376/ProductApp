using Microsoft.EntityFrameworkCore;
using NimapproductApp.Models;
using NimapproductApp.Repository;

namespace NimapproductApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string conn = builder.Configuration.GetConnectionString("LocalString");
            builder.Services.AddDbContext<AppDbContext>(p=>p.UseSqlServer(conn));
            builder.Services.AddScoped<IProductRepository , ProductRepository>();
            builder.Services.AddScoped < ICategoryRepository, CategoryRepository>();

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

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Category}/{action=Index}");
            app.MapControllers();
            app.Run();
        }
    }
}