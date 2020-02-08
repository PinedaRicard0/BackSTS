using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;

namespace sts_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITournamentConfService _TournamentConfService;
        public TeamsController(ITournamentConfService TournamentConfService)
        {
            _TournamentConfService = TournamentConfService;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _TournamentConfService.AllCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("categorieteams/{id}")]
        public async Task<IActionResult> GetTeamsCategories(int id)
        {
            var teams = await _TournamentConfService.GetCategoryTeams(id);
            return Ok(teams);
        }
    }
}