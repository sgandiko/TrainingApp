using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Domain.Entity;
using TrainingApp.Domain.Interfaces.Repository.Common;

namespace TrainingApp.Domain.Interfaces.Repository.TrainingRepo
{
    public interface ITrainingRepository : IGenericRepository<Training>
    {
    }
}
