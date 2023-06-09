using FluentValidation;

namespace DogsService.Application.Dogs.Queries.GetDogDetails
{
    public class GetDogDetailsQueryValidator : AbstractValidator<GetDogDetailsQuery>
    {
        public GetDogDetailsQueryValidator()
        {
            RuleFor(dog => dog.Id).NotEqual(Guid.Empty);
            RuleFor(dog => dog.UserId).NotEqual(Guid.Empty);
        }
    }
}