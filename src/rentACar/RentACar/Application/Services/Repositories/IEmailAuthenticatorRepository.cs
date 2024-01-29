using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IEmailAuthenticatorRepository:IAsyncRepository<EMailAuthenticator,int>,IRepository<EMailAuthenticator,int>
    {
    }
}
