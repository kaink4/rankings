using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rankings.EntityFramework;
using Rankings.EntityFramework.Entities;


namespace Ratings.Web.Services
{
    public class RankingsService : IRankingsService
    {
        private readonly RankingsContext _context;

        public RankingsService(RankingsContext context)
        {
            _context = context;
        }

        public int AddRanking(Ranking ranking)
        {
            _context.Rankings.Add(ranking);
            _context.SaveChanges();

            return ranking.RankingId;
        }

        public void DeleteRanking(int rankingId)
        {
            var rankingToDelete = _context.Rankings.FirstOrDefault(x => x.RankingId == rankingId);
            if (rankingToDelete != null)
            {
                _context.Rankings.Remove(rankingToDelete);
                _context.SaveChanges();
            }
        }

        public Ranking GetRanking(int rankingId)
        {
            return _context.Rankings.FirstOrDefault(x => x.RankingId == rankingId);
        }


        public IEnumerable<Ranking> GetRankings()
        {
            return _context.Rankings.ToList();
        }

        public void UpdateRanking(Ranking ranking)
        {
            throw new NotImplementedException();
        }
    }
}
