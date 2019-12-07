using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Domain.Dto;

namespace TrainingApp.Domain.Interfaces.Service
{
    public interface ITrainingService
    {
        Task<CreateTrainingDto> CreateTrainingAsync(CreateTrainingDto createTrainingDto);
        Task<GetTrainingDto> GetTrainingAsync(int id);
        Task<GetTrainingListDto> GetTrainingsAsync();
    }
}
