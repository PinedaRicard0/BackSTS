using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using sts_models.POCOS;

namespace sts_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly ITournamentConfService _TournamentConfService;
        public PlayersController(ITournamentConfService tournamentConfService)
        {
            _TournamentConfService = tournamentConfService;
        }

        // GET: api/Players
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Players/5
        [HttpGet]
        [Route("getteamplayers/{id}")]
        public async Task<IActionResult> GetPlayerOfTeam(int id)
        {
            var r = await _TournamentConfService.GetTeamPlayers(id);
            return Ok(r);
        }

        // POST: api/Players
        [HttpPost]
        [Route("addteamplayer")]
        public async Task<IActionResult> AddPlayer(PlayerP player)
        {
            var r = await _TournamentConfService.AddPlayerToTeam(player);
            return Json(r);
        }

        // PUT: api/Players/5
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put(PlayerP player)
        {
            var r = await _TournamentConfService.UpdatePlayer(player);
            return Json(r);
        }
    }
}
