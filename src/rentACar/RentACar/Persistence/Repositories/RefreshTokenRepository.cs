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
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context):base(context)
        {
            
        }
        public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userID, int refreshTokenTTL)
        {
            List<RefreshToken> tokens =await Query()
                .AsNoTracking()
                .Where(
                    r=>
                        r.UsertId==userID 
                        && r.Revoked==null
                        && r.Expires >= DateTime.UtcNow
                        && r.CreatedDate.AddDays(refreshTokenTTL)<=DateTime.UtcNow
                    ).ToListAsync();
            return tokens;
        }
    }
}
