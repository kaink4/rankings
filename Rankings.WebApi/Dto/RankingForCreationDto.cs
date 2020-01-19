using Ratings.Web.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rankings.WebApi.Dto
{
    public class RankingForCreationDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<ItemDto> Items { get; set; } = Enumerable.Empty<ItemDto>();
    }
}
