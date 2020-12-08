using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetCore.Api.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;

namespace CrudAspNetCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SkyHRContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // 包裝成 Image，並使用 Tye 進行取得此 Image 的時候
            // 請改用以下方法取得連線字串，因為無法得知 Tye 建立起的 DB Name
            // options.UseSqlServer(Configuration.GetConnectionString("sky-hr-db")));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*")
                    .AllowAnyMethod()
                    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization);
                    //.AllowCredentials();
                });
            });

            services.AddControllers();

            //services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Employee API",
                    Version = "v1", });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "DevelopmentForLocalDB")
            {
                app.UseDeveloperExceptionPage();
                
                //Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            // 不使用 SSL 導向，因為這個專案常常會放到 K8S 裡面
            // 有需要的可以自行開啟
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

 


        }
    }
}
