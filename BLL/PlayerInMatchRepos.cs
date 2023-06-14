using DAL.DBContext;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PlayerInMatchRepos
    {
        public static void Add(TbPlayerInMatch _tbPlayerInMatch)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_tbPlayerInMatch);
                dbContext.SaveChanges();

            }
        }
        public static TbPlayerInMatch GetById(int id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbPlayerInMatch = dbContext.TbPlayerInMatches.Single(P => P.Id == id);
                return _tbPlayerInMatch;
            }
        }
        public static List<TbPlayerInMatch> GetAll()
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbPlayerInMatch = dbContext.TbPlayerInMatches.ToList();
                return _tbPlayerInMatch;
            }
        }

        public static List<TbPlayerInMatch> GetByTeam(int teamId)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var players = dbContext.TbPlayerInMatches.Where(p => p.IdTeam == teamId).ToList();
                return players;
            }
        }
        public static List<TbPlayerInMatch> GetByPlayerId(int playerId)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var playerMatchs = dbContext.TbPlayerInMatches.Where(p => p.IdPlayer == playerId).ToList();
                return playerMatchs;
            }
        }

        public static void TbPlayerInMatchBuilder(TbMatch _tbMatch)
        {
            TbPlayerInMatch _tbPlayerInMatch = new TbPlayerInMatch();
            
            string stringId = _tbMatch.Id.ToString() + _tbPlayerInMatch.IdPlayer.ToString() + _tbPlayerInMatch.IdPlayer.ToString();
            _tbPlayerInMatch.Id = int.Parse(stringId);
            _tbPlayerInMatch.IdTeam = _tbMatch.TeamRed;
            //_tbPlayerInMatch.IdPlayer = PlayerRepos.GetById(_tbPlayerInMatch.IdPlayer);
        }


        public static void addByTeam(List<TbPlayerInMatch> list)
        {
           foreach (var item in list) {PlayerInMatchRepos.Add(item); } }
        


    }
}