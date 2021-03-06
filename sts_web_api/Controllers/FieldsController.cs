﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using sts_models.POCOS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sts_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : Controller
    {
        private readonly ITournamentConfService _TournamentConfService;

        public FieldsController(ITournamentConfService tournamentConfService)
        {
            _TournamentConfService = tournamentConfService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFields()
        {
           return Ok( await _TournamentConfService.AllFields());
        }

        [HttpPost]
        public async Task<ActionResult> CreateField(FieldP field) {
            var r = await _TournamentConfService.CreateField(field);
            return Json(r);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateField(FieldP field) {
            var r = await _TournamentConfService.UpdateField(field);
            return Json(r);
        }

    }
}
