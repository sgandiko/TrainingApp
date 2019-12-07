using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Domain.Dto;
using TrainingApp.Domain.Entity;

namespace TrainingApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CreateTrainingDto, Training>().ReverseMap();
            CreateMap<GetTrainingDto, Training>().ReverseMap();
            CreateMap<TrainingDto, Training>().ReverseMap();

        }
    }
}
