using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_GetMethod
    {
        D_SQLDBHelper d_SQLDBHelper = new D_SQLDBHelper();

        private readonly string sqlConnection = MicrosoftSqlHelper.GetConnSting();

        public static Bitmap ReadImageFile(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }


        public bool ImportPlanMethod(string filePath)
        {
            bool flag = false;
            try
            {
                M_ImportPlan m_ImportPlan = null;
                m_ImportPlan = NOPI_Excel.GetExcelToM_ImportPlan(filePath);
                for (int i = 0; i < m_ImportPlan.m_ListWorkOrderInfo.Count; i++)
                {
                    m_ImportPlan.m_ListWorkOrderInfo[i].productCode = d_SQLDBHelper.GetOneWord("select ");
                    string sqlStr = "INSERT INTO [dbo].[T_ImportPlan]([orderNumber],[productName],[deliveryDate],[client],[createTime],[productNumber]) VALUES ('" + m_ImportPlan.orderNumber + "','" + m_ImportPlan.m_ListWorkOrderInfo[i].productName + "','" + m_ImportPlan.m_ListWorkOrderInfo[i].deliveryDate + "','" + m_ImportPlan.m_ListWorkOrderInfo[i].client + "','" + DateTime.Now + "'," + m_ImportPlan.m_ListWorkOrderInfo[i].productNumber + ")";
                    flag = d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr);
                }
                DataTable dt = d_SQLDBHelper.GetRecordsTable0("select a.[productNumber],a.[productName],b.id from [dbo].[T_ProductInformation] as a,[T_ImportPlan] as b where a.[productName]=b.[productName]");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!d_SQLDBHelper.ISRecordsExists("select count(*) from T_JoinT_ImportPlan where FK=" + int.Parse(dt.Rows[i]["id"].ToString())))
                        {
                            d_SQLDBHelper.OperateOnARecordNonQuery("INSERT INTO [dbo].[T_JoinT_ImportPlan]([productNumber] ,[productName] ,[FK]) VALUES ('" + dt.Rows[i]["productNumber"].ToString() + "','" + dt.Rows[i]["productName"].ToString() + "'," + int.Parse(dt.Rows[i]["id"].ToString()) + ")");
                        }
                    }
                }
            }
            catch (Exception error){
                Log.LogWrite(error.ToString());
            }
            return flag;
        }

        public string HandleSpecifications(M_Specifications m_Specifications, M_SQLType m_SQLType)
        {
            string sqlStr = string.Empty; string returnStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(specificationsName) from T_Specifications where specificationsName='" + m_Specifications.specificationsName + "'"))
                    {
                        returnStr = "该规格书已存在!!!";
                        return returnStr;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_Specifications]([specificationsName],[clientCode],[productModel],[productCode],[LD_Method],[LD_Po],[LD_Wavelength],[LD_If],[temperature],[temperatureText],[PT_Method],[PT_apt],[PT_code],[PT_time],[PT_Sem],[PT_error],[PT_speed],[PT_Wavelength],[PT_APDV],[pomin],[pominText],[ithmin],[vfmin],[imomin],[imominText],[esmin],[esminText],[rsmin],[pkinkmin],[kimomin],[cmmin],[themin],[sRMSmin],[tEmin],[imoKinkmin],[idarkmin],[ifmin],[handlePomin],[handlePominText],[parallelmin],[pomax],[pomaxText],[ithmax],[vfmax],[imomax],[imomaxText],[esmax],[esmaxText],[rsmax],[pkinkmax],[kimomax],[cmmax],[themax],[sRMSmax],[tEmax],[imoKinkmax],[idarkmax],[ifmax],[handlePomax],[handlePomaxText],[parallelmax],[vbrmin],[iopmin],[iopminText],[iomin],[iominText],[idpmin],[iccmin],[senmin],[vbrmax],[iopmax],[iomax],[idpmax],[iccmax],[senmax],[senmaxText],[remarks],[createTime],[joinID]) VALUES('" + m_Specifications.specificationsName + "','" + m_Specifications.clientCode + "','" + m_Specifications.productModel + "','" + m_Specifications.productCode + "','" + m_Specifications.LD_Method + "','" + m_Specifications.LD_Po + "','" + m_Specifications.LD_Wavelength + "','" + m_Specifications.LD_If + "','" + m_Specifications.temperature + "','" + m_Specifications.temperatureText + "','" + m_Specifications.PT_Method + "','" + m_Specifications.PT_apt + "','" + m_Specifications.PT_code + "','" + m_Specifications.PT_time + "','" + m_Specifications.PT_Sem + "','" + m_Specifications.PT_error + "','" + m_Specifications.PT_speed + "','" + m_Specifications.PT_Wavelength + "','" + m_Specifications.PT_APDV + "','" + m_Specifications.pomin + "','" + m_Specifications.pominText + "','" + m_Specifications.ithmin + "','" + m_Specifications.vfmin + "','" + m_Specifications.imomin + "','" + m_Specifications.imominText + "','" + m_Specifications.esmin + "','" + m_Specifications.esminText + "','" + m_Specifications.rsmin + "','" + m_Specifications.pkinkmin + "','" + m_Specifications.kimomin + "','" + m_Specifications.cmmin + "','" + m_Specifications.themin + "','" + m_Specifications.sRMSmin + "','" + m_Specifications.tEmin + "','" + m_Specifications.imoKinkmin + "','" + m_Specifications.idarkmin + "','" + m_Specifications.ifmin + "','" + m_Specifications.handlePomin + "','" + m_Specifications.handlePominText + "','" + m_Specifications.parallelmin + "','" + m_Specifications.pomax + "','" + m_Specifications.pomaxText + "','" + m_Specifications.ithmax + "','" + m_Specifications.vfmax + "','" + m_Specifications.imomax + "','" + m_Specifications.imomaxText + "','" + m_Specifications.esmax + "','" + m_Specifications.esmaxText + "','" + m_Specifications.rsmax + "','" + m_Specifications.pkinkmax + "','" + m_Specifications.kimomax + "','" + m_Specifications.cmmax + "','" + m_Specifications.themax + "','" + m_Specifications.sRMSmax + "','" + m_Specifications.tEmax + "','" + m_Specifications.imoKinkmax + "','" + m_Specifications.idarkmax + "','" + m_Specifications.ifmax + "','" + m_Specifications.handlePomax + "','" + m_Specifications.handlePomaxText + "','" + m_Specifications.parallelmax + "','" + m_Specifications.vbrmin + "','" + m_Specifications.iopmin + "','" + m_Specifications.iopminText + "','" + m_Specifications.iomin + "','" + m_Specifications.iominText + "','" + m_Specifications.idpmin + "','" + m_Specifications.iccmin + "','" + m_Specifications.senmin + "','" + m_Specifications.vbrmax + "','" + m_Specifications.iopmax + "','" + m_Specifications.iomax + "','" + m_Specifications.idpmax + "','" + m_Specifications.iccmax + "','" + m_Specifications.senmax + "','" + m_Specifications.senmaxText + "','" + m_Specifications.remarks + "','" + m_Specifications.createTime + "'," + m_Specifications.joinID + ")";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnStr = "上传规格书成功";
                    }
                    else
                    {
                        returnStr = "上传规格书失败!!!";
                    }
                    break;
                case "Update":
                    string conStr = string.Empty;
                    if (!d_SQLDBHelper.ISRecordsExists("select count(specificationsName) from T_Specifications where specificationsName='" + m_Specifications.specificationsName + "'"))
                    {
                        conStr = " <请检查是否存在该规格书>";
                    }
                    sqlStr = "UPDATE [dbo].[T_Specifications] SET [specificationsName]='" + m_Specifications.specificationsName + "',[clientCode]='" + m_Specifications.clientCode + "',[productModel]='" + m_Specifications.productModel + "',[productCode]='" + m_Specifications.productCode + "',[LD_Method]=" + m_Specifications.LD_Method + ",[LD_Po]='" + m_Specifications.LD_Po + "',[LD_Wavelength]=" + m_Specifications.LD_Wavelength + ",[LD_If]='" + m_Specifications.LD_If + "',[temperature]=" + m_Specifications.temperature + ",[temperatureText]='" + m_Specifications.temperatureText + "',[PT_Method]=" + m_Specifications.PT_Method + ",[PT_apt]=" + m_Specifications.PT_apt + ",[PT_code]=" + m_Specifications.PT_code + ",[PT_time]='" + m_Specifications.PT_time + "',[PT_Sem]='" + m_Specifications.PT_Sem + "',[PT_error]=" + m_Specifications.PT_error + ",[PT_speed]=" + m_Specifications.PT_speed + ",[PT_Wavelength]=" + m_Specifications.PT_Wavelength + ",[PT_APDV]=" + m_Specifications.PT_APDV + ",[pomin]='" + m_Specifications.pomin + "',[pominText]='" + m_Specifications.pominText + "',[ithmin]='" + m_Specifications.ithmin + "',[vfmin]='" + m_Specifications.vfmin + "',[imomin]='" + m_Specifications.imomin + "',[imominText]='" + m_Specifications.imominText + "',[esmin]='" + m_Specifications.esmin + "',[esminText]='" + m_Specifications.esminText + "',[rsmin]='" + m_Specifications.rsmin + "',[pkinkmin]='" + m_Specifications.pkinkmin + "',[kimomin]='" + m_Specifications.kimomin + "',[cmmin]='" + m_Specifications.cmmin + "',[themin]='" + m_Specifications.themin + "',[sRMSmin]='" + m_Specifications.sRMSmin + "',[tEmin]='" + m_Specifications.tEmin + "',[imoKinkmin]='" + m_Specifications.imoKinkmin + "',[idarkmin]='" + m_Specifications.idarkmin + "',[ifmin]='" + m_Specifications.ifmin + "',[handlePomin]='" + m_Specifications.handlePomin + "',[handlePominText]='" + m_Specifications.handlePominText + "',[parallelmin]='" + m_Specifications.parallelmin + "',[pomax]='" + m_Specifications.pomax + "',[pomaxText]='" + m_Specifications.pomaxText + "',[ithmax]='" + m_Specifications.ithmax + "',[vfmax]='" + m_Specifications.vfmax + "',[imomax]='" + m_Specifications.imomax + "',[imomaxText]='" + m_Specifications.imomaxText + "',[esmax]='" + m_Specifications.esmax + "',[esmaxText]='" + m_Specifications.esmaxText + "',[rsmax]='" + m_Specifications.cmmax + "',[pkinkmax]='" + m_Specifications.pkinkmax + "',[kimomax]='" + m_Specifications.kimomax + "',[cmmax]='" + m_Specifications.cmmax + "',[themax]='" + m_Specifications.themax + "',[sRMSmax]='" + m_Specifications.sRMSmax + "',[tEmax]='" + m_Specifications.tEmax + "',[imoKinkmax]='" + m_Specifications.imoKinkmax + "',[idarkmax]='" + m_Specifications.idarkmax + "',[ifmax]='" + m_Specifications.ifmax + "',[handlePomax]='" + m_Specifications.handlePomax + "',[handlePomaxText]='" + m_Specifications.handlePomaxText + "',[parallelmax]='" + m_Specifications.parallelmax + "',[vbrmin]='" + m_Specifications.vbrmin + "',[iopmin]='" + m_Specifications.iopmin + "',[iopminText]='" + m_Specifications.iopminText + "',[iomin]='" + m_Specifications.iomin + "',[iominText]='" + m_Specifications.iominText + "',[idpmin]='" + m_Specifications.idpmin + "',[iccmin]='" + m_Specifications.iccmin + "',[senmin]='" + m_Specifications.senmin + "',[vbrmax]='" + m_Specifications.vbrmax + "',[iopmax]='" + m_Specifications.iopmax + "',[iomax]='" + m_Specifications.iomax + "',[idpmax]='" + m_Specifications.idpmax + "',[iccmax]='" + m_Specifications.iccmax + "',[senmax]='" + m_Specifications.senmax + "',[senmaxText]='" + m_Specifications.senmaxText + "',[remarks]='" + m_Specifications.remarks + "' WHERE [specificationsName]='" + m_Specifications.specificationsName + "'";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnStr = "修改规格书成功";
                    }
                    else
                    {
                        returnStr = "修改规格书失败!!!" + conStr;
                    }
                    break;
                case "Delete": break;
                default: break;
            }
            return returnStr;
        }

        public bool ExecuteSentence(string str)
        {
            bool flag = false;
            flag = d_SQLDBHelper.OperateOnARecordNonQuery(str);
            return flag;
        }

        public DataTable GetTable(string tableName, string selectColumns)
        {
            DataTable dt = new DataTable();
            dt = d_SQLDBHelper.GetRecordsTable0("SELECT " + selectColumns + " FROM " + tableName);
            return dt;
        }

        public List<string> GetM_SpecificationsList(string sqlStr)
        {
            List<string> specificationsNameArray = new List<string>();
            DataTable dt = new DataTable();
            dt = d_SQLDBHelper.GetRecordsTable0(sqlStr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                specificationsNameArray.Add(dt.Rows[i]["specificationsName"].ToString());
            }
            return specificationsNameArray;
        }

        public M_Specifications GetM_Specifications(string keyword)
        {
            M_Specifications m_Specifications = null;
            DataTable dt = d_SQLDBHelper.GetRecordsTable0("select * from T_Specifications where [specificationsName]='" + keyword + "'");
            if (dt.Rows.Count <= 0)
            {
                return m_Specifications;
            }
            m_Specifications = new M_Specifications();
            int defaultNumber = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m_Specifications.specificationsName = dt.Rows[i]["specificationsName"].ToString();
                m_Specifications.clientCode = dt.Rows[i]["clientCode"].ToString();
                m_Specifications.productModel = dt.Rows[i]["productModel"].ToString();
                m_Specifications.productCode = dt.Rows[i]["productCode"].ToString();
                m_Specifications.LD_Method = !string.IsNullOrEmpty(dt.Rows[i]["LD_Method"].ToString()) ? int.Parse(dt.Rows[i]["LD_Method"].ToString()) : defaultNumber;
                m_Specifications.LD_Po = dt.Rows[i]["LD_Po"].ToString();
                m_Specifications.LD_Wavelength = !string.IsNullOrEmpty(dt.Rows[i]["LD_Wavelength"].ToString()) ? int.Parse(dt.Rows[i]["LD_Wavelength"].ToString()) : defaultNumber;
                m_Specifications.LD_If = dt.Rows[i]["LD_If"].ToString();
                m_Specifications.temperature = !string.IsNullOrEmpty(dt.Rows[i]["temperature"].ToString()) ? int.Parse(dt.Rows[i]["temperature"].ToString()) : defaultNumber;
                m_Specifications.temperatureText = dt.Rows[i]["temperatureText"].ToString();
                m_Specifications.PT_Method = !string.IsNullOrEmpty(dt.Rows[i]["PT_Method"].ToString()) ? int.Parse(dt.Rows[i]["PT_Method"].ToString()) : defaultNumber;
                m_Specifications.PT_apt = !string.IsNullOrEmpty(dt.Rows[i]["PT_apt"].ToString()) ? int.Parse(dt.Rows[i]["PT_apt"].ToString()) : defaultNumber;
                m_Specifications.PT_code = !string.IsNullOrEmpty(dt.Rows[i]["PT_code"].ToString()) ? int.Parse(dt.Rows[i]["PT_code"].ToString()) : defaultNumber;
                m_Specifications.PT_time = dt.Rows[i]["PT_time"].ToString();
                m_Specifications.PT_Sem = dt.Rows[i]["PT_Sem"].ToString();
                m_Specifications.PT_error = !string.IsNullOrEmpty(dt.Rows[i]["PT_error"].ToString()) ? int.Parse(dt.Rows[i]["PT_error"].ToString()) : defaultNumber;
                m_Specifications.PT_speed = !string.IsNullOrEmpty(dt.Rows[i]["PT_speed"].ToString()) ? int.Parse(dt.Rows[i]["PT_speed"].ToString()) : defaultNumber;
                m_Specifications.PT_Wavelength = !string.IsNullOrEmpty(dt.Rows[i]["PT_Wavelength"].ToString()) ? int.Parse(dt.Rows[i]["PT_Wavelength"].ToString()) : defaultNumber;
                m_Specifications.PT_APDV = !string.IsNullOrEmpty(dt.Rows[i]["PT_APDV"].ToString()) ? int.Parse(dt.Rows[i]["PT_APDV"].ToString()) : defaultNumber;
                m_Specifications.pomin = dt.Rows[i]["pomin"].ToString();
                m_Specifications.pominText = dt.Rows[i]["pominText"].ToString();
                m_Specifications.ithmin = dt.Rows[i]["ithmin"].ToString();
                m_Specifications.vfmin = dt.Rows[i]["vfmin"].ToString();
                m_Specifications.imomin = dt.Rows[i]["imomin"].ToString();
                m_Specifications.imominText = dt.Rows[i]["imominText"].ToString();
                m_Specifications.esmin = dt.Rows[i]["esmin"].ToString();
                m_Specifications.esminText = dt.Rows[i]["esminText"].ToString();
                m_Specifications.rsmin = dt.Rows[i]["rsmin"].ToString();
                m_Specifications.pkinkmin = dt.Rows[i]["pkinkmin"].ToString();
                m_Specifications.kimomin = dt.Rows[i]["kimomin"].ToString();
                m_Specifications.cmmin = dt.Rows[i]["cmmin"].ToString();
                m_Specifications.themin = dt.Rows[i]["themin"].ToString();
                m_Specifications.sRMSmin = dt.Rows[i]["sRMSmin"].ToString();
                m_Specifications.tEmin = dt.Rows[i]["tEmin"].ToString();
                m_Specifications.imoKinkmin = dt.Rows[i]["imoKinkmin"].ToString();
                m_Specifications.idarkmin = dt.Rows[i]["idarkmin"].ToString();
                m_Specifications.ifmin = dt.Rows[i]["ifmin"].ToString();
                m_Specifications.handlePomin = dt.Rows[i]["handlePomin"].ToString();
                m_Specifications.handlePominText = dt.Rows[i]["handlePominText"].ToString();
                m_Specifications.parallelmin = dt.Rows[i]["parallelmin"].ToString();
                m_Specifications.pomax = dt.Rows[i]["pomax"].ToString();
                m_Specifications.pomaxText = dt.Rows[i]["pomaxText"].ToString();
                m_Specifications.ithmax = dt.Rows[i]["ithmax"].ToString();
                m_Specifications.vfmax = dt.Rows[i]["vfmax"].ToString();
                m_Specifications.imomax = dt.Rows[i]["imomax"].ToString();
                m_Specifications.imomaxText = dt.Rows[i]["imomaxText"].ToString();
                m_Specifications.esmax = dt.Rows[i]["esmax"].ToString();
                m_Specifications.esmaxText = dt.Rows[i]["esmaxText"].ToString();
                m_Specifications.rsmax = dt.Rows[i]["rsmax"].ToString();
                m_Specifications.pkinkmax = dt.Rows[i]["pkinkmax"].ToString();
                m_Specifications.kimomax = dt.Rows[i]["kimomax"].ToString();
                m_Specifications.cmmax = dt.Rows[i]["cmmax"].ToString();
                m_Specifications.themax = dt.Rows[i]["themax"].ToString();
                m_Specifications.sRMSmax = dt.Rows[i]["sRMSmax"].ToString();
                m_Specifications.tEmax = dt.Rows[i]["tEmax"].ToString();
                m_Specifications.imoKinkmax = dt.Rows[i]["imoKinkmax"].ToString();
                m_Specifications.idarkmax = dt.Rows[i]["idarkmax"].ToString();
                m_Specifications.ifmax = dt.Rows[i]["ifmax"].ToString();
                m_Specifications.handlePomax = dt.Rows[i]["handlePomax"].ToString();
                m_Specifications.handlePomaxText = dt.Rows[i]["handlePomaxText"].ToString();
                m_Specifications.parallelmax = dt.Rows[i]["parallelmax"].ToString();
                m_Specifications.vbrmin = dt.Rows[i]["vbrmin"].ToString();
                m_Specifications.iopmin = dt.Rows[i]["iopmin"].ToString();
                m_Specifications.iopminText = dt.Rows[i]["iopminText"].ToString();
                m_Specifications.iomin = dt.Rows[i]["iomin"].ToString();
                m_Specifications.iominText = dt.Rows[i]["iominText"].ToString();
                m_Specifications.idpmin = dt.Rows[i]["idpmin"].ToString();
                m_Specifications.iccmin = dt.Rows[i]["iccmin"].ToString();
                m_Specifications.senmin = dt.Rows[i]["senmin"].ToString();
                m_Specifications.vbrmax = dt.Rows[i]["vbrmax"].ToString();
                m_Specifications.iopmax = dt.Rows[i]["iopmax"].ToString();
                m_Specifications.iomax = dt.Rows[i]["iomax"].ToString();
                m_Specifications.idpmax = dt.Rows[i]["idpmax"].ToString();
                m_Specifications.iccmax = dt.Rows[i]["iccmax"].ToString();
                m_Specifications.senmax = dt.Rows[i]["senmax"].ToString();
                m_Specifications.senmaxText = dt.Rows[i]["senmaxText"].ToString();
                m_Specifications.remarks = dt.Rows[i]["remarks"].ToString();
            }
            return m_Specifications;
        }

        public string HandleSpecificInformation(M_SpecificInformation m_SpecificInformation, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from T_SpecificInformation where workOrderNumberOne='" + m_SpecificInformation.workOrderNumberOne + "' and workOrderNumberTow='" + m_SpecificInformation.workOrderNumberTow + "'"))
                    {
                        returnInfo = "该随工单已存在!!!";
                        return returnInfo;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_SpecificInformation]([workOrderNumberOne],[workOrderNumberTow],[deliveryDate],[orderDate],[contractNumber],[specificationNumber],[tbleNumber],[LD_One],[LD_Tow],[LD_Three],[PT_One],[PT_Tow],[PT_Three],[monoblockOne],[monoblockTow],[monoblockThree],[zeroFilterChipOne],[zeroFilterChipTow],[zeroFilterChipThree],[fortyFiveFilterChipOne],[fortyFiveFilterChipTow],[fortyFiveFilterChipThree],[interfaceModuleOne],[interfaceModuleTow],[interfaceModuleThree],[equipmentNumberOne],[equipmentNumberTow],[equipmentNumberThree],[equipmentNumberFour],[uploadQuantity],[uploadTime],[unqualifiedQuantity],[consoleOneFirstText],[consoleOneLastText],[consoleTowFirstText],[consoleTowLastText],[consoleThreeFirstText],[consoleThreeLastText],[consoleFourFirstText],[consoleFourLastText],[dataEntryStaffFirstText],[dataEntryStaffLastText],[filterChipError],[weldError],[LDError],[exceed],[pressure],[LD_Threshold],[markingError],[monoblockError],[slugError],[theOther],[theQuantity],[serialNumberOne],[serialNumberTow],[serialNumberThree],[CASE_One],[CASE_Tow],[CASE_Three],[LD_AddOne],[LD_AddTow],[LD_AddThree],[LD_AddFour],[LD_AddFive],[LD_AddSix],[LD_MinusOne],[LD_MinusTow],[LD_MinusThree],[rangeOne],[rangeTow],[rangeThree],[concaveCnvexOne],[concaveCnvexTow],[concaveCnvexThree],[slugFocal],[inspectionPersonal],[checker],[remarks],[createTime]) VALUES ('" + m_SpecificInformation.workOrderNumberOne + "','" + m_SpecificInformation.workOrderNumberTow + "','" + m_SpecificInformation.deliveryDate + "','" + m_SpecificInformation.orderDate + "','" + m_SpecificInformation.contractNumber + "','" + m_SpecificInformation.specificationNumber + "','" + m_SpecificInformation.tbleNumber + "','" + m_SpecificInformation.LD_One + "','" + m_SpecificInformation.LD_Tow + "','" + m_SpecificInformation.LD_Three + "','" + m_SpecificInformation.PT_One + "','" + m_SpecificInformation.PT_Tow + "','" + m_SpecificInformation.PT_Three + "','" + m_SpecificInformation.monoblockOne + "','" + m_SpecificInformation.monoblockTow + "','" + m_SpecificInformation.monoblockThree + "','" + m_SpecificInformation.zeroFilterChipOne + "','" + m_SpecificInformation.zeroFilterChipTow + "','" + m_SpecificInformation.zeroFilterChipThree + "','" + m_SpecificInformation.fortyFiveFilterChipOne + "','" + m_SpecificInformation.fortyFiveFilterChipTow + "','" + m_SpecificInformation.fortyFiveFilterChipThree + "','" + m_SpecificInformation.interfaceModuleOne + "','" + m_SpecificInformation.interfaceModuleTow + "','" + m_SpecificInformation.interfaceModuleThree + "','" + m_SpecificInformation.equipmentNumberOne + "','" + m_SpecificInformation.equipmentNumberTow + "','" + m_SpecificInformation.equipmentNumberThree + "','" + m_SpecificInformation.equipmentNumberFour + "'," + m_SpecificInformation.uploadQuantity + ",'" + m_SpecificInformation.uploadTime + "'," + m_SpecificInformation.unqualifiedQuantity + "," + m_SpecificInformation.consoleOneFirstText + ",'" + m_SpecificInformation.consoleOneLastText + "'," + m_SpecificInformation.consoleTowFirstText + ",'" + m_SpecificInformation.consoleTowLastText + "'," + m_SpecificInformation.consoleThreeFirstText + ",'" + m_SpecificInformation.consoleThreeLastText + "'," + m_SpecificInformation.consoleFourFirstText + ",'" + m_SpecificInformation.consoleFourLastText + "'," + m_SpecificInformation.dataEntryStaffFirstText + ",'" + m_SpecificInformation.dataEntryStaffLastText + "'," + m_SpecificInformation.filterChipError + "," + m_SpecificInformation.weldError + "," + m_SpecificInformation.LDError + "," + m_SpecificInformation.exceed + "," + m_SpecificInformation.pressure + "," + m_SpecificInformation.LD_Threshold + "," + m_SpecificInformation.markingError + "," + m_SpecificInformation.monoblockError + "," + m_SpecificInformation.slugError + ",'" + m_SpecificInformation.theOther + "'," + m_SpecificInformation.theQuantity + ",'" + m_SpecificInformation.serialNumberOne + "','" + m_SpecificInformation.serialNumberTow + "','" + m_SpecificInformation.serialNumberThree + "','" + m_SpecificInformation.CASE_One + "','" + m_SpecificInformation.CASE_Tow + "','" + m_SpecificInformation.CASE_Three + "','" + m_SpecificInformation.LD_AddOne + "','" + m_SpecificInformation.LD_AddTow + "','" + m_SpecificInformation.LD_AddThree + "','" + m_SpecificInformation.LD_AddFour + "','" + m_SpecificInformation.LD_AddFive + "','" + m_SpecificInformation.LD_AddSix + "','" + m_SpecificInformation.LD_MinusOne + "','" + m_SpecificInformation.LD_MinusTow + "','" + m_SpecificInformation.LD_MinusThree + "','" + m_SpecificInformation.rangeOne + "','" + m_SpecificInformation.rangeTow + "','" + m_SpecificInformation.rangeThree + "','" + m_SpecificInformation.concaveCnvexOne + "','" + m_SpecificInformation.concaveCnvexTow + "','" + m_SpecificInformation.concaveCnvexThree + "','" + m_SpecificInformation.slugFocal + "','" + m_SpecificInformation.inspectionPersonal + "','" + m_SpecificInformation.checker + "','" + m_SpecificInformation.remarks + "','" + m_SpecificInformation.createTime + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "随工单【" + m_SpecificInformation.workOrderNumberOne + m_SpecificInformation.workOrderNumberTow + "】上传成功";
                        if (!d_SQLDBHelper.ISRecordsExists("select count(specificationsName) from T_Specifications where specificationsName='" + m_SpecificInformation.specificationNumber + "'"))
                        {
                            d_SQLDBHelper.OperateOnARecordNonQuery("INSERT INTO [dbo].[T_Specifications]([specificationsName]) VALUES ('" + m_SpecificInformation.specificationNumber + "')");
                        }
                        string str = d_SQLDBHelper.GetOneWord("select id from T_SpecificInformation where workOrderNumberOne='" + m_SpecificInformation.workOrderNumberOne + "'");
                        d_SQLDBHelper.OperateOnARecordNonQuery("INSERT INTO [dbo].[T_CreateTable] ([specificationsName],[specificInformationID]) VALUES ('" + m_SpecificInformation.specificationNumber + "'," + int.Parse(str) + ")");
                    }
                    else
                    {
                        returnInfo = "随工单【" + m_SpecificInformation.workOrderNumberOne + m_SpecificInformation.workOrderNumberTow + "】上传失败!!!";
                    }
                    break;
                case "Update":
                    string conStr = string.Empty;
                    if (!d_SQLDBHelper.ISRecordsExists("select count(*) from T_SpecificInformation where workOrderNumberOne='" + m_SpecificInformation.workOrderNumberOne + "' and workOrderNumberTow='" + m_SpecificInformation.workOrderNumberTow + "'"))
                    {
                        conStr = " <请检查是否存在该随工单>";
                    }
                    sqlStr = "UPDATE [dbo].[T_SpecificInformation] SET [workOrderNumberTow] = '" + m_SpecificInformation.workOrderNumberTow + "',[deliveryDate] = '" + m_SpecificInformation.deliveryDate + "',[orderDate] = '" + m_SpecificInformation.orderDate + "',[contractNumber] = '" + m_SpecificInformation.contractNumber + "',[specificationNumber] = '" + m_SpecificInformation.specificationNumber + "',[tbleNumber] = '" + m_SpecificInformation.tbleNumber + "',[LD_One] = '" + m_SpecificInformation.LD_One + "',[LD_Tow] = '" + m_SpecificInformation.LD_Tow + "',[LD_Three] ='" + m_SpecificInformation.LD_Three + "',[PT_One] = '" + m_SpecificInformation.PT_One + "',[PT_Tow] = '" + m_SpecificInformation.PT_Tow + "',[PT_Three] = '" + m_SpecificInformation.PT_Three + "',[monoblockOne] = '" + m_SpecificInformation.monoblockOne + "',[monoblockTow] =  '" + m_SpecificInformation.monoblockTow + "',[monoblockThree] = '" + m_SpecificInformation.monoblockThree + "',[zeroFilterChipOne] =  '" + m_SpecificInformation.zeroFilterChipOne + "',[zeroFilterChipTow] =  '" + m_SpecificInformation.zeroFilterChipTow + "' ,[zeroFilterChipThree] =  '" + m_SpecificInformation.zeroFilterChipThree + "' ,[fortyFiveFilterChipOne] =  '" + m_SpecificInformation.fortyFiveFilterChipOne + "',[fortyFiveFilterChipTow] =  '" + m_SpecificInformation.fortyFiveFilterChipTow + "',[fortyFiveFilterChipThree] = '" + m_SpecificInformation.fortyFiveFilterChipThree + "' ,[interfaceModuleOne] =  '" + m_SpecificInformation.interfaceModuleOne + "',[interfaceModuleTow] = '" + m_SpecificInformation.interfaceModuleTow + "',[interfaceModuleThree] =  '" + m_SpecificInformation.interfaceModuleThree + "',[equipmentNumberOne] =  '" + m_SpecificInformation.equipmentNumberOne + "',[equipmentNumberTow] =  '" + m_SpecificInformation.equipmentNumberTow + "',[equipmentNumberThree] =  '" + m_SpecificInformation.equipmentNumberThree + "',[equipmentNumberFour] =  '" + m_SpecificInformation.equipmentNumberFour + "' ,[uploadQuantity] =  " + m_SpecificInformation.uploadQuantity + " ,[uploadTime] = '" + m_SpecificInformation.uploadTime + "',[unqualifiedQuantity] =  " + m_SpecificInformation.unqualifiedQuantity + ",[consoleOneFirstText] =   " + m_SpecificInformation.consoleOneFirstText + ",[consoleOneLastText] =  '" + m_SpecificInformation.consoleOneLastText + "',[consoleTowFirstText] =  " + m_SpecificInformation.consoleTowFirstText + ",[consoleTowLastText] = '" + m_SpecificInformation.consoleTowLastText + "',[consoleThreeFirstText] =  " + m_SpecificInformation.consoleThreeFirstText + ",[consoleThreeLastText] = '" + m_SpecificInformation.consoleThreeLastText + "',[consoleFourFirstText] =  " + m_SpecificInformation.consoleFourFirstText + " ,[consoleFourLastText] = '" + m_SpecificInformation.consoleFourLastText + "',[dataEntryStaffFirstText] =  " + m_SpecificInformation.dataEntryStaffFirstText + ",[dataEntryStaffLastText] = '" + m_SpecificInformation.dataEntryStaffLastText + "' ,[filterChipError] = " + m_SpecificInformation.filterChipError + " ,[weldError] =  " + m_SpecificInformation.weldError + " ,[LDError] =  " + m_SpecificInformation.LDError + ",[exceed] =  " + m_SpecificInformation.exceed + ",[pressure] =  " + m_SpecificInformation.pressure + ",[LD_Threshold] =  " + m_SpecificInformation.uploadQuantity + ",[markingError] =  " + m_SpecificInformation.markingError + ",[monoblockError] =  " + m_SpecificInformation.monoblockError + ",[slugError] =  " + m_SpecificInformation.slugError + ",[theOther] = '" + m_SpecificInformation.theOther + "',[theQuantity] = " + m_SpecificInformation.theQuantity + ",[serialNumberOne] ='" + m_SpecificInformation.serialNumberOne + "',[serialNumberTow] = '" + m_SpecificInformation.serialNumberTow + "',[serialNumberThree] = '" + m_SpecificInformation.serialNumberThree + "',[CASE_One] = '" + m_SpecificInformation.CASE_One + "' ,[CASE_Tow] = '" + m_SpecificInformation.CASE_Tow + "',[CASE_Three] = '" + m_SpecificInformation.CASE_Three + "',[LD_AddOne] = '" + m_SpecificInformation.LD_AddOne + "' ,[LD_AddTow] = '" + m_SpecificInformation.LD_AddTow + "',[LD_AddThree] = '" + m_SpecificInformation.LD_AddThree + "',[LD_AddFour] ='" + m_SpecificInformation.LD_AddFour + "',[LD_AddFive] = '" + m_SpecificInformation.LD_AddFive + "' ,[LD_AddSix] = '" + m_SpecificInformation.LD_AddSix + "' ,[LD_MinusOne] = '" + m_SpecificInformation.LD_MinusOne + "',[LD_MinusTow] ='" + m_SpecificInformation.LD_MinusTow + "',[LD_MinusThree] = '" + m_SpecificInformation.LD_MinusThree + "',[rangeOne] = '" + m_SpecificInformation.rangeOne + "',[rangeTow] = '" + m_SpecificInformation.rangeTow + "',[rangeThree] = '" + m_SpecificInformation.rangeThree + "',[concaveCnvexOne] ='" + m_SpecificInformation.concaveCnvexOne + "' ,[concaveCnvexTow] = '" + m_SpecificInformation.concaveCnvexTow + "',[concaveCnvexThree] ='" + m_SpecificInformation.concaveCnvexThree + "',[slugFocal] = '" + m_SpecificInformation.slugFocal + "',[inspectionPersonal] = '" + m_SpecificInformation.inspectionPersonal + "',[checker] = '" + m_SpecificInformation.checker + "',[remarks] ='" + m_SpecificInformation.remarks + "' WHERE workOrderNumberOne='" + m_SpecificInformation.workOrderNumberOne + "'";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "修改随工单成功";
                        if (!d_SQLDBHelper.ISRecordsExists("select count(specificationsName) from T_Specifications where specificationsName='" + m_SpecificInformation.specificationNumber + "'"))
                        {
                            d_SQLDBHelper.OperateOnARecordNonQuery("INSERT INTO [dbo].[T_Specifications]([specificationsName]) VALUES ('" + m_SpecificInformation.specificationNumber + "')");
                        }
                        string str = d_SQLDBHelper.GetOneWord("select id from T_SpecificInformation where workOrderNumberOne='" + m_SpecificInformation.workOrderNumberOne + "'");
                        d_SQLDBHelper.OperateOnARecordNonQuery("UPDATE [dbo].[T_CreateTable] SET [specificationsName] = '" + m_SpecificInformation.specificationNumber + "' WHERE [specificInformationID]=" + int.Parse(str));
                    }
                    else
                    {
                        returnInfo = "修改随工单失败!!!" + conStr;
                    }
                    break;
                case "Delete": break;
                default: break;
            }

            return returnInfo;
        }

        public M_SpecificInformation GetM_SpecificInformation(string keyword)
        {
            M_SpecificInformation m_SpecificInformation = null;
            DataTable dt = d_SQLDBHelper.GetRecordsTable0("select * from T_SpecificInformation where [workOrderNumberOne]='" + keyword + "'");
            if (dt.Rows.Count <= 0)
            {
                return m_SpecificInformation;
            }
            m_SpecificInformation = new M_SpecificInformation();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m_SpecificInformation.workOrderNumberOne = dt.Rows[i]["workOrderNumberOne"].ToString();
                m_SpecificInformation.workOrderNumberTow = dt.Rows[i]["workOrderNumberTow"].ToString();
                m_SpecificInformation.deliveryDate = DateTime.Parse(dt.Rows[i]["deliveryDate"].ToString());
                m_SpecificInformation.orderDate = DateTime.Parse(dt.Rows[i]["orderDate"].ToString());
                m_SpecificInformation.contractNumber = dt.Rows[i]["contractNumber"].ToString();
                m_SpecificInformation.specificationNumber = dt.Rows[i]["specificationNumber"].ToString();
                m_SpecificInformation.tbleNumber = dt.Rows[i]["tbleNumber"].ToString();
                m_SpecificInformation.LD_One = dt.Rows[i]["LD_One"].ToString();
                m_SpecificInformation.LD_Tow = dt.Rows[i]["LD_Tow"].ToString();
                m_SpecificInformation.LD_Three = dt.Rows[i]["LD_Three"].ToString();
                m_SpecificInformation.PT_One = dt.Rows[i]["PT_One"].ToString();
                m_SpecificInformation.PT_Tow = dt.Rows[i]["PT_Tow"].ToString();
                m_SpecificInformation.PT_Three = dt.Rows[i]["PT_Three"].ToString();
                m_SpecificInformation.monoblockOne = dt.Rows[i]["monoblockOne"].ToString();
                m_SpecificInformation.monoblockTow = dt.Rows[i]["monoblockTow"].ToString();
                m_SpecificInformation.monoblockThree = dt.Rows[i]["monoblockThree"].ToString();
                m_SpecificInformation.zeroFilterChipOne = dt.Rows[i]["zeroFilterChipOne"].ToString();
                m_SpecificInformation.zeroFilterChipTow = dt.Rows[i]["zeroFilterChipTow"].ToString();
                m_SpecificInformation.zeroFilterChipThree = dt.Rows[i]["zeroFilterChipThree"].ToString();
                m_SpecificInformation.fortyFiveFilterChipOne = dt.Rows[i]["fortyFiveFilterChipOne"].ToString();
                m_SpecificInformation.fortyFiveFilterChipTow = dt.Rows[i]["fortyFiveFilterChipTow"].ToString();
                m_SpecificInformation.fortyFiveFilterChipThree = dt.Rows[i]["fortyFiveFilterChipThree"].ToString();
                m_SpecificInformation.interfaceModuleOne = dt.Rows[i]["interfaceModuleOne"].ToString();
                m_SpecificInformation.interfaceModuleTow = dt.Rows[i]["interfaceModuleTow"].ToString();
                m_SpecificInformation.interfaceModuleThree = dt.Rows[i]["interfaceModuleThree"].ToString();
                m_SpecificInformation.equipmentNumberOne = dt.Rows[i]["equipmentNumberOne"].ToString();
                m_SpecificInformation.equipmentNumberTow = dt.Rows[i]["equipmentNumberTow"].ToString();
                m_SpecificInformation.equipmentNumberThree = dt.Rows[i]["equipmentNumberThree"].ToString();
                m_SpecificInformation.equipmentNumberFour = dt.Rows[i]["equipmentNumberFour"].ToString();
                m_SpecificInformation.uploadQuantity = int.Parse(dt.Rows[i]["uploadQuantity"].ToString());
                m_SpecificInformation.uploadTime = DateTime.Parse(dt.Rows[i]["uploadTime"].ToString());
                m_SpecificInformation.unqualifiedQuantity = int.Parse(dt.Rows[i]["unqualifiedQuantity"].ToString());
                m_SpecificInformation.consoleOneFirstText = int.Parse(dt.Rows[i]["consoleOneFirstText"].ToString());
                m_SpecificInformation.consoleOneLastText = dt.Rows[i]["consoleOneLastText"].ToString();
                m_SpecificInformation.consoleTowFirstText = int.Parse(dt.Rows[i]["consoleTowFirstText"].ToString());
                m_SpecificInformation.consoleTowLastText = dt.Rows[i]["consoleTowLastText"].ToString();
                m_SpecificInformation.consoleThreeFirstText = int.Parse(dt.Rows[i]["consoleThreeFirstText"].ToString());
                m_SpecificInformation.consoleThreeLastText = dt.Rows[i]["consoleThreeLastText"].ToString();
                m_SpecificInformation.consoleFourFirstText = int.Parse(dt.Rows[i]["consoleFourFirstText"].ToString());
                m_SpecificInformation.consoleFourLastText = dt.Rows[i]["consoleFourLastText"].ToString();
                m_SpecificInformation.dataEntryStaffFirstText = int.Parse(dt.Rows[i]["dataEntryStaffFirstText"].ToString());
                m_SpecificInformation.dataEntryStaffLastText = dt.Rows[i]["dataEntryStaffLastText"].ToString();
                m_SpecificInformation.filterChipError = int.Parse(dt.Rows[i]["filterChipError"].ToString());
                m_SpecificInformation.weldError = int.Parse(dt.Rows[i]["weldError"].ToString());
                m_SpecificInformation.LDError = int.Parse(dt.Rows[i]["LDError"].ToString());
                m_SpecificInformation.exceed = int.Parse(dt.Rows[i]["exceed"].ToString());
                m_SpecificInformation.pressure = int.Parse(dt.Rows[i]["pressure"].ToString());
                m_SpecificInformation.LD_Threshold = int.Parse(dt.Rows[i]["LD_Threshold"].ToString());
                m_SpecificInformation.markingError = int.Parse(dt.Rows[i]["markingError"].ToString());
                m_SpecificInformation.monoblockError = int.Parse(dt.Rows[i]["monoblockError"].ToString());
                m_SpecificInformation.slugError = int.Parse(dt.Rows[i]["slugError"].ToString());
                m_SpecificInformation.theOther = dt.Rows[i]["theOther"].ToString();
                m_SpecificInformation.theQuantity = int.Parse(dt.Rows[i]["theQuantity"].ToString());
                m_SpecificInformation.serialNumberOne = dt.Rows[i]["serialNumberOne"].ToString();
                m_SpecificInformation.serialNumberTow = dt.Rows[i]["serialNumberTow"].ToString();
                m_SpecificInformation.serialNumberThree = dt.Rows[i]["serialNumberThree"].ToString();
                m_SpecificInformation.CASE_One = dt.Rows[i]["CASE_One"].ToString();
                m_SpecificInformation.CASE_Tow = dt.Rows[i]["CASE_Tow"].ToString();
                m_SpecificInformation.CASE_Three = dt.Rows[i]["CASE_Three"].ToString();
                m_SpecificInformation.LD_AddOne = dt.Rows[i]["LD_AddOne"].ToString();
                m_SpecificInformation.LD_AddTow = dt.Rows[i]["LD_AddTow"].ToString();
                m_SpecificInformation.LD_AddThree = dt.Rows[i]["LD_AddThree"].ToString();
                m_SpecificInformation.LD_AddFour = dt.Rows[i]["LD_AddFour"].ToString();
                m_SpecificInformation.LD_AddFive = dt.Rows[i]["LD_AddFive"].ToString();
                m_SpecificInformation.LD_AddSix = dt.Rows[i]["LD_AddSix"].ToString();
                m_SpecificInformation.LD_MinusOne = dt.Rows[i]["LD_MinusOne"].ToString();
                m_SpecificInformation.LD_MinusTow = dt.Rows[i]["LD_MinusTow"].ToString();
                m_SpecificInformation.LD_MinusThree = dt.Rows[i]["LD_MinusThree"].ToString();
                m_SpecificInformation.rangeOne = dt.Rows[i]["rangeOne"].ToString();
                m_SpecificInformation.rangeTow = dt.Rows[i]["rangeTow"].ToString();
                m_SpecificInformation.rangeThree = dt.Rows[i]["rangeThree"].ToString();
                m_SpecificInformation.concaveCnvexOne = dt.Rows[i]["concaveCnvexOne"].ToString();
                m_SpecificInformation.concaveCnvexTow = dt.Rows[i]["concaveCnvexTow"].ToString();
                m_SpecificInformation.concaveCnvexThree = dt.Rows[i]["concaveCnvexThree"].ToString();
                m_SpecificInformation.slugFocal = dt.Rows[i]["slugFocal"].ToString();
                m_SpecificInformation.inspectionPersonal = dt.Rows[i]["inspectionPersonal"].ToString();
                m_SpecificInformation.checker = dt.Rows[i]["checker"].ToString();
                m_SpecificInformation.remarks = dt.Rows[i]["remarks"].ToString();
            }
            return m_SpecificInformation;
        }

        public string HandlePublicInformation(M_PublicInformation m_PublicInformation, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from T_PublicInformation where workOrderNumber='" + m_PublicInformation.workOrderNumber + "'"))
                    {
                        returnInfo = "该随工单已存在!!!";
                        return returnInfo;
                    }
                    if (!d_SQLDBHelper.ISRecordsExists("select count(*) from T_SpecificInformation where workOrderNumberOne='" + m_PublicInformation.workOrderNumber + "'"))
                    {
                        returnInfo = "该随工单未找到!!!";
                        return returnInfo;
                    }
                    sqlStr = @"INSERT INTO [dbo].[T_PublicInformation]([workOrderNumber],[deliveryDate],[orderDate],[contractNumber],[specificationNumber],[tbleNumberOne],[tbleNumberTow],[productModel],[productCode],[productName],[productChartNumber],[stockNumber],[clientCode],[preparationOfInvoiceNumber],[WithTheNumberOfWorkers],[surfaceOfA],[surfaceOfB],[surfaceOfCOne],[surfaceOfCTow] ,[LD_Focal],[weldingMethod],[endFaceQuality] ,[cycleIndex],[powerBeforeWeldingOne],[powerBeforeWeldingTow],[powerBeforeWeldedOne],[powerBeforeWeledTow],[fiberPower],[photocurrentOne],[photocurrentTow] ,[testPowerOne],[testPowerTow],[LD_Kink],[PD_Kink],[testConditionOne],[testConditionTow],[sensitivityOne],[sensitivityTow] ,[ICCOne] ,[ICCTow],[photoelectricityIf],[factoryPowerOne] ,[factoryPowerTow],[photoelectricityImoOne],[photoelectricityImoTow],[photoelectricityIthOne],[photoelectricityIthTow],[photoelectricityVfOne],[photoelectricityVfTow],[photoelectricityPTOne],[photoelectricityVbrOne],[photoelectricityVbrTow],[testTemperatureOne],[testTemperatureTow],[assemblyDirection],[PTHeight],[peripheralGlue],[LD_Type],[PT_Type],[deviceTag],[beforeWelding] ,[postwelding],[theTest],[authorized],[technologyAuditing],[manufactureAuditing],[dataEntryStaff],[dataEntryStaffTime],[theProductName],[theDescription],[theMatterCode],[theModelAttributes],[theSpecification],[theCustomerType],[theStockNumber],[theContractNumber],[theLD_Type],[thePT_Type],[theDateOfManufacture],[theQuantityOne],[theQuantityTow],[theNumber]) VALUES ('" + m_PublicInformation.workOrderNumber + "','" + m_PublicInformation.deliveryDate + "','" + m_PublicInformation.orderDate + "','" + m_PublicInformation.contractNumber + "','" + m_PublicInformation.specificationNumber + "','" + m_PublicInformation.tbleNumberOne + "','" + m_PublicInformation.tbleNumberTow + "','" + m_PublicInformation.productModel + "','" + m_PublicInformation.productCode + "','" + m_PublicInformation.productName + "','" + m_PublicInformation.productChartNumber + "','" + m_PublicInformation.stockNumber + "','" + m_PublicInformation.clientCode + "','" + m_PublicInformation.preparationOfInvoiceNumber + "','" + m_PublicInformation.WithTheNumberOfWorkers + "','" + m_PublicInformation.surfaceOfA + "','" + m_PublicInformation.surfaceOfB + "','" + m_PublicInformation.surfaceOfCOne + "','" + m_PublicInformation.surfaceOfCTow + "','" + m_PublicInformation.LD_Focal + "','" + m_PublicInformation.weldingMethod + "','" + m_PublicInformation.endFaceQuality + "','" + m_PublicInformation.cycleIndex + "','" + m_PublicInformation.powerBeforeWeldingOne + "','" + m_PublicInformation.powerBeforeWeldingTow + "','" + m_PublicInformation.powerBeforeWeldedOne + "','" + m_PublicInformation.powerBeforeWeledTow + "','" + m_PublicInformation.fiberPower + "','" + m_PublicInformation.photocurrentOne + "','" + m_PublicInformation.photocurrentTow + "','" + m_PublicInformation.testPowerOne + "','" + m_PublicInformation.testPowerTow + "','" + m_PublicInformation.LD_Kink + "','" + m_PublicInformation.PD_Kink + "','" + m_PublicInformation.testConditionOne + "','" + m_PublicInformation.testConditionTow + "','" + m_PublicInformation.sensitivityOne + "','" + m_PublicInformation.sensitivityTow + "','" + m_PublicInformation.ICCOne + "','" + m_PublicInformation.ICCTow + "','" + m_PublicInformation.photoelectricityIf + "','" + m_PublicInformation.factoryPowerOne + "','" + m_PublicInformation.factoryPowerTow + "','" + m_PublicInformation.photoelectricityImoOne + "','" + m_PublicInformation.photoelectricityImoTow + "','" + m_PublicInformation.photoelectricityIthOne + "','" + m_PublicInformation.photoelectricityIthTow + "','" + m_PublicInformation.photoelectricityVfOne + "','" + m_PublicInformation.photoelectricityVfTow + "','" + m_PublicInformation.photoelectricityPTOne + "','" + m_PublicInformation.photoelectricityVbrOne + "','" + m_PublicInformation.photoelectricityVbrTow + "','" + m_PublicInformation.testTemperatureOne + "','" + m_PublicInformation.testTemperatureTow + "','" + m_PublicInformation.assemblyDirection + "','" + m_PublicInformation.PTHeight + "','" + m_PublicInformation.peripheralGlue + "','" + m_PublicInformation.LD_Type + "','" + m_PublicInformation.PT_Type + "','" + m_PublicInformation.deviceTag + "','" + m_PublicInformation.beforeWelding + "','" + m_PublicInformation.postwelding + "','" + m_PublicInformation.theTest + "','" + m_PublicInformation.authorized + "','" + m_PublicInformation.technologyAuditing + "','" + m_PublicInformation.manufactureAuditing + "','" + m_PublicInformation.dataEntryStaff + "','" + m_PublicInformation.dataEntryStaffTime + "','" + m_PublicInformation.theProductName + "','" + m_PublicInformation.theDescription + "','" + m_PublicInformation.theMatterCode + "','" + m_PublicInformation.theModelAttributes + "','" + m_PublicInformation.theSpecification + "','" + m_PublicInformation.theCustomerType + "','" + m_PublicInformation.theStockNumber + "','" + m_PublicInformation.theContractNumber + "','" + m_PublicInformation.theLD_Type + "','" + m_PublicInformation.thePT_Type + "','" + m_PublicInformation.theDateOfManufacture + "','" + m_PublicInformation.theQuantityOne + "','" + m_PublicInformation.theQuantityTow + "','" + m_PublicInformation.theNumber + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "随工单【" + m_PublicInformation.workOrderNumber + "】上传成功";
                    }
                    else
                    {
                        returnInfo = "随工单【" + m_PublicInformation.workOrderNumber + "】上传失败!!!";
                    }
                    break;
                case "Update":
                    string conStr = string.Empty;
                    if (!d_SQLDBHelper.ISRecordsExists("select count(*) from T_PublicInformation where workOrderNumber='" + m_PublicInformation.workOrderNumber + "'"))
                    {
                        conStr = " <请检查是否存在该随工单>";
                    }
                    sqlStr = "";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "修改随工单成功";
                    }
                    else
                    {
                        returnInfo = "修改随工单失败!!!" + conStr;
                    }
                    break;
                case "Delete": break;
                default: break;
            }
            return returnInfo;
        }

        public string HandleProductInformation(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from T_ProductInformation where productName='" + m_ProductInformation.productName + "'"))
                    {
                        returnInfo = "该产品信息已存在!!!";
                        return returnInfo;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_ProductInformation]([productName],[dataEntryStaff],[entryTime],[productNumber])VALUES('" + m_ProductInformation.productName + "','" + m_ProductInformation.dataEntryStaff + "','" + DateTime.Now.ToString() + "','" + m_ProductInformation.productNumber + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "产品【" + m_ProductInformation.productName + "】添加成功";
                    }
                    else
                    {
                        returnInfo = "产品【" + m_ProductInformation.productName + "】添加失败!!!";
                    }
                    break;
                case "Update": break;
                case "Delete":
                    sqlStr = "DELETE FROM [dbo].[T_ProductInformation] WHERE id in(" + m_ProductInformation.productName.TrimEnd(',') + ")";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "删除成功";
                    }
                    else
                    {
                        returnInfo = "删除失败!!!";
                    }
                    break;
                default: break;
            }
            return returnInfo;
        }

        public string TheFinishProductInfo(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from [T_TheFinishProductInfo] where [productCode]='" + m_ProductInformation.productName + "'"))
                    {
                        returnInfo = "该成品信息已存在!!!";
                        return returnInfo;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_TheFinishProductInfo]([productCode],[dataEntryStaff],[entryTime])VALUES('" + m_ProductInformation.productName + "','" + m_ProductInformation.dataEntryStaff + "','" + m_ProductInformation.entryTime + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "成品【" + m_ProductInformation.productName + "】添加成功";
                    }
                    else
                    {
                        returnInfo = "成品【" + m_ProductInformation.productName + "】添加失败!!!";
                    }
                    break;
                case "Update": break;
                case "Delete":
                    sqlStr = "DELETE FROM [dbo].[T_TheFinishProductInfo] WHERE id in(" + m_ProductInformation.productName.TrimEnd(',') + ")";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "删除成功";
                    }
                    else
                    {
                        returnInfo = "删除失败!!!";
                    }
                    break;
                default: break;
            }
            return returnInfo;
        }

        public string ServiceInfo(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from [T_ServiceInfo] where [clientCode]='" + m_ProductInformation.productName + "'"))
                    {
                        returnInfo = "该客户信息已存在!!!";
                        return returnInfo;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_ServiceInfo]([clientCode],[customerInformation],[dataEntryStaff],[entryTime])VALUES('" + m_ProductInformation.productName + "','" + m_ProductInformation.customerInformation + "','" + m_ProductInformation.dataEntryStaff + "','" + m_ProductInformation.entryTime + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "客户【" + m_ProductInformation.productName + "】添加成功";
                    }
                    else
                    {
                        returnInfo = "客户【" + m_ProductInformation.productName + "】添加失败!!!";
                    }
                    break;
                case "Update": break;
                case "Delete":
                    sqlStr = "DELETE FROM [dbo].[T_ServiceInfo] WHERE id in(" + m_ProductInformation.productName.TrimEnd(',') + ")";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "删除成功";
                    }
                    else
                    {
                        returnInfo = "删除失败!!!";
                    }
                    break;
                default: break;
            }
            return returnInfo;
        }

        public List<string> GetProductInformationList(string p)
        {
            List<string> list = new List<string>();
            DataTable dt = d_SQLDBHelper.GetRecordsTable0(p);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["productName"].ToString());
            }
            return list;
        }

        public string MaintainWorkOrder(M_MaintainWorkOrder m_MaintainWorkOrder, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from [T_MaintainWorkOrder] where [serialNumber]='" + m_MaintainWorkOrder.serialNumber + "'"))
                    {
                        returnInfo = "该产品序列号已存在!!!";
                        return returnInfo;
                    }

                    sqlStr = "INSERT INTO [dbo].[T_MaintainWorkOrder]([settingInformation],[productSerialNumberLength],[productSerialNumberprefix],[settingInformationText],[productSerialNumberText],[productSerialNumberprefixText],[productName],[workOrder],[isAcceptableQualityLevel],[serialNumber],[createTime])VALUES(" + m_MaintainWorkOrder.settingInformation + "," + m_MaintainWorkOrder.productSerialNumberLength + "," + m_MaintainWorkOrder.productSerialNumberprefix + ",'" + m_MaintainWorkOrder.settingInformationText + "','" + m_MaintainWorkOrder.productSerialNumberText + "','" + m_MaintainWorkOrder.productSerialNumberprefixText + "','" + m_MaintainWorkOrder.productName + "','" + m_MaintainWorkOrder.workOrder + "'," + m_MaintainWorkOrder.isAcceptableQualityLevel + ",'" + m_MaintainWorkOrder.serialNumber + "','" + DateTime.Now + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "添加成功";
                    }
                    else
                    {
                        returnInfo = "添加失败!!!";
                    }
                    break;
                case "Update": break;
                case "Delete": break;
                default: break;
            }
            return returnInfo;
        }

        public M_ProcessMaintenance GetM_ProcessMaintenance(string p)
        {
            M_ProcessMaintenance m_ProcessMaintenance = null;
            if (d_SQLDBHelper.ISRecordsExists("select count(*) from [T_MaintainWorkOrder] where [serialNumber]='" + p + "'"))
            {
                m_ProcessMaintenance = new M_ProcessMaintenance();
                DataTable dt = d_SQLDBHelper.GetRecordsTable0("select a.workOrder,b.specificationNumber,c.productCode from [T_MaintainWorkOrder] as a,[T_SpecificInformation] as b,[T_Specifications] as c where a.serialNumber='" + p + "' and a.workOrder=b.workOrderNumberOne and b.specificationNumber=c.specificationsName");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_ProcessMaintenance.workOrder = dt.Rows[i]["workOrder"].ToString();
                    m_ProcessMaintenance.productCode = dt.Rows[i]["productCode"].ToString();
                }
            }
            return m_ProcessMaintenance;
        }

        public bool SaveOrUpdateM_ProcessMaintenance(M_ProcessMaintenance m_ProcessMaintenance)
        {
            bool flag = false;
            if (d_SQLDBHelper.ISRecordsExists("select count(*) from T_ProcessMaintenance where productID='" + m_ProcessMaintenance.productID + "'"))
            {
                flag = d_SQLDBHelper.OperateOnARecordNonQuery("UPDATE [dbo].[T_ProcessMaintenance] SET [inputPersonnel] ='" + m_ProcessMaintenance.inputPersonnel + "',[workOrder] ='" + m_ProcessMaintenance.workOrder + "' ,[productCode] ='" + m_ProcessMaintenance.productCode + "' ,[theProcess] ='" + m_ProcessMaintenance.theProcess + "' ,[productionProcesses] ='" + m_ProcessMaintenance.productionProcesses + "' ,[createTime] ='" + DateTime.Now + "' WHERE [productID] ='" + m_ProcessMaintenance.productID + "'");
            }
            else
            {
                flag = d_SQLDBHelper.OperateOnARecordNonQuery("INSERT INTO [dbo].[T_ProcessMaintenance]([productID],[inputPersonnel],[workOrder],[productCode],[theProcess],[productionProcesses],[createTime]) VALUES ('" + m_ProcessMaintenance.productID + "','" + m_ProcessMaintenance.inputPersonnel + "','" + m_ProcessMaintenance.workOrder + "','" + m_ProcessMaintenance.productCode + "','" + m_ProcessMaintenance.theProcess + "','" + m_ProcessMaintenance.productionProcesses + "','" + DateTime.Now + "')");
            }
            return flag;
        }

        public List<string> GetList(string tableName, string colName, string str)
        {
            string sqlstr = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                sqlstr = "select distinct " + colName + " from " + tableName;
            }
            else
            {
                sqlstr = "select distinct " + colName + " from " + tableName + " where orderNumber=" + str;
            }
            List<string> list = new List<string>();
            DataTable dt = d_SQLDBHelper.GetRecordsTable0(sqlstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][colName].ToString());
            }
            return list;
        }

        public List<string> GetKeFu(string  sqlStr)
        {
            List<string> str = new List<string>();
            DataTable dt = new DataTable();
            dt = d_SQLDBHelper.GetRecordsTable0(sqlStr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Add(dt.Rows[i][0].ToString());
                str.Add(dt.Rows[i][1].ToString());
            }
            return str;
        }

        public string CreateWorkOrder(M_CreateAWorkOrder m_CreateAWorkOrder, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    if (d_SQLDBHelper.ISRecordsExists("select count(*) from [T_CerateWorkOrder] where [orderMD5Number]='" + m_CreateAWorkOrder.orderMD5Number + "'"))
                    {
                        returnInfo = "该工单信息已存在!!!";
                        return returnInfo;
                    }
                    sqlStr = "INSERT INTO [dbo].[T_CerateWorkOrder]([shopCode],[currentOperation],[singleType],[totalProduction],[orderNumber] ,[manufacturingProcess],[customerName],[poductCode],[orderMD5Number],[createTime]) VALUES ('" + m_CreateAWorkOrder.shopCode + "','" + m_CreateAWorkOrder.currentOperation + "','" + m_CreateAWorkOrder.singleType + "','" + m_CreateAWorkOrder.totalProduction + "','" + m_CreateAWorkOrder.orderNumber + "','" + m_CreateAWorkOrder.manufacturingProcess + "','" + m_CreateAWorkOrder.customerName + "','" + m_CreateAWorkOrder.poductCode + "','" + m_CreateAWorkOrder.orderMD5Number + "','" + m_CreateAWorkOrder.createTime + "')";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "添加成功";
                    }
                    else
                    {
                        returnInfo = "添加失败!!!";
                    }
                    break;
                case "Update": break;
                case "Delete":
                    sqlStr = "DELETE FROM [dbo].[T_CerateWorkOrder] WHERE id in(" + m_CreateAWorkOrder.id.TrimEnd(',') + ") and isConfirm='否'";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                    {
                        returnInfo = "删除成功";
                    }
                    else
                    {
                        returnInfo = "删除失败!!!<不能删除已确认的工单>";
                    }
                    break;
                default: break;
            }
            return returnInfo;
        }

        public string HandleM_ImportPlan(M_ImportPlan m_ImportPlan, M_SQLType m_SQLType)
        {
            string returnInfo = string.Empty;
            string sqlStr = string.Empty;
            switch (m_SQLType.ToString())
            {
                case "Select": break;
                case "Insert"://','"+m_ImportWorkOrder.currentOperation+"'
                    break;
                case "Update": break;
                case "Delete":
                    sqlStr = "DELETE FROM [dbo].[T_ImportPlan] WHERE id in(" + m_ImportPlan.id.TrimEnd(',') + ")";
                    if (d_SQLDBHelper.OperateOnARecordNonQuery(sqlStr))
                        {
                            returnInfo = "删除成功";
                        }
                        else
                        {
                            returnInfo = "删除失败!!!";
                        }
                    break;
                default: break;
            }
            return returnInfo;
        }

        public DataTable GetTable_ConfirmWorkOrder(string p1, string p2, string p3)
        {
            DataTable dt = new DataTable();
            dt = d_SQLDBHelper.GetRecordsTable0("select " + p2 + " from " + p1 + " where " + p3);
            return dt;
        }

        public List<string> GetListProductNumber(string str)
        {
            List<string> list = new List<string>();
            DataTable dt = new DataTable();
            dt = d_SQLDBHelper.GetRecordsTable0("select b.productNumber from T_ImportPlan as a,T_JoinT_ImportPlan as b where a.id in(b.FK) and a.orderNumber='" + str+"'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i]["productNumber"].ToString());
            }
            return list;
        }

        public bool UpdateWorkOrder(string selectID)
        {
            bool falg = false;
            falg=d_SQLDBHelper.OperateOnARecordNonQuery("UPDATE [dbo].[T_CerateWorkOrder] SET [isConfirm]='是' where [orderMD5Number] in(" + selectID + ")");
            return falg;
        }
    }
}
