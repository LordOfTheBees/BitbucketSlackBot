using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitbucket.BitbucketClients;
using Bitbucket.Interfaces.BitbucketClients;
using BitbucketSlackBot.Configs;
using BitbucketSlackBot.Data.Context;
using BitbucketSlackBot.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BitbucketSlackBot
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
            services.AddControllers();

            services.AddOptions();

            services.Configure<BitbucketAuthConfig>(Configuration.GetSection("BitbucketAuthConfig"));
            services.Configure<BitbucketRepoConfig>(Configuration.GetSection("BitbucketRepoConfig"));

            string connection = Configuration.GetConnectionString("DB_ConnectionString");
            services.AddDbContext<BitbucketSlackDataContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseMiddleware<TestMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
