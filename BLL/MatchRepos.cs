using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
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
        public static Match Add(Match _match)
        {

            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                TbMatch _tbMatch = new TbMatch();

                _tbMatch.Id = _match.Id;
                _tbMatch.Date = _match.Date;
                _tbMatch.WinsRed = _match.WinsRed;
                _tbMatch.WinsBlue = _match.WinsBlue;
                _tbMatch.TeamBlue = (_tbMatch.Id * 10) + 2;
                _tbMatch.TeamRed = (_tbMatch.Id * 10) + 1;
                dbContext.Add(_tbMatch);
                dbContext.SaveChanges();

                PlayerInMatchRepos.addByTeam(_match.TeamRed);
                PlayerInMatchRepos.addByTeam(_match.TeamBlue);

                return MatchRepos.MatchBuilder(_tbMatch);

            }

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

        public static List<Match> GetByPlayerId(int id) 
        { 
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext()) 
            {   
                List<Match> list = new List<Match>(); var PinMatch = PlayerInMatchRepos.GetByPlayerId(id);
                    foreach (TbPlayerInMatch P in PinMatch)
                    {    
                        int idMatch = P.IdTeam / 10;
                        var Match = MatchRepos.MatchBuilder(MatchRepos.tbMacthById(idMatch));
                        list.Add(Match); 
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

        public static TbMatch tbMacthById(int id)
        {

            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.Single(P => P.Id == id);

                return _tbMatch;
            }
        }

        public static bool checkWin(int _idteam)
        {

            int idPartida;
            if (_idteam % 2 == 0) { idPartida = (_idteam - 2) / 10; }
            else { idPartida = (_idteam - 1) / 10; }

            var partida = tbMacthById(idPartida);

            if (_idteam % 2 == 0)
            {
                if (partida.WinsBlue > partida.WinsRed) { return true; } else { return false; }

            }
            else
            {
                if (partida.WinsRed > partida.WinsBlue) { return true; } else { return false; }
            }

        }
    }
}