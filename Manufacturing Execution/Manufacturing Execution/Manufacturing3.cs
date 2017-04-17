using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_Execution
{
    public partial class Manufacturing3 : MetroAppForm
    {
        public Manufacturing3()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 判断主程序是否重复被打开
        /// </summary>
        private void IsOpenThisProcess()
        {
            Assembly assembly = Assembly.GetExecutingAssembly( );
            foreach (Process p in Process.GetProcesses(System.Environment.MachineName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    //显示用户程序名
                    if (p.ProcessName == assembly.GetName().Name)
                    {
                        Alert alert = new Alert("该程序已经打开了", @"../../Images/warning.png");
                        alert.Text = "警告";
                        alert.ShowDialog();
                        //MessageBox.Show("该程序已经打开了", "提示", MessageBoxButtons.OK);
                        Application.Exit();
                        return;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            contextMenuStrip1.Hide();
            //IsOpenThisProcess();
            notifyIcon1.Visible = true;
            contextMenuStrip1.Show();
            radialMenuone1.Hide();
            radialMenuone2.Hide();
            radialMenuone3.Hide();
            radialMenuone4.Hide();
            radialMenutow1.Hide();
            radialMenutow2.Hide();
            radialMenutow3.Hide();
            radialMenutow4.Hide();
            radialMenuthree1.Hide();
            radialMenuthree2.Hide();
            radialMenuthree3.Hide();
            radialMenuthree4.Hide();
            //文件
            radialMenuItem1.Click += radialMenuItem1_Click;
            radialMenuItem2.Click += radialMenuItem2_Click;
            radialMenuItem3.Click += radialMenuItem3_Click;
            radialMenuItem4.Click += radialMenuItem4_Click;
            radialMenuItem5.Click += radialMenuItem5_Click;
            //返修
            radialMenuItem6.Click += radialMenuItem6_Click;
            radialMenuItem7.Click += radialMenuItem7_Click;
            radialMenuItem8.Click += radialMenuItem8_Click;
            //随工单信息
            radialMenuItem9.Click += radialMenuItem9_Click;
            radialMenuItem10.Click += radialMenuItem10_Click;
            radialMenuItem11.Click += radialMenuItem11_Click;
            //数据分析
            radialMenuItem12.Click += radialMenuItem12_Click;
            radialMenuItem13.Click += radialMenuItem13_Click;
            //生产管理
            radialMenuItem14.Click += radialMenuItem14_Click;
            radialMenuItem15.Click += radialMenuItem15_Click;
            radialMenuItem16.Click += radialMenuItem16_Click;
            radialMenuItem17.Click += radialMenuItem17_Click;
            radialMenuItem18.Click += radialMenuItem18_Click;
            radialMenuItem19.Click += radialMenuItem19_Click;
            radialMenuItem50.Click += radialMenuItem50_Click;
            //工艺管理
            radialMenuItem24.Click += radialMenuItem24_Click;
            radialMenuItem25.Click += radialMenuItem25_Click;
            radialMenuItem26.Click += radialMenuItem26_Click;
            radialMenuItem27.Click += radialMenuItem27_Click;
            radialMenuItem28.Click += radialMenuItem28_Click;
            //物料管理
            //人员管理
            radialMenuItem31.Click += radialMenuItem31_Click;
            //机台管理
            //生产看板
            //质量管理
            //计划排程
            metroTileItem6.AutoRotateFramesInterval = 3000;
            radialMenuItem40.Click += radialMenuItem40_Click;
            radialMenuItem49.Click += radialMenuItem49_Click;
            timer1.Start();
        }

        void radialMenuItem50_Click(object sender, EventArgs e)
        {
            ConfirmWorkOrder confirmWorkOrder = new ConfirmWorkOrder();
            confirmWorkOrder.Text = "确认工单";
            confirmWorkOrder.ShowDialog();
        }

        void radialMenuItem31_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.ShowDialog();
        }

        void radialMenuItem49_Click(object sender, EventArgs e)
        {
            ImportWorkOrder importWorkOrderForm = new ImportWorkOrder();
            importWorkOrderForm.ShowDialog();
        }
        void radialMenuItem4_Click(object sender, EventArgs e)
        {
            ServiceTheInfo serviceInfoFrom = new ServiceTheInfo();
            serviceInfoFrom.Text = "客户信息";
            serviceInfoFrom.ShowDialog();
        }

        void radialMenuItem40_Click(object sender, EventArgs e)
        {
            CreateAWorkOrder createAWorkOrderFrom = new CreateAWorkOrder();
            createAWorkOrderFrom.Text = "创建工单";
            createAWorkOrderFrom.ShowDialog();
        }

        void radialMenuItem28_Click(object sender, EventArgs e)
        {
            WeldingSite weldingSiteFrom = new WeldingSite();
            weldingSiteFrom.Text = "焊接站点";
            weldingSiteFrom.ShowDialog();
        }

        void radialMenuItem27_Click(object sender, EventArgs e)
        {
            SpellCabinetSite spellCabinetSiteFrom = new SpellCabinetSite();
            spellCabinetSiteFrom.Text = "拼柜站点";
            spellCabinetSiteFrom.ShowDialog();
        }

        void radialMenuItem26_Click(object sender, EventArgs e)
        {
            StackSite stackSiteFrom = new StackSite();
            stackSiteFrom.Text = "叠层站点";
            stackSiteFrom.ShowDialog();
        }

        void radialMenuItem25_Click(object sender, EventArgs e)
        {
            CleaningSite cleaningSiteFrom = new CleaningSite();
            cleaningSiteFrom.Text = "清洗站点";
            cleaningSiteFrom.ShowDialog();
        }

        void radialMenuItem24_Click(object sender, EventArgs e)
        {
            PackagingSite packagingSiteFrom = new PackagingSite();
            packagingSiteFrom.Text = "包装站点";
            packagingSiteFrom.ShowDialog();
        }

        void radialMenuItem19_Click(object sender, EventArgs e)
        {
            ScrapInput scrapInputFrom = new ScrapInput();
            scrapInputFrom.Text = "报废品录入";
            scrapInputFrom.ShowDialog();
        }

        void radialMenuItem18_Click(object sender, EventArgs e)
        {
            AdverseAnalysis adverseAnalysisFrom = new AdverseAnalysis();
            adverseAnalysisFrom.Text = "不良品分析";
            adverseAnalysisFrom.ShowDialog();
        }

        void radialMenuItem17_Click(object sender, EventArgs e)
        {
            BadReport badReportFrom = new BadReport();
            badReportFrom.Text = "生产不良报告";
            badReportFrom.ShowDialog();
        }

        void radialMenuItem16_Click(object sender, EventArgs e)
        {
            ProcessMaintenance processMaintenanceFrom = new ProcessMaintenance();
            processMaintenanceFrom.Text = "工序维护";
            processMaintenanceFrom.ShowDialog();
        }

        void radialMenuItem15_Click(object sender, EventArgs e)
        {
            MaintainWorkOrder maintainWorkOrderFrom = new MaintainWorkOrder();
            maintainWorkOrderFrom.Text = "工单维护";
            maintainWorkOrderFrom.ShowDialog();
        }

        void radialMenuItem14_Click(object sender, EventArgs e)
        {
            return;
        }

        void radialMenuItem13_Click(object sender, EventArgs e)
        {
            Query queryFrom = new Query();
            queryFrom.Text = "查询";
            queryFrom.ShowDialog();
        }

        void radialMenuItem12_Click(object sender, EventArgs e)
        {
            OutgoingQuery outgoingQueryFrom = new OutgoingQuery();
            outgoingQueryFrom.Text = "出货查询";
            outgoingQueryFrom.ShowDialog();
        }

        void radialMenuItem11_Click(object sender, EventArgs e)
        {
            Specifications specificationsFrom = new Specifications();
            specificationsFrom.Text = "规格书录入";
            specificationsFrom.ShowDialog();
        }

        void radialMenuItem10_Click(object sender, EventArgs e)
        {
            SpecificInformation specificInformationFrom = new SpecificInformation();
            specificInformationFrom.Text = "随工单具体信息";
            specificInformationFrom.ShowDialog();
        }

        void radialMenuItem9_Click(object sender, EventArgs e)
        {
            PublicInformation publicInformationFrom = new PublicInformation();
            publicInformationFrom.Text = "随工单公共信息";
            publicInformationFrom.ShowDialog();
        }

        void radialMenuItem8_Click(object sender, EventArgs e)
        {
            TheAssociatedCode theAssociatedCodeFrom = new TheAssociatedCode();
            theAssociatedCodeFrom.Text = "关联码导出";
            theAssociatedCodeFrom.ShowDialog();
        }

        void radialMenuItem7_Click(object sender, EventArgs e)
        {
            ReworkOut reworkOutFrom = new ReworkOut();
            reworkOutFrom.Text = "返修数据录入（出）";
            reworkOutFrom.ShowDialog();
        }

        void radialMenuItem6_Click(object sender, EventArgs e)
        {
            ReworkInput reworkInputFrom = new ReworkInput();
            reworkInputFrom.Text = "返修数据录入（入）";
            reworkInputFrom.ShowDialog();
        }

        void radialMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void radialMenuItem3_Click(object sender, EventArgs e)
        {
            TheFinishProductInfo theFinishProductInfoFrom = new TheFinishProductInfo();
            theFinishProductInfoFrom.Text = "成品信息";
            theFinishProductInfoFrom.ShowDialog();
        }
        void radialMenuItem2_Click(object sender, EventArgs e)
        {
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, "未发现有打印机！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 3000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }

        void radialMenuItem1_Click(object sender, EventArgs e)
        {
            ProductInformation productInformationFrom = new ProductInformation();
            productInformationFrom.Text = "产品信息";
            productInformationFrom.ShowDialog();
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {

            radialMenuone1.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            radialMenuone2.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem8_Click(object sender, EventArgs e)
        {
            radialMenuone3.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            radialMenuone4.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            radialMenutow1.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            radialMenutow2.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem12_Click(object sender, EventArgs e)
        {
            radialMenutow3.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            radialMenutow4.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem14_Click(object sender, EventArgs e)
        {
            radialMenuthree1.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem15_Click(object sender, EventArgs e)
        {
            radialMenuthree2.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem16_Click(object sender, EventArgs e)
        {
            radialMenuthree3.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTileItem17_Click(object sender, EventArgs e)
        {
            radialMenuthree4.SetIsOpen(true, DevComponents.DotNetBar.eEventSource.Mouse);
        }

        private void metroTilePanel1_ItemClick(object sender, EventArgs e)
        {

        }
        int clickCount = 1;
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (clickCount == 1)
            {
                double d=1.0;
                while (d > 0)
                {
                    d = d - 0.4;
                    this.Opacity = d;
                    Thread.Sleep(200);
                }
                this.Visible = false;
                clickCount = 2;
            }
            else
            {
                this.Opacity = 1;
                this.Visible = true;
                clickCount = 1;
            }
            
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.ShowItemToolTips = true ;
        }

        private void Manufacturing3_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroShellpb_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelX1.Text = DateTime.Now.ToString("HH:mm:ss") +" "+ DateTime.Now.DayOfWeek.ToString() +" "+ DateTime.Now.ToString("yyyy-MM-dd");
        }
       


    }
}
