
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sts_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ITournamentConfService _TournamentConfService;
        public CategoriesController(ITournamentConfService TournamentConfService)
        {
            _TournamentConfService = TournamentConfService;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("categoriepools/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var r = await _TournamentConfService.GetCategoryPools(id);
            return Ok(r);
        }

        [HttpGet]
        [Route("canstart/{id}")]
        public async Task<IActionResult> CanStartCategorie(int id) {
            var r = await _TournamentConfService.CanStartCategorie(id);
            return Ok(r);
        }

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> StartCategorie([FromBody] int categoryId)
        {
            var r = await _TournamentConfService.StartCategory(categoryId);
            if (r.Equals("Started"))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
