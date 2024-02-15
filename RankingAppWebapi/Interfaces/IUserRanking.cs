using RankingAppWebapi.Models;

namespace RankingAppWebapi.Interfaces
{
    public interface IUserRanking
    {
        List<SampleUserRanking> GetAllUserRankings();

        SampleUserRanking UpdateRanking(SampleUserRanking updateRanking,int id);
    }
}
