using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_Execution
{
    public partial class Manufacturing2 : MetroAppForm
    {
        public Manufacturing2()
        {
            InitializeComponent();
        }

        private void productInformation_Click(object sender, EventArgs e)
        {
            ProductInformation productInformationFrom = new ProductInformation();
            productInformationFrom.ShowDialog();
        }

        private void theFinishProductInfo_Click(object sender, EventArgs e)
        {
            TheFinishProductInfo theFinishProductInfoFrom = new TheFinishProductInfo();
            theFinishProductInfoFrom.ShowDialog();
        }

        private void serviceInfo_Click(object sender, EventArgs e)
        {
            ServiceTheInfo serviceInfoFrom = new ServiceTheInfo();
            serviceInfoFrom.ShowDialog();
        }

        private void reworkInput_Click(object sender, EventArgs e)
        {
            ReworkInput reworkInputFrom = new ReworkInput();
            reworkInputFrom.ShowDialog();
        }

        private void reworkOut_Click(object sender, EventArgs e)
        {
            ReworkOut reworkOutFrom = new ReworkOut();
            reworkOutFrom.ShowDialog();
        }

        private void theAssociatedCode_Click(object sender, EventArgs e)
        {
            TheAssociatedCode theAssociatedCodeFrom = new TheAssociatedCode();
            theAssociatedCodeFrom.ShowDialog();
        }

        private void publicInformation_Click(object sender, EventArgs e)
        {
            PublicInformation publicInformationFrom = new PublicInformation();
            publicInformationFrom.ShowDialog();
        }

        private void specificInformation_Click(object sender, EventArgs e)
        {
            SpecificInformation specificInformationFrom = new SpecificInformation();
            specificInformationFrom.ShowDialog();
        }

        private void specifications_Click(object sender, EventArgs e)
        {
            Specifications specificationsFrom = new Specifications();
            specificationsFrom.ShowDialog();
        }

        private void outgoingQuery_Click(object sender, EventArgs e)
        {
            OutgoingQuery outgoingQueryFrom = new OutgoingQuery();
            outgoingQueryFrom.ShowDialog();
        }

        private void query_Click(object sender, EventArgs e)
        {
            Query queryFrom = new Query();
            queryFrom.ShowDialog();
        }

        private void maintainWorkOrder_Click(object sender, EventArgs e)
        {
            MaintainWorkOrder maintainWorkOrderFrom = new MaintainWorkOrder();
            maintainWorkOrderFrom.ShowDialog();
        }

        private void processMaintenance_Click(object sender, EventArgs e)
        {
            ProcessMaintenance processMaintenanceFrom = new ProcessMaintenance();
            processMaintenanceFrom.ShowDialog();
        }

        private void badReport_Click(object sender, EventArgs e)
        {
            BadReport badReportFrom = new BadReport();
            badReportFrom.ShowDialog();
        }

        private void adverseAnalysis_Click(object sender, EventArgs e)
        {
            AdverseAnalysis adverseAnalysisFrom = new AdverseAnalysis();
            adverseAnalysisFrom.ShowDialog();
        }

        private void scrapInput_Click(object sender, EventArgs e)
        {
            ScrapInput scrapInputFrom = new ScrapInput();
            scrapInputFrom.ShowDialog();
        }

        private void packagingSite_Click(object sender, EventArgs e)
        {
            PackagingSite packagingSiteFrom = new PackagingSite();
            packagingSiteFrom.ShowDialog();
        }

        private void cleaningSite_Click(object sender, EventArgs e)
        {
            CleaningSite cleaningSiteFrom = new CleaningSite();
            cleaningSiteFrom.ShowDialog();
        }

        private void stackSite_Click(object sender, EventArgs e)
        {
            StackSite stackSiteFrom = new StackSite();
            stackSiteFrom.ShowDialog();
        }

        private void spellCabinetSite_Click(object sender, EventArgs e)
        {
            SpellCabinetSite spellCabinetSiteFrom = new SpellCabinetSite();
            spellCabinetSiteFrom.ShowDialog();
        }

        private void weldingSite_Click(object sender, EventArgs e)
        {
            WeldingSite weldingSiteFrom = new WeldingSite();
            weldingSiteFrom.ShowDialog();
        }

        private void createAWorkOrder_Click(object sender, EventArgs e)
        {
            CreateAWorkOrder createAWorkOrderFrom = new CreateAWorkOrder();
            createAWorkOrderFrom.ShowDialog();
        }

        private void Manufacturing2_Load(object sender, EventArgs e)
        {

        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }


      
    }
}
