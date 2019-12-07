using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.Domain.Dto;
using TrainingApp.Domain.Entity;
using TrainingApp.Domain.Interfaces.Repository.TrainingRepo;
using TrainingApp.Domain.Interfaces.Service;

namespace TrainingApp.Infrastructure.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        #region Constructors
        public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<CreateTrainingDto> CreateTrainingAsync(CreateTrainingDto createTrainingDto)
        {
            try
            {
                var training = _mapper.Map<Training>(createTrainingDto);
                await _trainingRepository.InsertAsync(training);
                await _trainingRepository.SaveAsync();
                createTrainingDto.Saved = true;
                createTrainingDto.Id = training.Id;
                return createTrainingDto;
            }
            catch (Exception)
            {
                createTrainingDto.Saved = false;
                return createTrainingDto;
            }
        }

        public async Task<GetTrainingDto> GetTrainingAsync(int id)
        {
            try
            {
                var training = await _trainingRepository.GetByIdAsync(id);
                if (training == null)
                    return new GetTrainingDto() { TrainingNotFound = true };
                return _mapper.Map<GetTrainingDto>(training);
            }
            catch (Exception)
            {

                return new GetTrainingDto() { TrainingNotFound = true };
            }
        }

        public async Task<GetTrainingListDto> GetTrainingsAsync()
        {
            var getTrainingListDto = new GetTrainingListDto();
            try
            {

                var trainings = await _trainingRepository.GetAllAsync();
                if (trainings == null && trainings.Count() == 0)
                {
                    getTrainingListDto.TrainingsNotFound = true;
                    return getTrainingListDto;
                }
                getTrainingListDto.Trainings = trainings.Select(x => _mapper.Map<TrainingDto>(x)).ToList();

                return getTrainingListDto;
            }
            catch (Exception)
            {
                getTrainingListDto.TrainingsNotFound = true;
                return getTrainingListDto;
            }
        }
    }
}
