using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CurrentUser
    {
        public static User User { get; set; }
        public static Role Role { get; set; }
    }
}
