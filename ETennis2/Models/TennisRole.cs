﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class TennisRole : IdentityRole<int>
    {
        public ICollection<TennisUserRole> UserRoles { get; set; }
    }
}
