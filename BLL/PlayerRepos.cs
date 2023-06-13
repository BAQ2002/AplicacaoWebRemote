using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PlayerRepos
    {

        public static void Add(TbPlayer _player)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_player);
                dbContext.SaveChanges();
            }
        }

        public static TbPlayer GetById(int id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.Single(P => P.Id == id);
                return player;
            }
        }
        public static TbPlayer GetByUsername(string username)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.Single(P => P.Username == username);
                return player;
            }
        }

        public static List<TbPlayer> GetAll()
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _player = dbContext.TbPlayers.ToList();
                return _player;
            }
        }


        public static void Excluir(TbPlayer _player)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.Single(P => P.Id == _player.Id);
                dbContext.Remove(player);
                dbContext.SaveChanges();
            }
        }

        public static void Update(TbPlayer _player)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.Single(P => P.Id == _player.Id);
                player.Username = _player.Username;
                dbContext.SaveChanges();
            }

        }

        public static TbPlayer PlayerBuilder(int Id)
        {  

            TbPlayer _player = new TbPlayer();
            
            _player.Kills = PlayerInMatchRepos.GetByPlayerId(Id).Sum(pInMatch => pInMatch.Kills);                
            _player.Deaths = PlayerInMatchRepos.GetByPlayerId(Id).Sum(pInMatch => pInMatch.Deaths);
            _player.Assists = PlayerInMatchRepos.GetByPlayerId(Id).Sum(pInMatch => pInMatch.Assists); 
            _player.Experience = PlayerInMatchRepos.GetByPlayerId(Id).Sum(pInMatch => pInMatch.Points);
            _player.Level = (int)Math.Ceiling((double)_player.Experience / 10000);            
            _player.Rank = (int)Math.Ceiling((double)_player.Mmr / 100);
            _player.Wins = 
            _player.Mmr = _player.Wins * 25 - _player.Losses * 25;

            return _player;
        }





    }
}
