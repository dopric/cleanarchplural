using FluentValidation.Results;

namespace GloboTickets.Application.Exceptions;

public class EntryNotCreatedException : Exception
{
    public List<string> ValidationErrors { get; init; }
    public EntryNotCreatedException(ValidationResult validationResult)
    {
       ValidationErrors = 
           validationResult.Errors.Select(e => e.ErrorMessage).ToList();
    }
}