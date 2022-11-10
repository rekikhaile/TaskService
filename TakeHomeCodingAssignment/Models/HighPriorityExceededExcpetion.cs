using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TakeHomeCodingAssignment.Models
{
    public class HighPriorityExceededExcpetion : ExceptionFilterAttribute
    {
        String message;
        public HighPriorityExceededExcpetion(String message) { 
        this.message = message;
        }
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context) {
            var result = new ObjectResult(new
            {
                message, // Or a different generic message
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().FullName,
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };


            // Set the result
            context.Result = result;
        }

    }
}
