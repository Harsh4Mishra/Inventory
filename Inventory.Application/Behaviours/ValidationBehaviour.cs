using FluentValidation;
using MediatR;

namespace Inventory.Application.Behaviours
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region properties

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        //private readonly ILogger _logger;

        #endregion

        #region Ctor

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)//ILogger logger
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            //_logger = logger;
        }

        #endregion

        #region method

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Any())
                {
                    //_logger.Error("Error is ValidationBehaviour:" + failures.ToString());
                    throw new FluentValidation.ValidationException(failures);
                }
            }

            return await next();
        }

        #endregion
    }
}
