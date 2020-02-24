using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sts_i_services;
using sts_models.POCOS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sts_web_api.Controllers
{
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

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
