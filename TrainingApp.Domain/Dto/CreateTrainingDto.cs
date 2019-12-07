using Newtonsoft.Json;
using System.Text;

namespace TrainingApp.Domain.Dto
{
    public class CreateTrainingDto : TrainingDto
    {
        [JsonIgnore]
        public bool Created { get; set; } = false;
        [JsonIgnore]
        public bool DateError { get; set; } = false;
        public bool Saved { get; set; }
    }
}
