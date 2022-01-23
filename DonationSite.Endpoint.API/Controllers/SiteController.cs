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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // for swagger documentation
        public async Task<IActionResult> GetAllList()
        {
            try
            {
                var allList = await _unitOfWork.SiteRepository.GetAllList();
                var result = _mapper.Map<List<SiteDTO>>(allList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllList)}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = _unitOfWork.SiteRepository.GetById(id);
                var result = _mapper.Map<SiteDTO>(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetById)}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _unitOfWork.SiteRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Delete)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CreateSiteDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(Add)}");
                    return BadRequest(ModelState);
                }

                var result = await _unitOfWork.SiteRepository.Add(_mapper.Map<Site>(model));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Add)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateSiteDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid Update attempt in {nameof(Update)}");
                    return BadRequest(ModelState);
                }

                var result = await _unitOfWork.SiteRepository.Update(_mapper.Map<Site>(model));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Update)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }
    }
}
