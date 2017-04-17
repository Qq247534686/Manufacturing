using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.WinForms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Threading;
namespace Manufacturing_Execution
{
    public partial class Manufacturing : MetroAppForm
    {
        public Manufacturing()
        {
            InitializeComponent();
        }
        
        #region 按钮事件
        /// <summary>
        /// 产品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barProductInformation_Click(object sender, EventArgs e)
        {
            ProductInformation productInformationFrom = new ProductInformation();
            productInformationFrom.Text = "产品信息";
            productInformationFrom.ShowDialog();
        }
        /// <summary>
        /// 成品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barTheFinishProductInfo_Click(object sender, EventArgs e)
        {
            TheFinishProductInfo theFinishProductInfoFrom = new TheFinishProductInfo();
            theFinishProductInfoFrom.Text = "成品信息";
            theFinishProductInfoFrom.ShowDialog();
        }
       
        /// <summary>
        /// 客户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barServiceInfo_Click(object sender, EventArgs e)
        {
            ServiceTheInfo serviceInfoFrom = new ServiceTheInfo();
            serviceInfoFrom.Text = "客户信息";
            serviceInfoFrom.ShowDialog();
        }
        /// <summary>
        /// 返修数据录入（入）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barReworkInput_Click(object sender, EventArgs e)
        {
            ReworkInput reworkInputFrom = new ReworkInput();
            reworkInputFrom.Text = "返修数据录入（入）";
            reworkInputFrom.ShowDialog();
        }
        /// <summary>
        /// 返修数据录入（出）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barReworkOut_Click(object sender, EventArgs e)
        {
            ReworkOut reworkOutFrom = new ReworkOut();
            reworkOutFrom.Text = "返修数据录入（出）";
            reworkOutFrom.ShowDialog();
        }
        /// <summary>
        /// 关联码导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barTheAssociatedCode_Click(object sender, EventArgs e)
        {
            TheAssociatedCode theAssociatedCodeFrom = new TheAssociatedCode();
            theAssociatedCodeFrom .Text= "关联码导出";
            theAssociatedCodeFrom.ShowDialog();
        }
        /// <summary>
        /// 随工单公共信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barPublicInformation_Click(object sender, EventArgs e)
        {
            PublicInformation publicInformationFrom = new PublicInformation();
            publicInformationFrom .Text= "随工单公共信息";
            publicInformationFrom.ShowDialog();
        }
        /// <summary>
        /// 随工单具体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSpecificInformation_Click(object sender, EventArgs e)
        {
            SpecificInformation specificInformationFrom = new SpecificInformation();
            specificInformationFrom .Text= "随工单具体信息";
            specificInformationFrom.ShowDialog();
        }
        /// <summary>
        /// 规格书录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSpecifications_Click(object sender, EventArgs e)
        {
            Specifications specificationsFrom = new Specifications();
            specificationsFrom .Text= "规格书录入";
            specificationsFrom.ShowDialog();
        }
        /// <summary>
        /// 出货查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barOutgoingQuery_Click(object sender, EventArgs e)
        {
            OutgoingQuery outgoingQueryFrom = new OutgoingQuery();
            outgoingQueryFrom .Text= "出货查询";
            outgoingQueryFrom.ShowDialog();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barQuery_Click(object sender, EventArgs e)
        {
            Query queryFrom = new Query();
            queryFrom .Text= "查询";
            queryFrom.ShowDialog();
        }
        /// <summary>
        /// 工单维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barMaintainWorkOrder_Click(object sender, EventArgs e)
        {
            MaintainWorkOrder maintainWorkOrderFrom = new MaintainWorkOrder();
            maintainWorkOrderFrom .Text= "工单维护";
            maintainWorkOrderFrom.ShowDialog();
        }
        /// <summary>
        /// 工序维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barProcessMaintenance_Click(object sender, EventArgs e)
        {
            ProcessMaintenance processMaintenanceFrom = new ProcessMaintenance();
            processMaintenanceFrom.Text = "工序维护";
            processMaintenanceFrom.ShowDialog();
        }
        /// <summary>
        /// 生产不良报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBadReport_Click(object sender, EventArgs e)
        {
            BadReport badReportFrom = new BadReport();
            badReportFrom.Text= "生产不良报告";
            badReportFrom.ShowDialog();
        }
        /// <summary>
        /// 不良品分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barAdverseAnalysis_Click(object sender, EventArgs e)
        {
            AdverseAnalysis adverseAnalysisFrom = new AdverseAnalysis();
            adverseAnalysisFrom.Text= "不良品分析";
            adverseAnalysisFrom.ShowDialog();
        }
        /// <summary>
        /// 报废品录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barScrapInput_Click(object sender, EventArgs e)
        {
            ScrapInput scrapInputFrom = new ScrapInput();
            scrapInputFrom.Text= "报废品录入";
            scrapInputFrom.ShowDialog();
        }
        /// <summary>
        /// 包装站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barPackagingSite_Click(object sender, EventArgs e)
        {
            PackagingSite packagingSiteFrom = new PackagingSite();
            packagingSiteFrom.Text= "包装站点";
            packagingSiteFrom.ShowDialog();
        }
        /// <summary>
        /// 清洗站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCleaningSite_Click(object sender, EventArgs e)
        {
            CleaningSite cleaningSiteFrom = new CleaningSite();
            cleaningSiteFrom.Text= "清洗站点";
            cleaningSiteFrom.ShowDialog();
        }
        /// <summary>
        /// 叠层站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barStackSite_Click(object sender, EventArgs e)
        {
            StackSite stackSiteFrom = new StackSite();
            stackSiteFrom.Text= "叠层站点";
            stackSiteFrom.ShowDialog();
        }
        /// <summary>
        /// 拼柜站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barSpellCabinetSite_Click(object sender, EventArgs e)
        {
            SpellCabinetSite spellCabinetSiteFrom = new SpellCabinetSite();
            spellCabinetSiteFrom.Text= "拼柜站点";
            spellCabinetSiteFrom.ShowDialog();
        }
        /// <summary>
        /// 焊接站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barWeldingSite_Click(object sender, EventArgs e)
        {
            WeldingSite weldingSiteFrom = new WeldingSite();
            weldingSiteFrom.Text = "焊接站点";
            weldingSiteFrom.ShowDialog();
        }
        /// <summary>
        /// 创建工单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCreateAWorkOrder_Click(object sender, EventArgs e)
        {
            CreateAWorkOrder createAWorkOrderFrom = new CreateAWorkOrder();
            createAWorkOrderFrom.Text = "创建工单";
            createAWorkOrderFrom.ShowDialog();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {

        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, "未发现有打印机！！！", ReadImageFile(@"../../Images/2.png"), 3000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            //Alert alert = new Alert("欢饮光临！！！");
            //alert.Text = "打印";
            //alert.ShowDialog();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Manufacturing_Load(object sender, EventArgs e)
        {
          
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {

        }
        #endregion




        /// <summary>
        /// 读取图片的方法
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Bitmap ReadImageFile(string path)
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

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {

        }

        private void metroShellmain_Click(object sender, EventArgs e)
        {

        }

        private void metroStatusBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {

        }

       

    }
}
