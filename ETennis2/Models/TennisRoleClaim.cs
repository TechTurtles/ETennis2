using ETennis2.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETennis2.Models
{
    public class TennisRoleClaim : IdentityRoleClaim<int>
    {
        public virtual TennisRole Role { get; set; }
    }
}
