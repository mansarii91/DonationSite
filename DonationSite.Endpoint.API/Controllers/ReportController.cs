using AutoMapper;
using DonationSite.Core.Contracts;
using DonationSite.Core.Entities.Report;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationSite.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ReportController(IUnitOfWork unitOfWork, ILogger<SiteController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{siteId:int}/{take:int}/{skip:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetDonateSiteReport(int siteId, int take, int skip)
        {
            try
            {
                var reportData = await _unitOfWork.ReportRepository.GetDonatioSiteReport(siteId,take,skip);
                var result = _mapper.Map<List<DonateReportDTO>>(reportData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonateSiteReport)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpGet("{siteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetDonateSiteReportTotalCount(int siteId)
        {
            try
            {
                var totalCount = await _unitOfWork.ReportRepository.GetDonatioSiteReportTotalCount(siteId);
                return Ok(totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonateSiteReport)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpGet("{take:int}/{skip:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetDonationReport(int take, int skip)
        {
            try
            {
                var reportData = await _unitOfWork.ReportRepository.GetDonationReport(take,skip);
                return Ok(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonationReport)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetDonationReportTotalCount()
        {
            try
            {
                var totalCount = await _unitOfWork.ReportRepository.GetDonationReportTotalCount();
                return Ok(totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonationReport)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }


    }
}
