using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomRoute_Project
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // komutunu ekliyoruz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*Custom route kodlarımızı yazıyoruz*/
    
            // static (wwwroot) klasörü altındaki dosyalara erişebilmek için bu komutu kullanabilirsiniz.
            app.UseStaticFiles(); 

            app.UseMvc(routes => {
                 // url yapımızı oluşturuyoruz

                 // artık sitemize => blog/icerik/2019/1234567890 şeklinde bir istek geldiğinde
                 // Blog Controller içerisindeki Detail ActionResult alanı tetiklenecektir.
                 // yil=@"\d{4}" ile yil parametresinin 4 karakterli sayısal bir değer alabileceğini belirtiyoruz
                 // blogId=@"\d{10}" ile blogId parametresinin 10 karakterli sayısal bir değer alabileceğini belirtiyoruz
                 routes.MapRoute(
                     "customroutes", 
                     "blog/icerik/{yil}/{blogId}",
                     new {controller ="Blog", action="Detail"},
                     new {yil=@"\d{4}", blogId=@"\d{10}"});

                 // default url routing kontrolümüzü yazıyoruz
                 // default routes tanımını herzaman en alt satırda olmasını sağlamalıyız
                 // aksi halde custom routes yapımız göz ardı edilebilir ve bu sebepten dolayı
                 // custom routes yapımız çalışmayabilir.
                 routes.MapRoute(name:"default", template:"{controller=Home}/{action=Index}/{Id?}");
            });

        }
    }
}
