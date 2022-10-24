using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    internal class NewBaseType
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // Chuyển hướng các yêu cầu HTTP đến HTTPS.
            app.UseStaticFiles(); // Cho phép phân phát các tệp tĩnh, chẳng hạn như HTML, CSS, hình ảnh và JavaScript.

            app.UseRouting(); // Adds route matching to the middleware pipeline

            app.UseAuthorization(); //  cho phep nguoi dung truy cap cac tai nguyen an toan. Unng dung nay khong su dung uy quyen nen dong nay co the bi xoa

            app.MapRazorPages(); // configures endpoint routing for razorpage

            app.Run(); // chay ung dung
        }
    }

}