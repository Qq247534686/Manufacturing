using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 随工单公共信息类
    /// </summary>
   public class M_PublicInformation
   {
       public string workOrderNumber { get; set; }
        public DateTime deliveryDate { get; set; }
        public DateTime orderDate { get; set; }
        public string contractNumber { get; set; }//合同书编号
        public string specificationNumber { get; set; }//规格书编号
        public string tbleNumberOne { get; set; }//表格编号
        public string tbleNumberTow { get; set; }//表格编号

       public string productModel { get; set; }
       public string productCode { get; set; }
       public string productName { get; set; }
       public string productChartNumber { get; set; }
       public string stockNumber { get; set; }
       public string clientCode { get; set; }
       public string preparationOfInvoiceNumber { get; set; }
       public string WithTheNumberOfWorkers { get; set; }

       public string surfaceOfA { get; set; }
       public string surfaceOfB { get; set; }
       public string surfaceOfCOne { get; set; }
       public string surfaceOfCTow { get; set; }

       public string LD_Focal { get; set; }
       public string weldingMethod { get; set; }
       public string endFaceQuality { get; set; }
       public string cycleIndex { get; set; }

       public string powerBeforeWeldingOne { get; set; }
       public string powerBeforeWeldingTow { get; set; }
       public string powerBeforeWeldedOne { get; set; }
       public string powerBeforeWeledTow { get; set; }
       public string fiberPower { get; set; }
       public string photocurrentOne { get; set; }
       public string photocurrentTow { get; set; }
       public string testPowerOne { get; set; }
       public string testPowerTow { get; set; }
       public string LD_Kink { get; set; }
       public string PD_Kink { get; set; }
       public string testConditionOne { get; set; }
       public string testConditionTow{ get; set; }
       public string  sensitivityOne { get; set; }
       public string sensitivityTow { get; set; }
       public string ICCOne { get; set; }
       public string ICCTow { get; set; }

       public string photoelectricityIf { get; set; }
       public string factoryPowerOne { get; set; }
       public string factoryPowerTow { get; set; }
       public string photoelectricityImoOne { get; set; }
       public string photoelectricityImoTow { get; set; }
       public string photoelectricityIthOne { get; set; }
       public string photoelectricityIthTow { get; set; }
        public string photoelectricityVfOne{ get; set; }
       public string photoelectricityVfTow { get; set; }
        public string photoelectricityPTOne { get; set; }
       public string photoelectricityVbrOne { get; set; }
        public string photoelectricityVbrTow { get; set; }

       public string testTemperatureOne { get; set; }
       public string testTemperatureTow { get; set; }
        public string assemblyDirection { get; set; }
       public string PTHeight { get; set; }
        public string peripheralGlue { get; set; }
       public string LD_Type { get; set; }
        public string PT_Type { get; set; }
       public string deviceTag { get; set; }
        public string beforeWelding { get; set; }
       public string postwelding { get; set; }
        public string theTest { get; set; }

       public string authorized { get; set; }
        public string technologyAuditing { get; set; }
        public string manufactureAuditing { get; set; }

        public string dataEntryStaff { get; set; }
        public string dataEntryStaffTime { get; set; }

        public string theProductName { get; set; }
        public string theDescription { get; set; }
        public string theMatterCode { get; set; }
        public string theModelAttributes { get; set; }
        public string theSpecification { get; set; }
       public string theCustomerType { get; set; }
       public string theStockNumber { get; set; }
       public string theContractNumber { get; set; }
       public string theLD_Type { get; set; }
       public string thePT_Type { get; set; }
       public string theDateOfManufacture { get; set; }
       public string theQuantityOne { get; set; }
       public string theQuantityTow { get; set; }
       public string theNumber { get; set; }
    }
}
