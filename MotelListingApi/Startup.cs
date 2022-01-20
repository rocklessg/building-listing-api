using AspNetCoreRateLimit;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MotelListingApi.Configurations;
using MotelListingApi.Data;
using MotelListingApi.Extensions;
using MotelListingApi.Repository.UnitOfWork;
using MotelListingApi.Services;

namespace MotelListingApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
            );

           
            //Private cache lives on the server
            //Proxy cache lives on the network

            // services.AddResponseCaching();

            //Calling the ServiceExtension class

            services.AddMemoryCache(); //for rate limit (throttling) 
            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor(); // this gives access to a given controller and it inner working when neededHttpCacheHeaders();

            services.ConfigureHttpCacheHeaders();

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            // COnfiguring CORS
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(MapperInitializer));

            //services.ConfigureAutoMapper();

            services.AddTransient<IUnitOfWork, UnitOfWork>(); // always create new instance per request
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Motel Listing Api", Version = "v1" });
            });

            //ignore circular reference
            services.AddControllers().AddNewtonsoftJson(op => 
            op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //Api versioning configuration
            services.ConfigureVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Motel Listing API");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseResponseCaching();
            app.UseHttpCacheHeaders();

            //app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //This is a convention-based routing
            // we're not using it for this project
            //we're using attribute routing from the controller

            //endpoints.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}"
            //    );
        }
    }
}
