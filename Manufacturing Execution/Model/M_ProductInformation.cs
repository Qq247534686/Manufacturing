using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 产品信息类
    /// </summary>
    public class M_ProductInformation
    {
        public string productName { get; set; }
        public string customerInformation { get; set; }
        public string productNumber  { get; set; }
        public string dataEntryStaff { get; set; }
        public DateTime entryTime { get; set; }
    }
}
