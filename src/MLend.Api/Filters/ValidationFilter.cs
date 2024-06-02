
using FluentValidation;
using MLend.Application;

namespace MLend.Api;

public class ValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<LendRequest>>();

        if(validator is not null) 
        {
            var lendRequest = context.Arguments
                .OfType<LendRequest>()
                .FirstOrDefault(x => x?.GetType() == typeof(LendRequest));

            if(lendRequest is not null)
            {
                var result = await validator.ValidateAsync(lendRequest);

                if(!result.IsValid)
                    return Results.ValidationProblem(result.ToDictionary());
            }else 
            {
                return Results.Problem("Error Not Found");
            }
        }

        return await next(context);
    }
}
