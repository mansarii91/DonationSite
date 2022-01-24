﻿using AutoMapper;
using DonationSite.Core.Contracts;
using DonationSite.Core.Entities.Donate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DonationSite.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DonateController(IUnitOfWork unitOfWork, ILogger<SiteController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddDonate([FromBody] CreateDonateDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(AddDonate)}");
                    return BadRequest(ModelState);
                }
                var mapped = _mapper.Map<Donate>(model);
                var result = await _unitOfWork.DonateRepository.SubmitDonate(mapped);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(AddDonate)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }
    }
}
