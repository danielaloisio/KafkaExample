using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KafkaExampleApi.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerExtensions
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                   new Microsoft.OpenApi.Models.OpenApiInfo
                   {
                       Title = "KafkaExampleApi",
                       Version = "v1",
                       Description = "KafkaExampleApi",
                       Contact = new Microsoft.OpenApi.Models.OpenApiContact
                       {
                           Name = "KafkaExampleApi",
                           Url = new Uri("https://github.com/danielaloisio")
                       }
                   });
            });
        }
        public static void SwaggerApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "KafkaExampleApi");
                c.RoutePrefix = "docs";
            });
        }
    }
}
