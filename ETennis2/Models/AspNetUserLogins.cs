using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public TennisUser User { get; set; }
    }
}
