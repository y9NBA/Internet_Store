using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_Store
{
    internal class Singleton
    {
        public static Entities DB { get; } = new Entities();
    }
}
