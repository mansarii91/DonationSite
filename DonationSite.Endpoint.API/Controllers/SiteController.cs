using AutoMapper;
using DonationSite.Core.Contracts;
using DonationSite.Core.Entities.Site;
using Mapster;
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
    public class SiteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SiteController(IUnitOfWork unitOfWork, ILogger<SiteController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{take:int}/{skip:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetAllSiteList(int take, int skip)
        {
            try
            {
                var allList = await _unitOfWork.SiteRepository.GetAllList(take,skip);
                var result = _mapper.Map<List<SiteDTO>>(allList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllSiteList)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSiteById(int id)
        {
            try
            {
                var data = await _unitOfWork.SiteRepository.GetById(id);
                var result = _mapper.Map<SiteDTO>(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetSiteById)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSite(int id)
        {
            try
            {
                var result = await _unitOfWork.SiteRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteSite)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSite([FromBody] CreateSiteDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(AddSite)}");
                    return BadRequest(ModelState);
                }

                var result = await _unitOfWork.SiteRepository.Add(_mapper.Map<Site>(model));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(AddSite)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSite([FromBody] UpdateSiteDTO model)
        {
            try
            {
                if (!ModelState.IsValid || model.SiteID < 1)
                {
                    _logger.LogError($"Invalid Update attempt in {nameof(UpdateSite)}");
                    return BadRequest(ModelState);
                }

                var result = await _unitOfWork.SiteRepository.Update(_mapper.Map<Site>(model));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateSite)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }
    }
}
