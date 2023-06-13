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
        public static TbMatch Add(Match _match)
        {

            TbMatch _tbMatch = new TbMatch();

            foreach (TbPlayerInMatch m in _match.TeamBlue) {
                m.IdTeam = _tbMatch.TeamBlue; 
                PlayerInMatchRepos.Add(m);
                PlayerRepos.PlayerTracker(m);
            }
            foreach (TbPlayerInMatch m in _match.TeamRed) {
                m.IdTeam = _tbMatch.TeamRed; 
                PlayerInMatchRepos.Add(m);
                PlayerRepos.PlayerTracker(m);
            }

            _tbMatch.Id = _match.Id;
            _tbMatch.Date = _match.Date;
            _tbMatch.WinsRed = _match.WinsRed;
            _tbMatch.WinsBlue = _match.WinsBlue;

            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
               
                //dbContext.
                dbContext.Add(_tbMatch);
                dbContext.SaveChanges();

            }
            return _tbMatch;
        }

        public static Match GetById(int id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.Single(P => P.Id == id);

                Match match = MatchBuilder(_tbMatch);
               
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
                    list.Add(MatchBuilder(m));
                }
                return list;
            }
        }

        private static Match MatchBuilder(TbMatch _tbMatch)
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