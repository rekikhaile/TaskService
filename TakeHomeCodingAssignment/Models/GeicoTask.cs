using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using TaskAppGeico.Models;

namespace TakeHomeCodingAssignment.Models
{
    public class GeicoTask
    {

        /*  private int id;
          private string name;
          private string description;
          private DateTime dueDate;
          private DateTime startDate;
          private DateTime endDate;
          private Priority priority;
          private Status status;*/

        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        [CustomValidation(typeof(CustomValidatorGeicoTask),nameof(CustomValidatorGeicoTask.PastDateChecker))]
        public DateTime DueDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }


    }
}
