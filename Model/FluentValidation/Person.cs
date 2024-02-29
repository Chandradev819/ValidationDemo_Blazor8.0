using FluentValidation;
namespace ValidationDemo.Model.FluentValidation
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).InclusiveBetween(18, 99);
        }
    }
}
