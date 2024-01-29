using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(destinationMember:c=>c.BrandName,memberOptions:opt=>opt.MapFrom(c=>c.Brand.Name))
                .ForMember(destinationMember:c=>c.FuelName,memberOptions:opt=>opt.MapFrom(c=>c.Fuel.Name))
                .ForMember(destinationMember:c=>c.TransmissionName,memberOptions:opt=>opt.MapFrom(c=>c.Transmission.Name))
                .ReverseMap();
            CreateMap<Model, GetByIdModelResponse>()
                .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
                .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
                .ReverseMap();
            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
                .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
                .ReverseMap();
            CreateMap<Paginate<Model>,GetListResponse<GetListModelListItemDto>>().ReverseMap();
            CreateMap<Paginate<Model>,GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
        }
    }
}
