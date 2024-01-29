using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;

namespace Core.Security.Entities;

public class EMailAuthenticator:Entity<int>
{
    public int UserId { get; set; }
    public string ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; } = null!;

    public EMailAuthenticator()
    {
        
    }

    public EMailAuthenticator(int userId,bool isVerified)
    {
        UserId=userId;
        IsVerified=isVerified;
    }

    public EMailAuthenticator(int id, int userId, bool isVerified):base(id)
    {
        UserId = userId;
        IsVerified=isVerified;

    }

}