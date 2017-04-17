using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class M_ImportPlan
    {
        public string id { get; set; }
        public string orderNumber { get; set; }
        public List<M_ListPlanInfo> m_ListWorkOrderInfo { get; set; }
        
    }
    public class M_ListPlanInfo
    {
        public string productName { get; set; }
        public string productCode { get; set; }
        public DateTime deliveryDate { get; set; }
        public string client { get; set; }
        public int productNumber { get; set; }
    }
}
