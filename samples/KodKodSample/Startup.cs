using System.IO;
using KodKod;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
                    options.Conventions.Add(new OpenApiConvention(document))
                })
                .AddJsonFormatters(options => options.Formatting = Formatting.Indented)
                .AddApiExplorer();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
        }
    }
}
