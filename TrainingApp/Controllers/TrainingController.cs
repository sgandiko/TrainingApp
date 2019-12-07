using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.Dto;
using TrainingApp.Domain.Entity;
using TrainingApp.Domain.Interfaces.Service;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private const string TrainingNotFound = "Training id with {0} was not found.";
        private const string TrainingsNotFound = "No trainings found.";
        private const string TrainingSaveFailRequestMessage = "{0} unable to save the record.";

        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var getTrainingListDto = await _trainingService.GetTrainingsAsync();
                if (getTrainingListDto.TrainingsNotFound)
                    return BadRequest(string.Format(TrainingsNotFound));
                return Ok(getTrainingListDto.Trainings);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDto>> Get(int id)
        {
            try
            {
                var training = await _trainingService.GetTrainingAsync(id);
                if (training == null || training.TrainingNotFound)
                    return BadRequest(string.Format(TrainingNotFound, id));
                return Ok(training);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateTrainingDto createTrainingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _trainingService.CreateTrainingAsync(createTrainingDto);

                
                if (!createTrainingDto.Saved)
                    return BadRequest(string.Format(TrainingSaveFailRequestMessage, createTrainingDto.Name));

                return Created(new Uri(Request.GetDisplayUrl() + "/" + createTrainingDto.Id), createTrainingDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}