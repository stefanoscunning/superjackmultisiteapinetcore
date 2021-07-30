using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Superjack.MultiSites.Api.DataAccess;
using Superjack.MultiSites.Api.Dtos;

namespace Superjack.MultiSites.Api.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Block, BlockDto>().ReverseMap();
      CreateMap<BlockField, BlockFieldDto>().ReverseMap();
      CreateMap<PageBlock, PageBlockDto>().ReverseMap();
      CreateMap<Page, PageDto>().ReverseMap();
      CreateMap<PageField, PageFieldDto>().ReverseMap();
      CreateMap<PageType, PageTypeDto>().ReverseMap();
      CreateMap<Site, SiteDto>().ReverseMap();
      CreateMap<User, UserDto>().ReverseMap();
    }
  }
}
