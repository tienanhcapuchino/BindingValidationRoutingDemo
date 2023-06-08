using BindingValidationRoutingDemo.CustomBinder;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BindingValidationRoutingDemo.DTO
{
  //  [ModelBinder(typeof(CustomBinderEmployeeDetail))]
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

      //  [MinLength(3, ErrorMessage = "LastName must be more than 3 characters ")]
        public string LastName { get; set; } = null!;

       
        public string FirstName { get; set; } = null!;

        //[Required(ErrorMessage = "Title must be not null")]
        public string? Title { get; set; }
    }
}
