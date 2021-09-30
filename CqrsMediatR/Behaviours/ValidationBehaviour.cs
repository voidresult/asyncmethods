using CqrsMediatR.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validators.Any()) {

                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
                ValidationResult[] validationResults =
                    await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                List<ValidationFailure> failures = validationResults.SelectMany(result => result.Errors)
                    .Where(error => error != null).ToList();
                if (failures.Any())
                {
                    
                    throw new CommandValidationException(
                        $"Command Validation Errors for type {typeof(TRequest).Name}",
                        new ValidationException("Validation exception", failures));
                }
            }

            return await next();
        }
    }
}
