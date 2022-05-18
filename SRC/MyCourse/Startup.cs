using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyCourse.Models.Services.Application;
using MyCourse.Models.Services.Infrastructure;

namespace MyCourse
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        
        {
             
        services.AddRazorPages();
         IMvcBuilder mvcBuilder = services
            .AddControllersWithViews() //Oppure AddRazorPages o AddMvc
            .AddRazorRuntimeCompilation();
        services.AddTransient<ICourseService, AdoNetCourseService>(); // nuovo servizio applicativo
        services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>(); //nuovo servizio infrastrutturale
         }
        public void Configure (IApplicationBuilder app,IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
    
           
          
  //Qui altri middleware, ad esempio app.UseStaticFiles();


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
           });*/
        

           
            
        }
    }
}


