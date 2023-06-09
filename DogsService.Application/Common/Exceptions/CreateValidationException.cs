namespace DogsService.Application.Common.Exceptions
{
    public class CreateValidationException : Exception
    {
        public CreateValidationException(string name, object key) : base($"A dog with this \"{name}\" ({key}) name already exists.") { }
    }
}