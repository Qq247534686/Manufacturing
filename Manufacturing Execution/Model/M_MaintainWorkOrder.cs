using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class M_MaintainWorkOrder
    {
        public int settingInformation { get; set; }
        public int productSerialNumberLength { get; set; }
        public int productSerialNumberprefix { get; set; }

        public string settingInformationText { get; set; }
        public int productSerialNumberText { get; set; }
        public string productSerialNumberprefixText { get; set; }

        public string productName { get; set; }
        public string workOrder { get; set; }
        public int isAcceptableQualityLevel { get; set; }
        public string serialNumber { get; set; }
    }
}
