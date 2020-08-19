using AutoMapper;
using sts_models.DTO;
using sts_models.POCOS;
using System;

namespace sts_web_api.Others
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Team, TeamP>().
                ForMember(dest => dest.id, opt => opt.MapFrom(sour => sour.TeamId)).
                ForMember(dest => dest.name, opt => opt.MapFrom(sour => sour.Name)).
                ForMember(dest => dest.category, opt => opt.MapFrom(sour => sour.Pool.CategoryId.ToString())).
                ForMember(dest => dest.pool, opt => opt.MapFrom(sour => sour.Pool.Name)).
                ForMember(dest => dest.poolId, opt => opt.MapFrom(sour => sour.Pool.Id));

            CreateMap<TeamP, Team>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(sour => sour.name)).
                ForMember(dest => dest.PoolId, opt => opt.MapFrom(sour => Convert.ToInt32(sour.poolId))).
                ForMember(dest => dest.City, opt => opt.MapFrom(sour => "Medellín")).
                ForMember(dest => dest.Pool, opt => opt.MapFrom(sour => new Pool()));

            CreateMap<FieldP, Field>();
            CreateMap<Pool, PoolP>();
            CreateMap<PlayerP, Player>();
            CreateMap<Player, PlayerP>();

            CreateMap<Match, MatchP>().
                ForMember(dest => dest.TeamOneName, opt => opt.MapFrom(sour => sour.TeamOne.Name)).
                ForMember(dest => dest.TeamTwoName, opt => opt.MapFrom(sour => sour.TeamTwo.Name)).
                ForMember(dest => dest.FieldName, opt => opt.MapFrom(sour => sour.Field.Name)).
                ForMember(dest => dest.PoolName, opt => opt.MapFrom(sour => sour.Pool.Name));
            CreateMap<MatchP, Match>();
        }
    }
}
