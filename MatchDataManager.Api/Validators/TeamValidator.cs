using FluentValidation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        private readonly IRepository<Team> _repository;
        public TeamValidator(IRepository<Team> repository)
        {
            _repository = repository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!").MaximumLength(255);
            RuleFor(x => x.CoachName).NotEmpty().WithMessage("City is required!").MaximumLength(55);
            RuleFor(x => x.Name).Must(UniqueName).WithMessage("This name already exist!");

        }

        private bool UniqueName(string name)
        {
            return _repository.GetDataByName(name).FirstOrDefault(x => x.Name == name) == null;
        }
    }
}
