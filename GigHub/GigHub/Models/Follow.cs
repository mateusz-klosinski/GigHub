using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Follow
    {
        public ApplicationUser Follower { get; set; }

        public ApplicationUser Artist { get; set; }
    }
}