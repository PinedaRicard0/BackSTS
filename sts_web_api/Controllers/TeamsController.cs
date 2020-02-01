using System;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;

namespace sts_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITournamentConfService _CategoryService;
        public TeamsController(ITournamentConfService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult GetCategories()
        {
            var categories = _CategoryService.AllCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("categorieteams/{id}")]
        public IActionResult GetTeamsCategories(int id)
        {
            var teams = _CategoryService.GetCategoryTeams(id);
            return Ok(teams);
        }
    }
}