using FluentValidation;
using MediatR;

namespace TaskManagement.Core.Helpers
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f is not null).ToList();
                if (failures.Count > 0)
                {
                    var message = failures.Select(x => x.PropertyName + ":" + x.ErrorMessage).FirstOrDefault();
                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }
}
