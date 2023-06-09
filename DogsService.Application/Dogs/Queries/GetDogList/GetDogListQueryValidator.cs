using FluentValidation;

namespace DogsService.Application.Dogs.Queries.GetDogList
{
    public class GetDogListQueryValidator : AbstractValidator<GetDogListQuery>
    {
        public GetDogListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}