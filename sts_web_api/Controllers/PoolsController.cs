using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;

namespace sts_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private readonly ITournamentConfService _ITournamentConfService;

        public PoolsController(ITournamentConfService tournamentConfService)
        {
            _ITournamentConfService = tournamentConfService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("categorypoolsstatistics/{id}")]
        public async Task<ActionResult> CategoryPoolsTeamsAndStatistics(string id) {
            try {
                int categoryId = Int32.Parse(id);
                var response =  await _ITournamentConfService.GetPoolsAndStatisticOfCategory(categoryId);
                return Ok(response);
            }
            catch (Exception) {
                return BadRequest("Invalid pool id");
            }
            
        }
    }
}