using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.BLL
{
    class CategoryBLL
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime addedDate { get; set; }

        public int added_by { get; set; }

    }
}
