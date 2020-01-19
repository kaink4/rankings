using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ratings.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rankings.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : BaseController
    {
        public ItemsController(IMapper mapper) : base(mapper)
        {
        }




        [HttpGet]
        [Route("{rankingId}")]
        public ActionResult<IEnumerable<ItemDto>> GetItemsForRanking(int rankingId)
        {
            throw new NotImplementedException();
        }

    }
}
