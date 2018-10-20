using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class TennisUserClaim : IdentityUserClaim<int>
    {
        public TennisUser User { get; set; }
    }
}
