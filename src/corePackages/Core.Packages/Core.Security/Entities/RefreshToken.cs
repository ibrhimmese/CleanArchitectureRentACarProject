using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;

namespace Core.Security.Entities;

public class RefreshToken:Entity<int>
{
    public int UsertId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }


    public virtual User User { get; set; } = null!;


    public RefreshToken()
    {
        Token = string.Empty;
        CreatedByIp= string.Empty;
    }

    public RefreshToken(int userId,string token, DateTime expires, string createdByIp)
    {
        UsertId=userId;
        Token=token;
        Expires=expires;
        CreatedByIp=createdByIp;
    }

    public RefreshToken(int id,int userId,string token,DateTime expires, string createdByIp):base(id)
    {
        UsertId = userId;
        Token=token;
        Expires=expires;
        CreatedByIp=createdByIp;
    }

}