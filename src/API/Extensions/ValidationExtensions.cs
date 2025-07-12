using API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace API.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();

        return services;
    }
}
