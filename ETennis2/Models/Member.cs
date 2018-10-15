using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
    }
}
