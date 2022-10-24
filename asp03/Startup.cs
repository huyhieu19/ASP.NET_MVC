using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        /*
            Phương thức ConfigureServices cho phép truy cập đến các dịch vụ, dependency được Inject vào
            Webhost. Hoặc bạn cũng có thể đưa thêm các dependency tại đây.
        */
    }

    // IHostingEnvironment  env cho phép truy cập các biến môi trường, thư mục nguồn, thư mục file.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Thêm StaticFileMiddleware vào pipeline - kích hoạt truy cập file tĩnh trong wwwroot
        // file wwwroot/html/helloworld.html truy cập được http://localhost:7095/html/helloworld.html
        app.UseStaticFiles();


        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseSession();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            app.UseEndpoints(endpoints =>
            {
                // Tại đây là code, sử dụng endpoints (IEndpointRouteBuilder) tạo các điểm cuối
                // Hình thành lên các nhánh rẽ ra từ EndpointRoutingMiddleware


                //Điểm cuỗi của pipeline khi địa chỉ truy cập là /
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });



                // Điểm cuỗi của pipeline khi địa chỉ truy cập là /Abc
                endpoints.Map("/Abc", async context =>
                {
                    await context.Response.WriteAsync("Hello  Abc");
                });

                endpoints.Map("/RequestInfo", async context =>
                {
                    await context.Response.WriteAsync("RequestInfo!");
                });

                endpoints.MapGet("/Encoding", async context =>
                {
                    // xay dung chuc nang
                    await context.Response.WriteAsync("Hello Encoding!");
                });

                endpoints.MapGet("/Cookies", async context =>
                {
                    await context.Response.WriteAsync("Hello Cookies!");
                });
            });
        });
        app.Map("/Json", async context =>
                {
                    app.Run(async context =>
                    {
                        await context.Response.WriteAsync("/Json");
                    });
                });

        app.Map("/Form", async context =>
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("/Form");
            });
        });
    }
}