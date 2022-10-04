using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_and_register_system
{
    internal class Receipt
    {
        public int รายการ2 { get; set; }
        public string nameProduct2 { get; set; }
        public int qty2 { get; set; }
        public double cost2 { get; set; }
        public string Total { get { return string.Format("{0}$", qty2 * cost2); } }


    }
}
