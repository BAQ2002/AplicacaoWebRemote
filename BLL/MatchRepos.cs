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
        public static TbMatch GetById(int id)
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.Single(P => P.Id == id);
                return _tbMatch;
            }
        }
        public static List<TbMatch> GetAll()
        {
            using (var dbContext = new CUsersAntonSourceReposAplicacaowebDalDatabaseDatabase1MdfContext())
            {
                var _tbMatch = dbContext.TbMatches.ToList();
                return _tbMatch;
            }
        }


    }
}