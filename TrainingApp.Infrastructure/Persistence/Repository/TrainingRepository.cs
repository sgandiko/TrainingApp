using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Domain.Entity;
using TrainingApp.Domain.Interfaces.Repository.TrainingRepo;
using TrainingApp.Infrastructure.Context;
using TrainingApp.Infrastructure.Persistence.Repository.Common;

namespace TrainingApp.Infrastructure.Persistence.Repository
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        //private readonly TrainingAppContext _dbContext;
        public TrainingRepository(TrainingAppContext dbContext) : base(dbContext)
        {

        }
    }
}
    
