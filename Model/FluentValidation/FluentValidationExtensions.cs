namespace ValidationDemo.Model.FluentValidation
{
    using FluentValidation;
    using global::FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class FluentValidationExtensions
    {
        public static void AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            var validatorType = typeof(IValidator<>);
            var validators = assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(interfaceType => interfaceType.IsGenericType &&
                                           interfaceType.GetGenericTypeDefinition() == validatorType))
                .ToList();

            foreach (var validator in validators)
            {
                var interfaceType = validator.GetInterfaces()
                    .First(type => type.IsGenericType &&
                                   type.GetGenericTypeDefinition() == validatorType);
                services.AddTransient(interfaceType, validator);
            }
        }
    }

}
