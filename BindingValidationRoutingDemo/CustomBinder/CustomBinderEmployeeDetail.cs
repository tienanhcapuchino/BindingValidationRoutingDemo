using BindingValidationRoutingDemo.DTO;
using BindingValidationRoutingDemo.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BindingValidationRoutingDemo.CustomBinder
{
    public class CustomBinderEmployeeDetail : IModelBinder
    {
      

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
           var modelName = bindingContext.ModelName;
           var value = bindingContext.ValueProvider.GetValue(modelName);
           var result = value.FirstValue;

           if(!int .TryParse(result, out var id))
            {
                return Task.CompletedTask;
            }
            EmployeeDTO e = new EmployeeDTO();
            using (var context = new NorthwindContext())
            {
                Employee emp = context.Employees.FirstOrDefault(x=>x.EmployeeId== id);
               if(emp != null)
                {
                  
                    e.EmployeeId = emp.EmployeeId;
                    e.FirstName = emp.FirstName;
                    e.LastName = emp.LastName;
                    e.Title = emp.Title;

                }



            }

            bindingContext.Result = ModelBindingResult.Success(e);

            return Task.CompletedTask;
        }
    }
}
