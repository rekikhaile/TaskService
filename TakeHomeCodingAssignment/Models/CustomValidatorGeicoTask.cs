using System.ComponentModel.DataAnnotations;

namespace TakeHomeCodingAssignment.Models
{
    public class CustomValidatorGeicoTask
    {
        public static ValidationResult? PastDateChecker(DateTime dueDate)
        {
            return DateTime.Compare(dueDate, DateTime.Now) < 0 ? new ValidationResult("Due Date cannot be in the past") : ValidationResult.Success;
        }

       
    }
}
