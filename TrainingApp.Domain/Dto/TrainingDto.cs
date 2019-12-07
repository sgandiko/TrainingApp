using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Domain.Dto
{
    public class TrainingDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime TrainingStartDate { get; set; }
        [Required]
        public DateTime TrainingEndDate { get; set; }
    }
}
