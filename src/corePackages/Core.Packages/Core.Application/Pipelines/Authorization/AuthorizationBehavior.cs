using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Constants;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
    where TRequest : IRequest<Tresponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor= httpContextAccessor;
        }
        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            if (userRoleClaims == null)
                throw new AuthorizationException("You are not authenticated.");
            bool isNotMatchedAUserRoleClaimWithRequestRoles=userRoleClaims
                .FirstOrDefault(
                    userRoleClaim=>userRoleClaim==GeneralOperationClaims.Admin || request.Roles.Any(role=>role==userRoleClaim)
                     ).IsNullOrEmpty();

            if (isNotMatchedAUserRoleClaimWithRequestRoles)
                    throw new AuthorizationException("You are not authorized");
                
                Tresponse response = await next();

                return response;
        }
    }
}
