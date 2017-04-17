using Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NOPI_Excel
    {
        /// <summary>
        /// ------EXCEL转DataTable
        /// </summary>
        /// <param name="fileName">文件路径名</param>
        /// <param name="sheetName">sheet名</param>
        /// <param name="isFirstRowColumn">是否显示列</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            FileStream fs = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        public static M_ImportPlan GetExcelToM_ImportPlan(string filePath)
        {
            ISheet sheet;
            FileStream fs;
            IWorkbook workbook;
            M_ImportPlan m_ImportPlan;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.IndexOf(".xlsx") > 0)
                {// 2007版本
                    workbook = new XSSFWorkbook(fs);
                }
                else
                {// 2003版本
                    workbook = new HSSFWorkbook(fs);
                }
                m_ImportPlan = new M_ImportPlan();
                sheet = workbook.GetSheetAt(0);
                m_ImportPlan.orderNumber = sheet.GetRow(0).GetCell(1).StringCellValue.ToString();
                int count = 2;
                m_ImportPlan.m_ListWorkOrderInfo = new List<M_ListPlanInfo>();
                int lastCell = sheet.GetRow(2).Cells.Count;
                while (true)
                {
                    IRow rows=sheet.GetRow(count);
                    if (rows != null && rows.Cells.Count == lastCell)
                    {
                         M_ListPlanInfo m_ListPlanInfo = new M_ListPlanInfo();
                    m_ListPlanInfo.productName = rows.GetCell(0).StringCellValue.ToString();
                    m_ListPlanInfo.deliveryDate = DateTime.Parse(rows.GetCell(1).DateCellValue.ToString());
                    m_ListPlanInfo.client = rows.GetCell(2).StringCellValue.ToString();
                    m_ListPlanInfo.productNumber = int.Parse(rows.GetCell(3).NumericCellValue.ToString());
                    m_ImportPlan.m_ListWorkOrderInfo.Add(m_ListPlanInfo);
                    count++;
                        
                    }
                    else{
                        break;
                    }
                   
                }
                workbook.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return m_ImportPlan;
        }
    }
}
