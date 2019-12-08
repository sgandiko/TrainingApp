using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Domain.Entity;

namespace TrainingApp.UnitTest.Entity
{
    
    [TestFixture]
    public class TrainingTests
    {
        private readonly Training _training;
        private const int Id = 1;
        private const string Name = "Test";
        private readonly DateTime TrainingStartDate = new DateTime(2019, 1, 1);
        private readonly DateTime TrainingEndDate = new DateTime(2019,1,2);

        public TrainingTests()
        {
            _training = new Training();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _training.Id = Id;

            Assert.That(_training.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _training.Name = Name;

            Assert.That(_training.Name,
                Is.EqualTo(Name));
        }

        [Test]
        public void TestSetAndGetTrainingStartDate()
        {
            _training.TrainingStartDate = TrainingStartDate;

            Assert.That(_training.TrainingStartDate,
                Is.EqualTo(TrainingStartDate));
        }

        [Test]
        public void TestSetAndGetTrainingEndDate()
        {
            _training.TrainingEndDate = TrainingEndDate;

            Assert.That(_training.TrainingEndDate,
                Is.EqualTo(TrainingEndDate));
        }
    }
}
