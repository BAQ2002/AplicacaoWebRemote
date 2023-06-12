using DAL.DBContext;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class MatchRepos
    {
        public static void Add(TbMatch _tbMatch)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_tbMatch);
                dbContext.SaveChanges();

            }
        }
        public static Match GetById(int id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.Single(P => P.Id == id);

                Match match = MatchCronc(_tbMatch);
               
                return match;

            }
        }
        public static List<Match> GetAll()
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.ToList();
                 
                List<Match> list = new List<Match>();

                foreach (TbMatch m in _tbMatch)
                {
                    list.Add(MatchCronc(m));
                }
                return list;
            }
        }



        private static Match MatchCronc(TbMatch _tbMatch)
        {
            Match match = new Match();
            match.Id = _tbMatch.Id;
            match.WinsBlue = _tbMatch.WinsBlue;
            match.WinsRed = _tbMatch.WinsRed;
            match.Date = _tbMatch.Date;

            match.TeamBlue = PlayerInMatchRepos.GetByTeam(_tbMatch.TeamBlue);
            match.TeamRed = PlayerInMatchRepos.GetByTeam(_tbMatch.TeamRed);

            return match;
        }


    }
}