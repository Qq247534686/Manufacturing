using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data.SqlClient;
using System.Data;
namespace BLL
{
    public class B_GetMethod
    {
        DAL.D_GetMethod d_GetMethod = new DAL.D_GetMethod();
        /// <summary>
        /// 获取图片对象
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <returns></returns>
         public static Bitmap ReadImageFile(string path)
        {
            return DAL.D_GetMethod.ReadImageFile(path);
        }
        /// <summary>
        /// 计划导入
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="m_SQLType">操作类型</param>
        /// <returns></returns>
        
         public bool ImportPlanMethod(string filePath)
         {
             return d_GetMethod.ImportPlanMethod(filePath);
         }
        /// <summary>
        /// 规格书录入
        /// </summary>
        /// <param name="m_Specifications">规格书对象</param>
        /// <param name="m_SQLType">操作类型</param>
        /// <returns></returns>
        public  string HandleSpecifications(M_Specifications m_Specifications,M_SQLType m_SQLType)
         {
             return d_GetMethod.HandleSpecifications(m_Specifications, m_SQLType);
         }
        /// <summary>
        /// 随工单具体信息上传
        /// </summary>
        /// <param name="m_SpecificInformation"></param>
        /// <param name="m_SQLType"></param>
        /// <returns></returns>
        public string HandleSpecificInformation(M_SpecificInformation m_SpecificInformation, M_SQLType m_SQLType)
        {
            return d_GetMethod.HandleSpecificInformation(m_SpecificInformation, m_SQLType);
        }
        /// <summary>
        /// 获得表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="selectColumns">列名</param>
        /// <returns></returns>
        public DataTable GetTable(string tableName, string selectColumns)
        {
            return d_GetMethod.GetTable(tableName, selectColumns);
        }
        /// <summary>
        /// 获得规格书对象
        /// </summary>
        /// <returns></returns>
        public M_Specifications GetM_Specifications(string keyword)
        {
            return d_GetMethod.GetM_Specifications(keyword);
        }
        /// <summary>
        /// 获得具体随工单对象
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public M_SpecificInformation GetM_SpecificInformation(string keyword)
        {
            return d_GetMethod.GetM_SpecificInformation(keyword);
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logStr">信息</param>
       public static void LogWrite(string logStr)
        {
            Log.LogWrite(logStr);
        }
        /// <summary>
        /// 获得所有规格书编号
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
       public List<string> GetM_SpecificationsList(string sqlStr)
       {
           return d_GetMethod.GetM_SpecificationsList(sqlStr);
       }
        /// <summary>
        /// 随工单公共信息增删查改
        /// </summary>
        /// <param name="m_PublicInformation"></param>
        /// <param name="m_SQLType"></param>
        /// <returns></returns>
       public string HandlePublicInformation(M_PublicInformation m_PublicInformation, M_SQLType m_SQLType)
       {
           return d_GetMethod.HandlePublicInformation(m_PublicInformation, m_SQLType);
       }
        /// <summary>
        /// 执行sql语句是否成功
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
       public bool ExecuteSentence(string str)
       {
           return d_GetMethod.ExecuteSentence(str);
       }
        /// <summary>
        /// 产品信息增删查改
        /// </summary>
        /// <param name="m_ProductInformation"></param>
        /// <param name="m_SQLType"></param>
        /// <returns></returns>
       public string HandleProductInformation(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
       {
           return d_GetMethod.HandleProductInformation(m_ProductInformation, m_SQLType);
       }
        /// <summary>
        /// 成品编码的增删查改
        /// </summary>
        /// <param name="m_ProductInformation"></param>
        /// <param name="m_SQLType"></param>
        /// <returns></returns>
       public string TheFinishProductInfo(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
       {
           return d_GetMethod.TheFinishProductInfo(m_ProductInformation, m_SQLType);
       }
       /// <summary>
       /// 客户信息的增删查改
       /// </summary>
       /// <param name="m_ProductInformation"></param>
       /// <param name="m_SQLType"></param>
       /// <returns></returns>
       public string ServiceInfo(M_ProductInformation m_ProductInformation, M_SQLType m_SQLType)
       {
           return d_GetMethod.ServiceInfo(m_ProductInformation, m_SQLType);
       }
        /// <summary>
        /// 获得产品名称的集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
       public List<string> GetProductInformationList(string p)
       {
           return d_GetMethod.GetProductInformationList(p);
       }
        /// <summary>
        /// 工单维护增删查改
        /// </summary>
        /// <param name="m_MaintainWorkOrder"></param>
        /// <param name="m_SQLType"></param>
        /// <returns></returns>
       public string MaintainWorkOrder(M_MaintainWorkOrder m_MaintainWorkOrder, M_SQLType m_SQLType)
       {
           return d_GetMethod.MaintainWorkOrder(m_MaintainWorkOrder, m_SQLType);
       }
        /// <summary>
        /// 获得工序维护的对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
       public M_ProcessMaintenance GetM_ProcessMaintenance(string p)
       {
           return d_GetMethod.GetM_ProcessMaintenance(p);
       }
        /// <summary>
        /// 保存或者修改工序
        /// </summary>
        /// <param name="m_ProcessMaintenance"></param>
        /// <returns></returns>
       public bool SaveOrUpdateM_ProcessMaintenance(M_ProcessMaintenance m_ProcessMaintenance)
       {
           return d_GetMethod.SaveOrUpdateM_ProcessMaintenance(m_ProcessMaintenance);
       }

       public List<string> GetList(string tableName,string colName,string str)
       {
           return d_GetMethod.GetList(tableName, colName, str);
       }

       public List<string> GetKeFu(string str1)
       {
           return d_GetMethod.GetKeFu(str1);
       }
       public string CreateWorkOrder(M_CreateAWorkOrder m_CreateAWorkOrder, M_SQLType m_SQLType)
       {
           return d_GetMethod.CreateWorkOrder(m_CreateAWorkOrder, m_SQLType);
       }

       public string HandleM_ImportPlan(M_ImportPlan m_ImportPlan, M_SQLType m_SQLType)
       {
           return d_GetMethod.HandleM_ImportPlan(m_ImportPlan, m_SQLType);
       }

       public DataTable GetTable_ConfirmWorkOrder(string p1, string p2, string p3)
       {
           return d_GetMethod.GetTable_ConfirmWorkOrder(p1, p2, p3);
       }

       public List<string> GetListProductNumber(string str)
       {
           return d_GetMethod.GetListProductNumber(str);
       }

       public bool UpdateWorkOrder(string selectID)
       {
           return d_GetMethod.UpdateWorkOrder(selectID);
       }
    }
}
