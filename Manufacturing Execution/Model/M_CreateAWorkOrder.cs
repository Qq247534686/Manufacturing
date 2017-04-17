using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class M_CreateAWorkOrder
    {
        public string id { get; set; }
        public string shopCode { get; set; }
        public string currentOperation { get; set; }
        public string singleType { get; set; }
        public string totalProduction { get; set; }
        public string orderNumber { get; set; }
        public string manufacturingProcess { get; set; }
        public string customerName { get; set; }
        public string poductCode { get; set; }
        public string orderMD5Number { get; set; }
        public DateTime createTime { get; set; }

    }
}
