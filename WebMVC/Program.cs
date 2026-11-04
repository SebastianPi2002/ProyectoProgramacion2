using Dominio;

namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Habilitamos los servicios de sesión.
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // Creamos el sistema y cargamos los datos.
            Sistema sistema = new Sistema();
            sistema.PrecargarDatos();

            builder.Services.AddSingleton<Sistema>(sistema);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Habilitamos las sesiones.
            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}