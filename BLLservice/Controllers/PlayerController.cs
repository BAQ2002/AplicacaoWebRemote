using Microsoft.AspNetCore.Mvc;
using BLL;
using MODEL;
using System.Linq.Expressions;

namespace BLLservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlayerController: ControllerBase
    {

        [HttpGet(Name = "GetPlayer")]
        public ActionResult<List<TbPlayer>> GetPlayer()
        {
            try
            {
                List<TbPlayer> list = PlayerRepos.GetAll();
                if (list != null) { return Ok(list); }
                return NotFound();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpGet("{id}", Name = "GetPlayerById")]
        public ActionResult<TbPlayer> GetPlayerById(int id)
        {
        TbPlayer _player = PlayerRepos.GetById(id);
        
            try
            {                
                if (_player != null) 
                { 
                    return Ok(_player); 
                }
                return NotFound();
            }
        
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //[HttpGet("{Username}", Name = "GetPlayerByUsername")]
        //public ActionResult<TbPlayer> GetPlayerByUsername(string username)
        //{
        //   TbPlayer _player = PlayerRepos.GetByUsername(username);
        //
        //   try
        //   {
        //      if (_player != null) { return Ok(_player); }
        //       return NotFound();
        //   }

        //  catch (Exception ex)
        //  {
        //     return StatusCode(500, ex.Message);
        //  }
        //}


        [HttpPost(Name = "AddPlayer")]
        public ActionResult<TbPlayer> AddPlayer(TbPlayer player)
        {            
            try
            {
                PlayerRepos.Add(player);
                TbPlayer _player = player;
                return _player == null ? NotFound() : Ok(_player) ;
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut(Name = "UpdatePlayer")]
        public ActionResult<TbPlayer> UpdatePlayer(TbPlayer player)
        {
            try
            {
                if(player != null) 
                {
                    TbPlayer _player = new TbPlayer();
                    _player.Username = player.Username;
                    PlayerRepos.Update(_player);

                    return Ok(_player);
                }
                return NotFound();
            }
                
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete(Name = "DeletePlayer")]
        public ActionResult DeletePlayer(int id)
        {
            try
            {
                var player = PlayerRepos.GetById(id);
                PlayerRepos.Excluir(player);
                return Ok(player);
                
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

