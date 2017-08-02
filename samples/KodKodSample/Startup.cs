
using System.IO;
using KodKod;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using KodKod.Runtime.Swagger;

namespace KodKodSample
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
            var document = OpenApiParser.Parse(Path.Combine(Directory.GetCurrentDirectory(), "openapi.yaml"));

            services
                .AddMvcCore(options =>
                {
                    options.Filters.Add(new ConsumesAttribute("application/json"));
                    options.Filters.Add(new ProblemErrorPolicyAttribute());

                    options.Conventions.Add(new ProducesConvention());
                    options.Conventions.Add(new ApiExplorerSettingsConvention());
                    options.Conventions.Add(new OpenApiConvention(document));
                })
                .AddJsonFormatters(options => options.Formatting = Formatting.Indented)
                .AddApiExplorer();

            services.AddSingleton<IApiDescriptionProvider, ErrorPolicyApiDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<ProblemOperationFilter>();
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
