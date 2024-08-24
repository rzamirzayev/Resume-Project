using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    class ClaimsTransformation : IClaimsTransformation
    {
        private DbContext db;

        public ClaimsTransformation(DbContext db) {
            this.db = db;
                }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal.Identity is ClaimsIdentity identity && identity.IsAuthenticated
            && int.TryParse(identity.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "", out int userId))
        {

            var queryRoles = from r in db.Set<ResumeRole>()
                             join ur in db.Set<ResumeUserRole>() on r.Id equals ur.RoleId
                             where ur.UserId == userId
                             select r;


            var roles = await queryRoles.Select(m => m.Name).ToListAsync();

            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            var claims = await (from r in queryRoles
                                join rc in db.Set<ResumeRoleClaim>() on r.Id equals rc.RoleId
                                where "1".Equals(rc.ClaimValue)
                                select rc.ClaimType)
                         .Union(from uc in db.Set<ResumeUserClaim>()
                                where "1".Equals(uc.ClaimValue) && uc.UserId == userId
                                select uc.ClaimType).ToListAsync();

            foreach (var claimType in claims)
            {
                identity.AddClaim(new Claim(claimType, "1"));
            } 
        }

        return principal;
    }
}
}
