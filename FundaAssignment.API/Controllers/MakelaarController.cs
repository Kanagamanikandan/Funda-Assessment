using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FundaAssignment.Services;
namespace FundaAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakelaarController : ControllerBase
    {
        private IObjectService _objectService;
        public MakelaarController(IObjectService objectService)
        {
            _objectService = objectService;
        }
        public async Task<IActionResult> GetTop10MakelaarsInAmsterdam()
        {
            var top10makelaars = await _objectService.GetTop10MakelaarsInAmsterdam(false);
            return Ok(top10makelaars);
        }

        [Route("tuin")]
        public async Task<IActionResult> GetTop10MakelaarsInAmsterdamWithTuin()
        {
            var top10makelaars = await _objectService.GetTop10MakelaarsInAmsterdam(true);
            return Ok(top10makelaars);
        }
    }
}