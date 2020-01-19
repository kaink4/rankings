using AutoMapper;
using Rankings.EntityFramework.Entities;
using Rankings.WebApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rankings.WebApi.Profiles
{
    public class RankingsProfile : Profile
    {
        public RankingsProfile()
        {
            CreateMap<Ranking, RankingDto>();
            CreateMap<RankingForCreationDto, Ranking>();
        }
    }
}
