﻿namespace TrafficJams.WebApi
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public IConfiguration AppConfiguration { get; }

        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            AppConfiguration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddCors();
			services.AddMvc();
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddTransient<ITrafficJamsProvider, YandexTrafficJamsProvider>();
            //TODO use interface instead of implementation
            services.AddTransient<AvailableRegionsProvider, AvailableRegionsProvider>();
            services.AddTransient<GoogleSheetsRegionService, GoogleSheetsRegionService>();
            services.AddTransient<TrafficJamsCache, TrafficJamsCache>();
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
	        app.UseCors(builder =>
		        builder.WithOrigins("http://localhost:55354")
		        .AllowAnyHeader());
			app.UseMvcWithDefaultRoute();
        }
    }
}
