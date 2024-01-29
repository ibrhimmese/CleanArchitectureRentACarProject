﻿using Core.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery:IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest,ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration {get;}

    public string? CacheGroupKey => "GetBrands";

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
           Paginate<Brand> brands= await _brandRepository.GetListAsync(
                index:request.PageRequest.PageIndex,
                size:request.PageRequest.PageSize,
                cancellationToken:cancellationToken
            );
            GetListResponse<GetListBrandListItemDto>response=_mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return response;
        }
    }

}