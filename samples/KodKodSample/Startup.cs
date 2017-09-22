using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        }
        
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
