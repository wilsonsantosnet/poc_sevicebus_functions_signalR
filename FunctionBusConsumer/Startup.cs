using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Orm;
using Common.Validation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Seed.Application;
using Seed.Application.Interfaces;
using Seed.Data.Context;
using Seed.Data.Repository;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;
using Seed.Domain.Services;
using Seed.Domain.Validations;

namespace FunctionBusConsumer
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<DbContextSeed>>();

            builder.Services.AddScoped<IValidatorSpecification<Sample>, SampleIsSuitableValidation>();
            builder.Services.AddScoped<IWarningSpecification<Sample>, SampleIsSuitableWarning>();
            builder.Services.AddScoped<ISampleApplicationService, SampleApplicationService>();
            builder.Services.AddScoped<ISampleService, SampleService>();
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();

            builder.Services.AddScoped<IValidatorSpecification<SampleType>, SampleTypeIsSuitableValidation>();
            builder.Services.AddScoped<IWarningSpecification<SampleType>, SampleTypeIsSuitableWarning>();
            builder.Services.AddScoped<ISampleTypeApplicationService, SampleTypeApplicationService>();
            builder.Services.AddScoped<ISampleTypeService, SampleTypeService>();
            builder.Services.AddScoped<ISampleTypeRepository, SampleTypeRepository>();

            builder.Services.AddScoped<IValidatorSpecification<SampleItem>, SampleItemIsSuitableValidation>();
            builder.Services.AddScoped<IWarningSpecification<SampleItem>, SampleItemIsSuitableWarning>();
            builder.Services.AddScoped<ISampleItemApplicationService, SampleItemApplicationService>();
            builder.Services.AddScoped<ISampleItemService, SampleItemService>();
            builder.Services.AddScoped<ISampleItemRepository, SampleItemRepository>();


            builder.Services.AddScoped<CurrentUser>();
        }
    }
}
