using AutoMapper;
using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Entities.Site;
using DonationSite.Endpoint.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DonationSite.Test
{
    public class SiteControllerTest
    {

        private SiteController _controller;
        private Mock<ISiteService> _serviceMock;
        private Mock<ILogger<SiteController>> _loggerMock;
        private Mock<IMapper> _mapperMock;

        public SiteControllerTest()
        {
            _serviceMock = new Mock<ISiteService>();
            _loggerMock = new Mock<ILogger<SiteController>>();
            _mapperMock = new Mock<IMapper>();
            _controller = new SiteController(_serviceMock.Object, _loggerMock.Object, _mapperMock.Object);

        }

        [Fact]
        public void Should_Return_GetAllSiteList_OK()
        {
            //Arrange
            List<Site> siteList = new List<Site>();
            _serviceMock.Setup(a => a.GetAllList(0, 1000)).Returns(Task.FromResult<IEnumerable<Site>>(siteList));

            //act
            var result = _controller.GetAllSiteList(0, 1000);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void Should_Return_GetTotalCount_OK()
        {
            long value = 100;
            //Arrange
            _serviceMock.Setup(a => a.GetTotalCount()).Returns(value);

            //act
            var result = _controller.GetTotalCount();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(100)]
        public void Should_Return_GetSiteById_OK(int id)
        {
            var site = new Site();
            //Arrange
            _serviceMock.Setup(a => a.GetById(id)).Returns(Task.FromResult<Site>(site));

            //act
            var result = _controller.GetSiteById(id);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Theory]
        [InlineData(100)]
        public void Should_Return_Detele_OK(int id)
        {
            bool retVal = false;
            //Arrange
            _serviceMock.Setup(a => a.Delete(id)).Returns(Task.FromResult<bool>(retVal));

            //act
            var result = _controller.GetSiteById(id);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Should_Return_AddSite_OK()
        {
            //Arrange
            var retVal = true;
            CreateSiteDTO validSite = new CreateSiteDTO()
            {
                CreatedDateTime = System.DateTime.Now,
                Name = "sample name",
                URL = "www.sample.com"
            };

            _serviceMock.Setup(a => a.Add(It.IsAny<Site>())).Returns(Task.FromResult<bool>(retVal));

            //act
            var result = _controller.AddSite(validSite);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void Should_Return_AddSite_BadRequest()
        {
            //Arrange
            var retVal = true;

            CreateSiteDTO invalidSite = new CreateSiteDTO()
            {
                CreatedDateTime = System.DateTime.Now,
                Name = string.Empty,
                URL = "www.testUrl.com"
            };

            _serviceMock.Setup(a => a.Add(It.IsAny<Site>())).Returns(Task.FromResult<bool>(retVal));

            _controller.ModelState.AddModelError("Name", "The name is required");
            //act
            var result = _controller.AddSite(invalidSite);

            //assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

        [Fact]
        public void Should_Return_Update_OK()
        {
            //Arrange
            var retVal = true;
            UpdateSiteDTO validSite = new UpdateSiteDTO()
            {
                CreatedDateTime = System.DateTime.Now,
                Name = "my Site",
                SiteID = 1,
                URL = "www.mySite.com"
            };

            _serviceMock.Setup(a => a.Update(It.IsAny<Site>())).Returns(Task.FromResult<bool>(retVal));

            //act
            var result = _controller.UpdateSite(validSite);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void Should_Return_Update_BadRequest()
        {
            //Arrange
            var retVal = true;

            UpdateSiteDTO invalidSite = new UpdateSiteDTO()
            {
                CreatedDateTime = System.DateTime.Now,
                Name = "my site",
                SiteID = 0,
                URL = "www.mySite.com"
            };

            _serviceMock.Setup(a => a.Add(It.IsAny<Site>())).Returns(Task.FromResult<bool>(retVal));

            _controller.ModelState.AddModelError("SiteID", "SiteID is required");
            //act
            var result = _controller.UpdateSite(invalidSite);

            //assert
            Assert.IsType<BadRequestObjectResult>(result.Result);

        }

    }
}
