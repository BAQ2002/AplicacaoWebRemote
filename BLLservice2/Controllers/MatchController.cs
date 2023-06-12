using BLL;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System.Linq.Expressions;

namespace BLLservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MatchController: ControllerBase
    {

        [HttpGet(Name = "GetMatch")]
        public ActionResult<List<TbMatch>> GetMatch()
        {
            try
            {
                List<TbMatch> list = MatchRepos.GetAll();
                if (list != null) { return Ok(list); }
                return NotFound();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpGet("{id}", Name = "GetMatchById")]
        public ActionResult<TbMatch> GetMatchById(int id)
        {
            TbMatch _match = MatchRepos.GetById(id);

            try
            {
                if (_match != null) { return Ok(_match); }
                return NotFound();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost(Name = "AddMatch")]
        public ActionResult<TbMatch> AddMatch(TbMatch match)
        {
            try
            {
                MatchRepos.Add(match);
                TbMatch _match = match;
                return _match == null ? NotFound() : Ok(_match);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
