using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RankingAppWebapi.Interfaces;
using RankingAppWebapi.Models;

namespace RankingAppWebapi.DataAcceslayer
{
    public class UserRankingDAL : IUserRanking
    {
        private readonly KcOasContext _kcOasContext;
        public UserRankingDAL(KcOasContext kcOasContext)
        {

            _kcOasContext = kcOasContext;

        }
        public List<SampleUserRanking> GetAllUserRankings()
        {
            List<SampleUserRanking> userRanking = (from user in _kcOasContext.SampleUserRankings
                                                   orderby user.Ranking
                                       select user).ToList();
            return userRanking;
        }

        public SampleUserRanking UpdateRanking(SampleUserRanking updateRanking, int id)
        {
            // deleting record Updated Record
            var deleteRecord = _kcOasContext.SampleUserRankings.Find(id);
            _kcOasContext.SampleUserRankings.Remove(deleteRecord);
            _kcOasContext.SaveChanges();

            //update each records
            if (updateRanking.Ranking < deleteRecord.Ranking)
            {
                var Decrementing = from record in _kcOasContext.SampleUserRankings
                                      where record.Ranking >= updateRanking.Ranking && deleteRecord.Ranking >= record.Ranking
                                   select record;
                foreach (var item in Decrementing)
                {
                    item.Ranking ++;
                }
            }

            var updatingRecords = from record in _kcOasContext.SampleUserRankings
                                  where record.Ranking >= deleteRecord.Ranking && record.Ranking <= updateRanking.Ranking
                                  select record;
            foreach (var item in updatingRecords)
            {
                item.Ranking -= 1;
            }
            _kcOasContext.SaveChanges();

            //Adding new Record
            var postTheResult = _kcOasContext.SampleUserRankings.Add(updateRanking);
            _kcOasContext.SaveChanges();
            return deleteRecord;
        }

       
    }
}
