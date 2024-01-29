using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
    {

        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {

        }
        public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
        {
           var operationClaims=await Query()
               .AsNoTracking()
               .Where(p=>p.UserId==userId)
               .Select(p=>new OperationClaim{Id=p.OperationClaimId,Name = p.OperationClaim.Name})
               .ToListAsync();

           return operationClaims;
        }
    }
}
