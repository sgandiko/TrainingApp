using Newtonsoft.Json;

namespace TrainingApp.Domain.Dto
{
    public class GetTrainingDto : TrainingDto
    {
        [JsonIgnore]
        public bool TrainingNotFound { get; set; } = false;
    }
}
