namespace Company.Service.Domain.Base
{
    public class DomainException : Exception
    {
        public List<string> ValidationErrors { get; init; }

        public DomainException(string message, List<string> validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
