using DonationSite.Core.Contracts;
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

        public ReportController(IUnitOfWork unitOfWork, ILogger<ReportController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}
