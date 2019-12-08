using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Controllers;
using TrainingApp.Domain.Dto;
using TrainingApp.Infrastructure.Service;
using TrainingApp.UnitTest.Helpers.Service;

namespace TrainingApp.UnitTest.UnitTests.Controller
{
    [TestFixture]
    class TrainingControllerTests
    {
        private readonly TrainingController _controller;
        public TrainingControllerTests()
        {
            _controller = new TrainingController(new TrainingServiceTest() { });
        }
        [Test]
        public void CreateTraining_EndDateLessThanStartDate_ReturnBadResult()
        {
             
            var createTrainingDto = new CreateTrainingDto()
            {
                Name = "Test Training",
                TrainingStartDate = new DateTime(2019,12,09),
                TrainingEndDate = new DateTime(2019,12,01)
            };
            var result = _controller.Post(createTrainingDto).Result;

            // NotFound
            Assert.That(result, Is.TypeOf<BadRequestResult>());

            // NotFound or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void CreateTraining_NameIsNOtSet_ReturnBadResult()
        {
            
            var createTrainingDto = new CreateTrainingDto()
            {
                TrainingStartDate = new DateTime(2019, 12, 09),
                TrainingEndDate = new DateTime(2019, 12, 12)
            };

            

            var result = _controller.Post(createTrainingDto).Result;

            Assert.That(result, Is.TypeOf<BadRequestResult>());
        }

        [Test]
        public void CreateTraining_ReturnOkResult()
        {
            
            var createTrainingDto = new CreateTrainingDto()
            {
                Name = "Test Training4",
                TrainingStartDate = new DateTime(2019, 12, 09),
                TrainingEndDate = new DateTime(2019, 12, 12)
            };
            var result = _controller.Post(createTrainingDto).Result;

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.Get().Result as OkObjectResult;

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            Assert.That(okResult, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual(3, (okResult.Value as List<TrainingDto>).Count);
        }

        [Test]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.Get(4).Result;
            var notFoundResult = result.Result as NotFoundObjectResult;

            // Assert
            Assert.That(notFoundResult, Is.TypeOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            

            // Act
            var result = _controller.Get(1).Result;
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.That(okResult, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            

            // Act
            var result = _controller.Get(1).Result;
            var training = result.Result as OkObjectResult;
            // Assert

            Assert.AreEqual(1, (training.Value as TrainingDto).Id);
        }


    }

    
}
