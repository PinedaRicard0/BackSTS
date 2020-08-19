using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sts_web_api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MatchesController: ControllerBase
    {
        private readonly ITournamentConfService _ITournamentConfService;

        public MatchesController(ITournamentConfService tournamentConfService)
        {
            _ITournamentConfService = tournamentConfService;
        }

        [HttpGet]
        [Route("categorymatches/{categoryId}")]
        public async Task<IActionResult> GetCategoryMatches(int categoryId) {
            var r = await _ITournamentConfService.GetCategoryMatches(categoryId);
            return Ok(r);
        }
    }
}
