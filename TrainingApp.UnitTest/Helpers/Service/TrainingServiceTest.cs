using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Domain.Dto;
using TrainingApp.Domain.Interfaces.Service;

namespace TrainingApp.UnitTest.Helpers.Service
{
    class TrainingServiceTest : ITrainingService
    {
        private readonly List<TrainingDto> _trainings;
        public TrainingServiceTest()
        {
            _trainings = new List<TrainingDto>()
            {
                new TrainingDto() { Id = 1,
                    Name = "Test Training1", TrainingStartDate = new DateTime(2019,12,06) , TrainingEndDate = new DateTime(2019,12,12)},
                new TrainingDto() { Id = 2,
                    Name = "Test Training2", TrainingStartDate = new DateTime(2019,12,06) , TrainingEndDate = new DateTime(2019,12,12) },
                new TrainingDto() { Id = 3,
                    Name = "Test Training3", TrainingStartDate = new DateTime(2019,12,06) , TrainingEndDate = new DateTime(2019,12,12) }
            };
        }
        public async Task<CreateTrainingDto> CreateTrainingAsync(CreateTrainingDto createTrainingDto)
        {
            createTrainingDto.Id = 4;
            createTrainingDto.Created = true;
            _trainings.Add(new TrainingDto()
            {
                Id = createTrainingDto.Id,
                Name = createTrainingDto.Name,
                TrainingStartDate = createTrainingDto.TrainingStartDate,
                TrainingEndDate = createTrainingDto.TrainingEndDate
            });
            return createTrainingDto;
        }

        public async Task<GetTrainingDto> GetTrainingAsync(int id)
        {
            var training = _trainings.Where(x => x.Id == id).FirstOrDefault();
            if (training == null)
                return new GetTrainingDto { TrainingNotFound = true};

            return new GetTrainingDto()
            {
                Id = training.Id,
                TrainingStartDate = training.TrainingStartDate,
                TrainingEndDate = training.TrainingEndDate,
                TrainingNotFound = false
            };
        }

        public async Task<GetTrainingListDto> GetTrainingsAsync()
        {
            
            if (_trainings == null || _trainings.Count() == 0)
                return new GetTrainingListDto { TrainingsNotFound = true };

            return new GetTrainingListDto()
            {
                TrainingsNotFound = false,
                Trainings = _trainings
            };
        }
    }
}
