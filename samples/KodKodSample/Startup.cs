using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace KodKodSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
            })
            .AddJsonFormatters(options => options.Formatting = Formatting.Indented)
            .AddApiExplorer();

            services.Remove(services.Where(s => s.ServiceType == typeof(IApiDescriptionProvider) && s.ImplementationType.Name == "DefaultApiDescriptionProvider").Single());
            services.AddSingleton<IApiDescriptionProvider, KodKod.DefaultApiDescriptionProvider>();
            services.AddSingleton<IApiDescriptionProvider, KodKod.ProblemDetailsApiDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() { Title = "Swagger Petstore" });
            });
        }
        
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Petstore");
            });
        }
    }
}
