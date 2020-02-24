using AutoMapper;
using sts_models.DTO;
using sts_models.POCOS;

namespace sts_web_api.Others
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Team, TeamP>().
                ForMember(dest => dest.id, opt => opt.MapFrom(dest => dest.TeamId)).
                ForMember(dest => dest.name, opt => opt.MapFrom(dest => dest.Name)).
                ForMember(dest => dest.category, opt => opt.MapFrom(dest => dest.Pool.CategoryId.ToString())).
                ForMember(dest => dest.pool, opt => opt.MapFrom(dest => dest.Pool.Name));

            CreateMap<TeamP, Team>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.name)).
                ForMember(dest => dest.PoolId, opt => opt.MapFrom(dest => dest.pool));

            CreateMap<FieldP, Field>();
            CreateMap<Pool, PoolP>();
        }
    }
}
