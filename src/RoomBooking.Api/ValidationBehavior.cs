namespace RoomBooking.Api;

public class ValidationBehavior<TMessage, TResponse>(IEnumerable<IValidator<TMessage>> validators) : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    public async ValueTask<TResponse> Handle(TMessage message, MessageHandlerDelegate<TMessage, TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next(message, cancellationToken);
        }

        var validationTasks = validators
            .Select(v => v.ValidateAsync(message, cancellationToken));

        var validationResults = await Task.WhenAll(validationTasks);

        var validationErrors = validationResults
            .SelectMany(r => r.Errors)
            .Where(e => e is not null)
            .ToList();

        if (validationErrors.Count == 0)
        {
            return await next(message, cancellationToken);
        }

        var errors = validationErrors
            .ConvertAll(error => Error.Validation(
                code: error.PropertyName,
                description: error.ErrorMessage));

        return (dynamic)errors;
    }
}
