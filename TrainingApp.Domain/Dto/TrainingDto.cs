using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Domain.Dto
{
    public class TrainingDto : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime TrainingStartDate { get; set; }
        [Required]
        public DateTime TrainingEndDate { get; set; }
        public int Days { get { return (TrainingEndDate - TrainingStartDate).Days; }  }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Name == null || string.IsNullOrEmpty(Name) || Name.Length > 100)
            {
                yield return new ValidationResult(
                    $"Name value is not valid",
                    new[] { "TrainingEndDate" });
            }

            if(TrainingEndDate < TrainingStartDate)
            {
                yield return new ValidationResult(
                    $"EndDate {TrainingEndDate} Cannot be less than  StartDate {TrainingStartDate}.",
                    new[] { "TrainingEndDate" });
            }
        }
    }
}
