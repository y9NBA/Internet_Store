using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Singleton
    {
        public static Context DB { get; set; } = new Context();
    }
}
