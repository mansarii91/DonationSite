using AutoMapper;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Entities.Report;
using DonationSite.Endpoint.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DonationSite.Test
{
    public class ReportControllerTest
    {
        private ReportController _controller;
        private Mock<IReportService> _serviceMock;
        private Mock<ILogger<ReportController>> _loggerMock;
        private Mock<IMapper> _mapperMock;

        public ReportControllerTest()
        {
            _serviceMock = new Mock<IReportService>();
            _loggerMock = new Mock<ILogger<ReportController>>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ReportController(_serviceMock.Object, _loggerMock.Object, _mapperMock.Object);

        }

        [Theory]
        [InlineData(100, 10, 0)]
        public void Should_return_GetDonateSiteReport_OK(int siteId, int take, int skip)
        {
            //Arrange
            List<DonateReport> retList = new List<DonateReport>();
            retList.Add(new DonateReport()
            {
                Donator = "user1",
                SiteName = "google co",
                SiteURL = "www.google.com",
                Value = 1000
            });

            retList.Add(new DonateReport()
            {
                Donator = "user2",
                SiteName = "facebook co",
                SiteURL = "www.facebook.com",
                Value = 1200
            });

            _serviceMock.Setup(a => a.GetDonationSiteReport(siteId, take, skip)).Returns(Task.FromResult<IEnumerable<DonateReport>>(retList));

            //act
            var result = _controller.GetDonateSiteReport(siteId, take, skip);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Theory]
        [InlineData(100)]
        public void Should_return_GetDonateSiteReportTotalCount_OK(int siteId)
        {
            //Arrange
            long retVal = 1000;

            _serviceMock.Setup(a => a.GetDonatioSiteReportTotalCount(siteId)).Returns(Task.FromResult<long>(retVal));

            //act
            var result = _controller.GetDonateSiteReportTotalCount(siteId);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Theory]
        [InlineData(10, 0)]
        public void Should_return_GetDonationReport_OK(int take, int skip)
        {
            //Arrange
            List<DonateSite> retList = new List<DonateSite>();
            retList.Add(new DonateSite()
            {
                TotalDonation = 50000,
                SiteName = "google co",
                SiteURL = "www.google.com"

            });

            retList.Add(new DonateSite()
            {
                SiteName = "facebook co",
                SiteURL = "www.facecbook.com",
                TotalDonation = 90000
            });

            _serviceMock.Setup(a => a.GetDonationReport(take, skip)).Returns(Task.FromResult<IEnumerable<DonateSite>>(retList));

            //act
            var result = _controller.GetDonationReport(take, skip);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Should_return_GetDonationReportTotalCount_OK()
        {
            //Arrange
            long retVal = 1000;

            _serviceMock.Setup(a => a.GetDonationReportTotalCount()).Returns(Task.FromResult<long>(retVal));

            //act
            var result = _controller.GetDonationReportTotalCount();

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


    }
}
