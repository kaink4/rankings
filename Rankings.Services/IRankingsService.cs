using System.Collections.Generic;
using Rankings.EntityFramework.Entities;

namespace Ratings.Web.Services
{
    public interface IRankingsService
    {
        int AddRanking(Ranking ranking);
        void DeleteRanking(int rankingId);
        Ranking GetRanking(int rankingId);
        IEnumerable<Ranking> GetRankings();
        void UpdateRanking(Ranking ranking);
    }
}