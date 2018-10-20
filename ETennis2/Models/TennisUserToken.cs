using ETennis2.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETennis2.Models
{
    public class TennisUserToken : IdentityUserToken<int>
    {
        public virtual TennisUser User { get; set; }
    }
}
