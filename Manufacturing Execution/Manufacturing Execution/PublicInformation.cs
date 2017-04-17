using BLL;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using Model;
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
    public partial class PublicInformation : MetroAppForm
    {
        B_GetMethod b_GetMethod = new B_GetMethod();
        public PublicInformation()
        {
            InitializeComponent();
        }

        private void PublicInformation_Load(object sender, EventArgs e)
        {
            highlighter2.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            highlighter2.SetHighlightOnFocus(textBoxX1, true);
            LockControl();
            comboBox1.DataSource = b_GetMethod.GetM_SpecificationsList("select specificationsName from T_Specifications");
            comboBox2.DataSource = b_GetMethod.GetProductInformationList("select [productName] from [T_ProductInformation]");
            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            //comboBox1.DataSource = b_GetMethod.GetM_SpecificationsList("select specificationsName from T_Specifications");
            radialMenuItem1.Click += radialMenuItem1_Click;
            radialMenuItem2.Click += radialMenuItem2_Click;
            radialMenuItem3.Click += radialMenuItem3_Click;
            radialMenuItem4.Click += radialMenuItem4_Click;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radialMenuItem3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radialMenuItem2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radialMenuItem1_Click(object sender, EventArgs e)
        {
            string img = string.Empty;
            M_PublicInformation m_PublicInformation=GetM_PublicInformation();
            string returnInfo = b_GetMethod.HandlePublicInformation(m_PublicInformation, M_SQLType.Insert);
            img=returnInfo.Equals("随工单【" + m_PublicInformation.workOrderNumber+ "】上传成功")?@"../../Images/success.png":@"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }
        /// <summary>
        /// 锁定控件
        /// </summary>
        private void LockControl()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
            textBoxX1.Focus();
            metroShellpb.Enabled = true;
            textBoxX1.Enabled = true;
        }
        void radialMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            textBox68.Text = textBoxX1.Text;
            textBox7.Text = textBoxX1.Text;
            highlighter2.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            highlighter2.SetHighlightOnFocus(textBoxX1, true);
            if (!string.IsNullOrEmpty(textBoxX1.Text.Trim()))
            {
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }
                M_SpecificInformation m_SpecificInformation = b_GetMethod.GetM_SpecificInformation(textBoxX1.Text);
                M_SpecificInformationPaddingDataToControl(m_SpecificInformation);
            }
            else
            {
                LockControl();
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "请输入随工单序号！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 3000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }



        private M_PublicInformation GetM_PublicInformation()
        {
            M_PublicInformation m_PublicInformation = new M_PublicInformation();
            m_PublicInformation.workOrderNumber = textBoxX1.Text;
            m_PublicInformation.deliveryDate = dateTimePicker1.Value;
            m_PublicInformation.orderDate = dateTimePicker2.Value;
            m_PublicInformation.contractNumber = textBox1.Text;
            m_PublicInformation.specificationNumber = comboBox1.SelectedItem.ToString();
            m_PublicInformation.tbleNumberOne = textBox3.Text;
            m_PublicInformation.tbleNumberTow = textBox4.Text;

            m_PublicInformation.productModel = textBox5.Text;
            m_PublicInformation.productCode = textBox9.Text;
            m_PublicInformation.productName = comboBox2.SelectedItem.ToString();
            m_PublicInformation.productChartNumber = textBox10.Text;
            m_PublicInformation.stockNumber = textBox7.Text;
            m_PublicInformation.clientCode = textBox11.Text;
            m_PublicInformation.preparationOfInvoiceNumber = textBox8.Text;
            m_PublicInformation.WithTheNumberOfWorkers = textBox12.Text;

            m_PublicInformation.surfaceOfA = textBox25.Text;
            m_PublicInformation.surfaceOfB = textBox24.Text;
            m_PublicInformation.surfaceOfCOne = textBox26.Text;
            m_PublicInformation.surfaceOfCTow = textBox27.Text;

            m_PublicInformation.LD_Focal = textBox23.Text;
            m_PublicInformation.weldingMethod = textBox22.Text;
            m_PublicInformation.endFaceQuality = textBox20.Text;
            m_PublicInformation.cycleIndex = textBox15.Text;

            m_PublicInformation.powerBeforeWeldingOne = textBox31.Text;
            m_PublicInformation.powerBeforeWeldingTow = textBox34.Text;
            m_PublicInformation.powerBeforeWeldedOne = textBox32.Text;
            m_PublicInformation.powerBeforeWeledTow = textBox33.Text;
            m_PublicInformation.fiberPower = textBox35.Text;
            m_PublicInformation.photocurrentOne = textBox30.Text;
            m_PublicInformation.photocurrentTow = textBox28.Text;
            m_PublicInformation.testPowerOne = textBox39.Text;
            m_PublicInformation.testPowerTow = textBox37.Text;
            m_PublicInformation.LD_Kink = textBox38.Text;
            m_PublicInformation.PD_Kink = textBox29.Text;
            m_PublicInformation.testConditionOne = textBox43.Text;
            m_PublicInformation.testConditionTow = textBox41.Text;
            m_PublicInformation.sensitivityOne = textBox42.Text;
            m_PublicInformation.sensitivityTow = textBox40.Text;
            m_PublicInformation.ICCOne = textBox44.Text;
            m_PublicInformation.ICCTow = textBox36.Text;

            m_PublicInformation.photoelectricityIf = textBox46.Text;
            m_PublicInformation.factoryPowerOne = textBox48.Text;
            m_PublicInformation.factoryPowerTow = textBox47.Text;
            m_PublicInformation.photoelectricityImoOne = textBox50.Text;
            m_PublicInformation.photoelectricityImoTow = textBox49.Text;
            m_PublicInformation.photoelectricityIthOne = textBox52.Text;
            m_PublicInformation.photoelectricityIthTow = textBox51.Text;
            m_PublicInformation.photoelectricityVfOne = textBox54.Text;
            m_PublicInformation.photoelectricityVfTow = textBox53.Text;
            m_PublicInformation.photoelectricityPTOne = textBox56.Text;
            m_PublicInformation.photoelectricityVbrOne = textBox58.Text;
            m_PublicInformation.photoelectricityVbrTow = textBox7.Text;

            m_PublicInformation.testTemperatureOne = textBox60.Text;
            m_PublicInformation.testTemperatureTow = textBox6.Text;
            m_PublicInformation.assemblyDirection = textBox59.Text;
            m_PublicInformation.PTHeight = textBox45.Text;
            m_PublicInformation.peripheralGlue = textBox19.Text;
            m_PublicInformation.LD_Type = textBox17.Text;
            m_PublicInformation.PT_Type = textBox14.Text;
            m_PublicInformation.deviceTag = comboBox3.SelectedItem.ToString();
            m_PublicInformation.beforeWelding = textBox13.Text;
            m_PublicInformation.postwelding = textBox62.Text;
            m_PublicInformation.theTest = textBox55.Text;

            m_PublicInformation.authorized = textBox16.Text;
            m_PublicInformation.technologyAuditing = textBox18.Text;
            m_PublicInformation.manufactureAuditing = textBox21.Text;

            m_PublicInformation.dataEntryStaff = label21.Text;
            m_PublicInformation.dataEntryStaffTime = label88.Text;

            m_PublicInformation.theProductName = textBox61.Text;
            m_PublicInformation.theDescription = textBox63.Text;
            m_PublicInformation.theMatterCode = textBox65.Text;
            m_PublicInformation.theModelAttributes = textBox64.Text;
            m_PublicInformation.theSpecification = textBox66.Text;
            m_PublicInformation.theCustomerType = textBox70.Text;
            m_PublicInformation.theStockNumber = textBox68.Text;
            m_PublicInformation.theContractNumber = textBox69.Text;
            m_PublicInformation.theLD_Type = textBox67.Text;
            m_PublicInformation.thePT_Type = textBox74.Text;
            m_PublicInformation.theDateOfManufacture = textBox72.Text;
            m_PublicInformation.theQuantityOne = textBox73.Text;
            m_PublicInformation.theQuantityTow = textBox71.Text;
            m_PublicInformation.theNumber = textBox75.Text;
            return m_PublicInformation;
        }
        public void SetM_PublicInformation()
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            M_Specifications m_Specifications = b_GetMethod.GetM_Specifications(comboBox1.SelectedItem.ToString());
            M_SpecificationsPaddingDataToControl(m_Specifications);
        }



        private void M_SpecificInformationPaddingDataToControl(M_SpecificInformation m_SpecificInformation)
        {
            
            if (m_SpecificInformation != null)
            {
                highlighter2.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Green;
                highlighter2.SetHighlightOnFocus(textBoxX1, true);
                textBox1.Text = m_SpecificInformation.contractNumber;
                textBox3.Text = m_SpecificInformation.tbleNumber;
                dateTimePicker1.Value = m_SpecificInformation.deliveryDate;
                dateTimePicker2.Value = m_SpecificInformation.orderDate;
                label21.Text += m_SpecificInformation.dataEntryStaffFirstText.ToString();
                label88.Text = "录入时间："+m_SpecificInformation.uploadTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                textBox1.Text ="";
                textBox3.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                label21.Text ="录入员：" ;
                label88.Text += "录入时间：";
            }
        }
        private void M_SpecificationsPaddingDataToControl(M_Specifications m_Specifications)
        {
            textBox5.Text = m_Specifications.productModel;
            textBox9.Text = m_Specifications.productCode;
            textBox11.Text = m_Specifications.clientCode;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox61.Text = comboBox2.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox69.Text = textBox1.Text;
        }
    }
}
