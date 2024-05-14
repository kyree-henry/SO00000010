﻿using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SO00000010.Presentation.Data.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription descr in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descr.GroupName, ProvideApiInfo(descr));
            }
        }

        private OpenApiInfo ProvideApiInfo(ApiVersionDescription descr)
        {
            OpenApiInfo info = new()
            {
                Title = $"Software Operation 00000010: API {descr.ApiVersion}",
                Version = descr.ApiVersion.ToString(),
                Description = "Task:\r\nCreate application form for a program\r\nAllow user to apply and store the information",
                Contact = new OpenApiContact() { Name = "Kyree Henry", Email = "ene.henry.eh@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (descr.IsDeprecated)
            {
                info.Description += " API Version has been deprecated!!!";
            }

            return info;
        }
    }
}