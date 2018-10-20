using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ETennis2.Model
{
    public partial class TennisUser : IdentityUser<int>
    {
        public string Nickname { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<TennisUserRole> UserRoles { get; set; }
    }
}
