using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rankings.EntityFramework.Entities;
using Rankings.WebApi.Dto;
using Ratings.Web.Services;

namespace Rankings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : BaseController
    {
        private readonly IRankingsService _rankingService;

        public RankingsController(IMapper mapper, IRankingsService rankingsService) 
            : base(mapper)
        {
            _rankingService = rankingsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RankingDto>> GetRankings()
        {
            var rankings = _rankingService.GetRankings();
            var rankingsDto = _mapper.Map<IEnumerable<RankingDto>>(rankings);
            return Ok(rankingsDto);
        }

        [HttpGet]
        [HttpHead]
        [Route("{rankingId}", Name = nameof(GetRanking))]
        public ActionResult<RankingDto> GetRanking([FromRoute]int rankingId)
        {
            var ranking = _rankingService.GetRanking(rankingId);
           
            if(ranking == null)
            {
                return NotFound();
            }

            var rankingsDto = _mapper.Map<RankingDto>(ranking);

            return Ok(rankingsDto);
        }

        [HttpPost]
        public ActionResult<RankingDto> CreateRanking(RankingForCreationDto rankingForCreationDto)
        {
            var ranking = _mapper.Map<Ranking>(rankingForCreationDto);
            _rankingService.AddRanking(ranking);

            var rankingToReturn = _mapper.Map<RankingDto>(ranking);

            return CreatedAtRoute(
                nameof(GetRanking),
                new { rankingId = ranking.Id },
                rankingToReturn);
        }

        [HttpOptions]
        public IActionResult GetRankingsOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }

    }

}