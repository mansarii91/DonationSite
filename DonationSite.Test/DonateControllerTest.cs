using AutoMapper;
using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Entities.Donate;
using DonationSite.Endpoint.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DonationSite.Test
{
    public class DonateControllerTest
    {
        private DonateController _controller;
        private Mock<IDonateService> _serviceMock;
        private Mock<ILogger<DonateController>> _loggerMock;
        private Mock<IMapper> _mapperMock;

        public DonateControllerTest()
        {
            _serviceMock = new Mock<IDonateService>();
            _loggerMock = new Mock<ILogger<DonateController>>();
            _mapperMock = new Mock<IMapper>();
            _controller = new DonateController(_serviceMock.Object, _loggerMock.Object, _mapperMock.Object);

        }

        [Fact]
        public void Should_Return_AddSite_OK()
        {
            //Arrange
            var retVal = true;
            DonateDTO validSite = new DonateDTO()
            {
                DonateID = 1,
                DonatorName = "alan wake",
                FKSiteID = 2,
                Value = 1000
            };

            _serviceMock.Setup(a => a.SubmitDonate(It.IsAny<Donate>())).Returns(Task.FromResult<bool>(retVal));

            //act
            var result = _controller.AddDonate(validSite);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void Should_Return_AddSite_BadRequest()
        {
            //Arrange
            var retVal = true;
            DonateDTO validSite = new DonateDTO()
            {
                DonateID = 1,
                DonatorName = string.Empty,
                FKSiteID = 2,
                Value = 0
            };

            _serviceMock.Setup(a => a.SubmitDonate(It.IsAny<Donate>())).Returns(Task.FromResult<bool>(retVal));
            _controller.ModelState.AddModelError("DonatorName", "Donator name is required");

            //act
            var result = _controller.AddDonate(validSite);

            //assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }
    }
}
