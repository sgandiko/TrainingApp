using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingApp.Domain.Dto
{
    public class CreateTrainingDto : TrainingDto
    {
        
        public bool Created { get; set; } = false;
        [JsonIgnore]
        public bool DateError { get; set; } = false;
    }
}
