using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrainingApp.Domain.Dto
{
    public class GetTrainingListDto : TrainingDto
    {
        public GetTrainingListDto()
        {
            Trainings = new HashSet<TrainingDto>();
        }
        public virtual ICollection<TrainingDto> Trainings { get; set; }
        [JsonIgnore]
        public bool TrainingsNotFound { get; set; } = false;
    }
}
