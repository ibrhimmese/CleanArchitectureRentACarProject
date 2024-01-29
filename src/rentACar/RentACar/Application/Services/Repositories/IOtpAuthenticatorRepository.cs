using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IOtpAuthenticatorRepository:IAsyncRepository<OtpAuthenticator,int>, IRepository<OtpAuthenticator,int>
    {
    }
}
