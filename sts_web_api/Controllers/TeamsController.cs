using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using sts_models.POCOS;

namespace sts_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly ITournamentConfService _TournamentConfService;
        public TeamsController(ITournamentConfService TournamentConfService)
        {
            _TournamentConfService = TournamentConfService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateTeam(TeamP team) {
            var r = await _TournamentConfService.CreateTeams(team);
            return Json(r);
        }

        [HttpGet]
        [Route("getteam/{id}")]
        public async Task<IActionResult> GetTeamById(string id) {
            var r = await _TournamentConfService.GetTeamById(Int32.Parse(id));
            return Ok(r);
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

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateTeam(TeamP team)
        {
            var r = await _TournamentConfService.UpdateTeam(team);
            return Json(r);
        }
    }
}