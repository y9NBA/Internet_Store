using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CurrentUser
    {
        public static UserModel User { get; set; } = null;
        public static string Role { get; set; } = "Покупатель";
    }
}
