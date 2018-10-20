using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class TennisUserLogin : IdentityUserLogin<int>
    {
        public TennisUser User { get; set; }
    }
}
