using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rankings.EntityFramework.Entities;
using Rankings.WebApi.Controllers;
using Rankings.WebApi.Dto;
using Ratings.Web.Services;
using System;
using System.Linq;
using Xunit;

namespace Ratings.Web.Tests
{
    public class RankingsControllerTests : IDisposable
    {
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IRankingsService> _rankingsServiceMock = new Mock<IRankingsService>();

        public RankingsControllerTests()
        {
            _rankingsServiceMock.Reset();
            _mapperMock.Reset();
        }



        [Fact]
        public void GetRankingOk()
        {
            _rankingsServiceMock
                .Setup(x => x.GetRanking(It.IsAny<int>()))
                .Returns(new Ranking());

            var rankingsController = new RankingsController(_mapperMock.Object, _rankingsServiceMock.Object);

            var response = rankingsController.GetRanking(-1);

            response.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetRankingNotFound()
        {
            _rankingsServiceMock
                .Setup(x => x.GetRanking(It.IsAny<int>()))
                .Returns((Ranking)null);

            var rankingsController = new RankingsController(_mapperMock.Object, _rankingsServiceMock.Object);

            var response = rankingsController.GetRanking(10);

            response.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetRankingsOk()
        {
            _rankingsServiceMock
                .Setup(x => x.GetRankings())
                .Returns(Enumerable.Empty<Ranking>());

            var rankingsController = new RankingsController(_mapperMock.Object, _rankingsServiceMock.Object);

            var response = rankingsController.GetRankings();

            response.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void CreateRankingBadRequest()
        {
            _rankingsServiceMock
                .Setup(x => x.AddRanking(It.IsAny<Ranking>()));

            var rankingsController = new RankingsController(_mapperMock.Object, _rankingsServiceMock.Object);
          
            var response = rankingsController.CreateRanking(null);

            response.Result.Should().BeOfType<BadRequestResult>();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
