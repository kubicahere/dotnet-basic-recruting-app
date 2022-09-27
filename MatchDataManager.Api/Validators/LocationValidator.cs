using FluentValidation;
using MatchDataManager.Api.Database;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        private readonly IRepository<Location> _repository;
        public LocationValidator(IRepository<Location> repository)
        {
            _repository = repository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!").MaximumLength(255);
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required!").MaximumLength(55);
            RuleFor(x => x.Name).Must(UniqueName).WithMessage("This name already exist!");

        }

        private bool UniqueName(string name)
        {
            return _repository.GetDataByName(name).FirstOrDefault(x => x.Name == name) == null;
        }
    }
}
