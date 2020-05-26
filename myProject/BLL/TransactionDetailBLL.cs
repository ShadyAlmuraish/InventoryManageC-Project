using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.BLL
{
    class TransactionDetailBLL
    {
        public int Id { get; set; }
        public int product_id { get; set; }
        public decimal rate { get; set; }
        public decimal  qty { get; set; }
        public decimal total { get; set; }
        public int customer_id { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

    }
}
