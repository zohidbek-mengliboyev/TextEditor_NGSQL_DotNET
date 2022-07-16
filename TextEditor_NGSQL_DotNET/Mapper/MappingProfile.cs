using AutoMapper;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.Model;

namespace TextEditor_NGSQL_DotNET.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostContent, Post>().ReverseMap();
        }
    }
}
