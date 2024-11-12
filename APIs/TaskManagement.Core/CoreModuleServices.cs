using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core
{
    public static class CoreModuleServices
    {
        public static IServiceCollection AddCoreModuleServices(this IServiceCollection services)
        {
            #region MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            #endregion

            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #endregion

            #region Cors
            services.AddCors();
            #endregion

            return services;
        }
    }
}
