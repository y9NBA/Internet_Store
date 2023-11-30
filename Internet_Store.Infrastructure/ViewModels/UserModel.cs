using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserModel
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long RoleID {  get; set; }
        public Role Role { get; set; }
        public PersonModel Person { get; set; }
        public List<Custom> Customs { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Good> Goods { get; set; }
    }
}
