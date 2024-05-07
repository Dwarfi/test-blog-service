using System.ComponentModel.DataAnnotations;

namespace Company.Service.Domain.Base;

public abstract class Entity
{
    public bool IsDeleted { get; private set; }
    public DateTime DateUpdated { get; protected set; } = DateTime.UtcNow;
    public DateTime DateCreated { get; init; } = DateTime.UtcNow;
    public int Id { get; init; }

    public virtual void Delete()
    {
        IsDeleted = true;
        DateUpdated = DateTime.UtcNow;
    }

    protected virtual void Validate()
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(this);

        bool isValid = Validator.TryValidateObject(this, context, validationResults, true);

        if (!isValid)
        {
            string errorMessages = string.Join(Environment.NewLine, validationResults.Select(v => v.ErrorMessage));
            throw new ValidationException($"Validation failed for {GetType().Name}: {errorMessages}");
        }
    }
}