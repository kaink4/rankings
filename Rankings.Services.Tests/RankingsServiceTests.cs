using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rankings.EntityFramework;
using Rankings.EntityFramework.Entities;
using Ratings.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ratings.Services.Tests
{
    public class RankingsServiceTests
    {
        private RankingsContext GetContext(string databaseName) =>
             new RankingsContext(new DbContextOptionsBuilder<RankingsContext>()
                       .UseInMemoryDatabase(databaseName: databaseName)
                       .EnableDetailedErrors()
                       .EnableSensitiveDataLogging()
                       .Options);
        

        [Fact]
        public void AddRanking()
        {
            var guid = Guid.NewGuid().ToString();

            using (var context = GetContext(guid))
            {
                context.Rankings.AddRange(
                    new Ranking()
                    {
                        Items = new List<Item>(),
                        Title = "empty",
                        Description = "empty"
                    },
                   new Ranking()
                   {
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   });

                context.SaveChanges();
            }

            int newRankingId;
            using (var context = GetContext(guid))
            {
                var ranking = new Ranking
                {
                    Title = "new title",
                    Description = "new description",
                };

                var rankingService = new RankingsService(context);

                newRankingId = rankingService.AddRanking(ranking);
            }

            using (var context = GetContext(guid))
            {
                context.Rankings.Count().Should().Be(3);

                var expected = new Ranking
                {
                    RankingId = newRankingId,
                    Title = "new title",
                    Description = "new description",
                    Items = new List<Item>()
                };

                var ranking = context.Rankings.First(x => x.RankingId == newRankingId);
                ranking.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void DeleteRanking()
        {
            var guid = Guid.NewGuid().ToString();

            using (var context = GetContext(guid))
            {
                context.Rankings.AddRange(
                    new Ranking()
                    {
                        RankingId = 1,
                        Items = new List<Item>(),
                        Title = "empty",
                        Description = "empty"
                    },
                   new Ranking()
                   {
                       RankingId = 2,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   },
                   new Ranking()
                   {
                       RankingId = 3,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   });

                context.SaveChanges();
            }

            using (var context = GetContext(guid))
            {
                var rankingService = new RankingsService(context);

                rankingService.DeleteRanking(2);
            }

            using (var context = GetContext(guid))
            {
                context.Rankings.Count(x => x.RankingId == 2).Should().Be(0);
            }
        }

        [Fact]
        public void GetRanking()
        {
            var guid = Guid.NewGuid().ToString();

            using (var context = GetContext(guid))
            {
                context.Rankings.AddRange(
                    new Ranking()
                    {
                        RankingId = 1,
                        Items = new List<Item>(),
                        Title = "empty",
                        Description = "empty"
                    },
                   new Ranking()
                   {
                       RankingId = 2,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   },
                   new Ranking()
                   {
                       RankingId = 3,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   });

                context.SaveChanges();
            }

            using (var context = GetContext(guid))
            {
                var rankingService = new RankingsService(context);

                var ranking = rankingService.GetRanking(2);

                var expected = new Ranking
                {
                    RankingId = 2,
                    Items = new List<Item>(),
                    Title = "empty2",
                    Description = "empty2"
                };

                ranking.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void GetRankingIfNotExistReturnNull()
        {
            var guid = Guid.NewGuid().ToString();

            using (var context = GetContext(guid))
            {
                context.Rankings.AddRange(
                    new Ranking()
                    {
                        RankingId = 1,
                        Items = new List<Item>(),
                        Title = "empty",
                        Description = "empty"
                    },
                   new Ranking()
                   {
                       RankingId = 2,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   },
                   new Ranking()
                   {
                       RankingId = 3,
                       Items = new List<Item>(),
                       Title = "empty2",
                       Description = "empty2"
                   });

                context.SaveChanges();
            }

            using (var context = GetContext(guid))
            {
                var rankingService = new RankingsService(context);

                var ranking = rankingService.GetRanking(4);

                ranking.Should().BeNull();
            }
        }
    }
}
