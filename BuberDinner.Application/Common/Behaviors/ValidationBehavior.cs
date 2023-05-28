using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>      // TRequest is of MediatR, TResponse is of TRequest return
    where TRequest : IRequest<TResponse>        // TRequest will return type MediatR (TResponse)
    where TResponse : IErrorOr                  // TResponse will return type ErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        // If check no validators are registered then next
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if(validationResult.IsValid)
        {
            return await next();
        }
        var errors = validationResult.Errors.ConvertAll(validationFailure =>
            Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

        return (dynamic)errors;
    }
}