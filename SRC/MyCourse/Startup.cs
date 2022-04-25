using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
            {
           
           services.AddRazorPages();
            }
        public void Configure (IApplicationBuilder app,IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
           // app.UseMvcWithDefaultRoute();
            //app.UseStaticFiles();
            app.UseRouting();
           // app.UseCors();

            app.UseEndpoints(endpoints =>
                {
                 endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
                });

           /*app.UseMvc(routeBuilder=>
           {
               routeBuilder.MapRoute("default","{controller}/{action}/{id}");
           });


           /* app.Run(async (context) =>
            {
                string nome = context.Request.Query["nome"];
                await context.Response.WriteAsync($"Hello {nome}!");
            });*/
        }
    }
}


