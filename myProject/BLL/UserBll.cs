using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.BLL
{
    class UserBll
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public string userName { get; set; }
        public string passWord { get; set; }

        public string Contact { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string user_type { get; set; }
        public DateTime addedDate { get; set; }
        public int addedBy { get; set; }

    }
}
