using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ratings.Web.Dto;
using Ratings.Web.Services;

namespace Rankings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : BaseController
    {
        private readonly IRankingsService _rankingService;

        public RankingsController(IMapper mapper, IRankingsService rankingsService) : base(mapper)
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
    }
}