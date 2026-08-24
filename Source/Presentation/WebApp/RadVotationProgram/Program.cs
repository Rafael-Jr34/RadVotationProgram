using Microsoft.EntityFrameworkCore;
using RadVotationProgram.Middlewares;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Infrastructure.Persistence;
using RVP.Infrastructure.Persistence.Context;


namespace RadVotationProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddPersistenceLayerIoc(builder.Configuration);
            builder.Services.AddServiceLayerIoc();
            builder.Services.AddSession(opt =>
                { opt.IOTimeout = TimeSpan.FromMinutes(60); //Just one hour of sesion activiness
                  opt.Cookie.HttpOnly = true; //just work with http
                });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUserSession, UserSession>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Citizen}/{action=Index}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
