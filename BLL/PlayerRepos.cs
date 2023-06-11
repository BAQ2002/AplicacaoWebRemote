using DAL.DBContext;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class PlayerRepos
    {

        public static void Add(TbPlayer _player)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_player);
                dbContext.SaveChanges();
            }
        }

        public static TbPlayer GetById(int Id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.Single(P => P.Id == Id);
                return player;
            }
        }

        public static List<TbPlayer> GetAll()
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var player = dbContext.TbPlayers.ToList();
                return player;
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


    }
}
