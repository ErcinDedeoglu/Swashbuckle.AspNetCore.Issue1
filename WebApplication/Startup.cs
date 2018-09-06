using System.Reflection;
using Core.DbContext;
using Extension.Alpha.DbContext;
using Extension.Beta.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Extension.Alpha")));
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Extension.Beta")));

            services.AddDbContext<CoreContext>(options => options.UseSqlServer(@"Server=localhost;Database=TestDatabase;Trusted_Connection=True;"));
            services.AddDbContext<AlphaContext>(options => options.UseSqlServer(@"Server=localhost;Database=TestDatabase;Trusted_Connection=True;"));
            services.AddDbContext<BetaContext>(options => options.UseSqlServer(@"Server=localhost;Database=TestDatabase;Trusted_Connection=True;"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}