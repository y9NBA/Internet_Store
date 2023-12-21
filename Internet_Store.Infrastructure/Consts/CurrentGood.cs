using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CurrentGood
    {
        public static Good Good { get; set; } = null;
        public static bool isOrder {  get; set; } = false;
        public static bool isEditing { get; set;} = false;
    }
}
