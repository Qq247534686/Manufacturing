using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 随工单具体信息类
    /// </summary>
    public class M_SpecificInformation
    {
        public string workOrderNumberOne { get; set; }//随工单序号1
        public string workOrderNumberTow { get; set; }//随工单序号2
        public DateTime deliveryDate { get; set; }//交货日期
        public DateTime orderDate { get; set; }//下单日期
        public string contractNumber { get; set; }//合同书编号
        public string specificationNumber { get; set; }//规格书编号
        public string tbleNumber { get; set; }//表格编号

        public string LD_One { get; set; }
        public string LD_Tow { get; set; }
        public string LD_Three { get; set; }

        public string PT_One { get; set; }
        public string PT_Tow { get; set; }
        public string PT_Three{ get; set; }

        public string monoblockOne { get; set; }
        public string monoblockTow { get; set; }
        public string monoblockThree { get; set; }

        public string zeroFilterChipOne { get; set; }
        public string zeroFilterChipTow { get; set; }
        public string zeroFilterChipThree { get; set; }

        public string fortyFiveFilterChipOne { get; set; }
        public string fortyFiveFilterChipTow { get; set; }
        public string fortyFiveFilterChipThree { get; set; }

        public string interfaceModuleOne { get; set; }
        public string interfaceModuleTow{ get; set; }
        public string interfaceModuleThree { get; set; }

        public string equipmentNumberOne { get; set; }
        public string equipmentNumberTow { get; set; }
        public string equipmentNumberThree { get; set; }
        public string equipmentNumberFour { get; set; }

        public int uploadQuantity { get; set; }
        public DateTime uploadTime { get; set; }
        public int unqualifiedQuantity { get; set; }
        public int consoleOneFirstText { get; set; }
        public string consoleOneLastText { get; set; }
        public int consoleTowFirstText { get; set; }
        public string consoleTowLastText { get; set; }
        public int consoleThreeFirstText { get; set; }
        public string consoleThreeLastText { get; set; }
        public int consoleFourFirstText { get; set; }
        public string consoleFourLastText { get; set; }
        public int dataEntryStaffFirstText { get; set; }
        public string dataEntryStaffLastText { get; set; }

        public int filterChipError { get; set; }
        public int weldError { get; set; }
        public int LDError { get; set; }
        public int exceed { get; set; }
        public int pressure { get; set; }
        public int LD_Threshold { get; set; }
        public int markingError { get; set; }
        public int monoblockError { get; set; }
        public int slugError { get; set; }
        public string theOther { get; set; }
        public int theQuantity { get; set; }

        public string serialNumberOne { get; set; }
        public string serialNumberTow { get; set; }
        public string serialNumberThree { get; set; }
        public string CASE_One { get; set; }
        public string CASE_Tow{ get; set; }
        public string CASE_Three { get; set; }
        public string LD_AddOne { get; set; }
        public string LD_AddTow { get; set; }
        public string LD_AddThree { get; set; }
        public string LD_AddFour { get; set; }
        public string LD_AddFive{ get; set; }
        public string LD_AddSix{ get; set; }
        public string LD_MinusOne { get; set; }
        public string LD_MinusTow { get; set; }
        public string LD_MinusThree { get; set; }
        public string rangeOne { get; set; }
        public string rangeTow { get; set; }
        public string rangeThree { get; set; }
        public string concaveCnvexOne { get; set; }
        public string concaveCnvexTow { get; set; }
        public string concaveCnvexThree { get; set; }
        public string slugFocal { get; set; }
        public string inspectionPersonal { get; set; }
        public string checker { get; set; }
        public string remarks { get; set; }
        public DateTime createTime { get; set; }

    }
}
