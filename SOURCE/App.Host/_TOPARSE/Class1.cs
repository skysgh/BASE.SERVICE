using App.Host.Web.Controllers;
using App.Modules.Sys.Infrastructure.Storage.EF;
//using App.Host.Web.Startup;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System.Reflection;

namespace App.Host.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            RegisterServices(builder);

            var assembly = typeof(WeatherForecastController).GetTypeInfo().Assembly;
            var part = new AssemblyPart(assembly);

            builder.Services.AddControllersWithViews()

               // Correction: this is now implicit for all Referenced assemblies.
               // Although not the case for non-referenced assemblies.
               // See: https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/app-parts?view=aspnetcore-6.0
               // See:
               // Add this to find parts in other assemblies:
               //.ConfigureApplicationPartManager(
               // apm => apm.ApplicationParts.Add(
               //     part))
               ;

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }

        static void RegisterServices(WebApplicationBuilder builder)
        {


            // Add DbContext:
            // Except that means a dependency on EF
            // From Host...not the best. Better if it could be added later.
            // But how... Since Lamar ServiceRepository doesn't have view
            // back to builder...
            // So instead, have a direct Ref on the static class in the EF.SqlServer
            // assembly (where it's ok to have a Ref) and leverage it to initiate
            // the Builder before it is built.
            FuckFuckFuck.Crap(builder.Services, builder.Configuration);


            builder.Host.UseLamar((context, registry) =>
            {
                // register services using Lamar
                //Not recommended: registry.For<IFooService>().Use<FooService>();
                //in favour of:
                //registry.IncludeRegistry<ModuleServiceRegistry>();
                //But even that is not as flexible as scanning:
                // As per 
                // https://jasperfx.github.io/lamar/documentation/ioc/registration/auto-registration-and-conventions/
                registry.Scan(x => {
                    string? path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    //x.TheCallingAssembly();

                    //x.AssembliesFromPath(path);


                    x.AssembliesAndExecutablesFromApplicationBaseDirectory(
                        f => { return f.Location.Contains("App."); }
                        );
                    x.LookForRegistries();

                });



                // Not a hundred percent certain the rest of 
                // add the controllers
                //registry.AddControllers();

            });


        }

    }

}