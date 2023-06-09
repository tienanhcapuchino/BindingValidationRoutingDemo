using BindingValidationRoutingDemo.DTO;
using BindingValidationRoutingDemo.Models;
using FluentValidation;
namespace BindingValidationRoutingDemo.Validation
{
    public class EmployeeValidation : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidation() { 
        
                 RuleFor(x =>x.Title).NotEmpty().MinimumLength(3).WithMessage("Title must more than 3 charactor");
                RuleFor(x => x.EmployeeId).NotNull().NotEmpty().WithErrorCode("E01").WithMessage("Error Id");
        }
    }
}
