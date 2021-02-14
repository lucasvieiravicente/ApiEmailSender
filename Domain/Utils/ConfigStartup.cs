using ApiEmails.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ApiEmails.Domain.Utils
{
    public static class ConfigStartup
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<ISendEmailAppService, SendEmailAppService>();
        }

        public static void ConfigureSwaggerGenInfos(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ApiEmails",
                    Version = "V1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Lucas Vieira",
                        Email = "lucasvieiravicente1@gmail.com",
                        Url = new Uri("https://white-moss-0cf7e1e0f.azurestaticapps.net")
                    },
                    Description = "A simple API just to send e-mails",
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/lucasvieiravicente/ApiEmailSender/blob/master/LICENSE")
                    }
                });
            });
        }

        public static void ConfigureSwaggerUI(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiEmail V1");
            });
        }
    }
}
