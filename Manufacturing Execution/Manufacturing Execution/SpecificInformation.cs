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
    public partial class SpecificInformation : MetroAppForm
    {
        public SpecificInformation()
        {
            InitializeComponent();
        }
        B_GetMethod b_GetMethod = new B_GetMethod();
        private void SpecificInformation_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox7.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBox1.Enabled = false;

                textBox2.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!AlertInfo())
            {
                return;
            }
            M_SpecificInformation m_SpecificInformation = GetM_SpecificInformation();
            string returnInfo = b_GetMethod.HandleSpecificInformation(m_SpecificInformation, M_SQLType.Insert);
            string img = string.Empty;
            if (returnInfo.Equals("随工单【" + m_SpecificInformation.workOrderNumberOne + m_SpecificInformation.workOrderNumberTow + "】上传成功"))
            {
                img = @"../../Images/success.png";
            }
            else
            {
                img = @"../../Images/Error.png";
            }
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);

        }

        private bool AlertInfo()
        {
            bool falg = true;
            if ((string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox1.Text) || (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox7.Text))))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "随工单序号,合同书编号,规格书编号,表格编号为必填字段!!!", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                falg = false;
                return falg;
            }
            return falg;
        }

        private M_SpecificInformation GetM_SpecificInformation()
        {
            M_SpecificInformation m_SpecificInformation = new M_SpecificInformation();
            m_SpecificInformation.workOrderNumberOne = textBox3.Text;
            m_SpecificInformation.workOrderNumberTow = textBox4.Text;
            m_SpecificInformation.deliveryDate = dateTimePicker1.Value;
            m_SpecificInformation.orderDate = dateTimePicker2.Value;
            m_SpecificInformation.contractNumber = textBox1.Text;
            m_SpecificInformation.specificationNumber = textBox2.Text;
            m_SpecificInformation.tbleNumber = textBox7.Text;

            m_SpecificInformation.LD_One = textBox22.Text;
            m_SpecificInformation.LD_Tow = textBox16.Text;
            m_SpecificInformation.LD_Three = textBox15.Text;

            m_SpecificInformation.PT_One = textBox19.Text;
            m_SpecificInformation.PT_Tow = textBox14.Text;
            m_SpecificInformation.PT_Three = textBox13.Text;

            m_SpecificInformation.monoblockOne = textBox21.Text;
            m_SpecificInformation.monoblockTow = textBox12.Text;
            m_SpecificInformation.monoblockThree = textBox11.Text;

            m_SpecificInformation.zeroFilterChipOne = textBox18.Text;
            m_SpecificInformation.zeroFilterChipTow = textBox34.Text;
            m_SpecificInformation.zeroFilterChipThree = textBox33.Text;

            m_SpecificInformation.fortyFiveFilterChipOne = textBox20.Text;
            m_SpecificInformation.fortyFiveFilterChipTow = textBox10.Text;
            m_SpecificInformation.fortyFiveFilterChipThree = textBox9.Text;

            m_SpecificInformation.interfaceModuleOne = textBox17.Text;
            m_SpecificInformation.interfaceModuleTow = textBox32.Text;
            m_SpecificInformation.interfaceModuleThree = textBox31.Text;

            m_SpecificInformation.equipmentNumberOne = textBox78.Text;
            m_SpecificInformation.equipmentNumberTow = textBox77.Text;
            m_SpecificInformation.equipmentNumberThree = textBox76.Text;
            m_SpecificInformation.equipmentNumberFour = textBox75.Text;
            m_SpecificInformation.uploadQuantity = int.Parse(textBox74.Text);
            m_SpecificInformation.uploadTime = string.IsNullOrEmpty(textBox73.Text) ? DateTime.Now : DateTime.Parse(textBox73.Text);
            m_SpecificInformation.unqualifiedQuantity = int.Parse(textBox72.Text);
            m_SpecificInformation.consoleOneFirstText = int.Parse(textBox71.Text);
            m_SpecificInformation.consoleOneLastText = textBox70.Text;
            m_SpecificInformation.consoleTowFirstText = int.Parse(textBox69.Text);
            m_SpecificInformation.consoleTowLastText = textBox68.Text;
            m_SpecificInformation.consoleThreeFirstText = int.Parse(textBox67.Text);
            m_SpecificInformation.consoleThreeLastText = textBox66.Text;
            m_SpecificInformation.consoleFourFirstText = int.Parse(textBox65.Text);
            m_SpecificInformation.consoleFourLastText = textBox64.Text;
            m_SpecificInformation.dataEntryStaffFirstText = int.Parse(textBox63.Text);
            m_SpecificInformation.dataEntryStaffLastText = textBox62.Text;

            m_SpecificInformation.filterChipError = int.Parse(textBox61.Text);
            m_SpecificInformation.weldError = int.Parse(textBox55.Text);
            m_SpecificInformation.LDError = int.Parse(textBox60.Text);
            m_SpecificInformation.exceed = int.Parse(textBox38.Text);
            m_SpecificInformation.pressure = int.Parse(textBox59.Text);
            m_SpecificInformation.LD_Threshold = int.Parse(textBox37.Text);
            m_SpecificInformation.markingError = int.Parse(textBox58.Text);
            m_SpecificInformation.monoblockError = int.Parse(textBox57.Text);
            m_SpecificInformation.slugError = int.Parse(textBox56.Text);
            m_SpecificInformation.theOther = textBox36.Text;
            m_SpecificInformation.theQuantity = int.Parse(textBox35.Text);

            m_SpecificInformation.serialNumberOne = textBox23.Text;
            m_SpecificInformation.serialNumberTow = textBox24.Text;
            m_SpecificInformation.serialNumberThree = textBox25.Text;
            m_SpecificInformation.CASE_One = textBox28.Text;
            m_SpecificInformation.CASE_Tow = textBox27.Text;
            m_SpecificInformation.CASE_Three = textBox26.Text;
            m_SpecificInformation.LD_AddOne = textBox39.Text;
            m_SpecificInformation.LD_AddTow = textBox30.Text;
            m_SpecificInformation.LD_AddThree = textBox29.Text;
            m_SpecificInformation.LD_AddFour = textBox42.Text;
            m_SpecificInformation.LD_AddFive = textBox41.Text;
            m_SpecificInformation.LD_AddSix = textBox40.Text;
            m_SpecificInformation.LD_MinusOne = textBox51.Text;
            m_SpecificInformation.LD_MinusTow = textBox50.Text;
            m_SpecificInformation.LD_MinusThree = textBox49.Text;
            m_SpecificInformation.rangeOne = textBox48.Text;
            m_SpecificInformation.rangeTow = textBox47.Text;
            m_SpecificInformation.rangeThree = textBox46.Text;
            m_SpecificInformation.concaveCnvexOne = textBox45.Text;
            m_SpecificInformation.concaveCnvexTow = textBox44.Text;
            m_SpecificInformation.concaveCnvexThree = textBox43.Text;
            m_SpecificInformation.slugFocal = textBox54.Text;
            m_SpecificInformation.inspectionPersonal = textBox53.Text;
            m_SpecificInformation.checker = textBox52.Text;
            m_SpecificInformation.remarks = textBox8.Text;
            m_SpecificInformation.createTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return m_SpecificInformation;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox73.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            M_SpecificInformation m_SpecificInformation=GetM_SpecificInformation();
            string returnInfo = b_GetMethod.HandleSpecificInformation(m_SpecificInformation, M_SQLType.Update);
            string img = string.Empty;
            if (returnInfo.Equals("修改随工单成功"))
            {
                img = @"../../Images/success.png";
            }
            else
            {
                img = @"../../Images/Error.png";
            }
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SpecificInformationQuery specificInformationQuery = new SpecificInformationQuery(this);
            specificInformationQuery.ShowDialog();
        }

        public void SetSpecificInformationParameter(string keyword)
        {
            M_SpecificInformation m_SpecificInformation = b_GetMethod.GetM_SpecificInformation(keyword);
            if (m_SpecificInformation == null)
            {
                return;
            }
            textBox3.Text=m_SpecificInformation.workOrderNumberOne;
            textBox4.Text=m_SpecificInformation.workOrderNumberTow;
            dateTimePicker1.Value=m_SpecificInformation.deliveryDate;
            dateTimePicker2.Value=m_SpecificInformation.orderDate;
            textBox1.Text=m_SpecificInformation.contractNumber;
            textBox2.Text=m_SpecificInformation.specificationNumber;
            textBox7.Text=m_SpecificInformation.tbleNumber;

            textBox22.Text=m_SpecificInformation.LD_One;
            textBox16.Text=m_SpecificInformation.LD_Tow;
            textBox15.Text=m_SpecificInformation.LD_Three;

            textBox19.Text=m_SpecificInformation.PT_One;
            textBox14.Text=m_SpecificInformation.PT_Tow;
            textBox13.Text=m_SpecificInformation.PT_Three;

            textBox21.Text=m_SpecificInformation.monoblockOne;
            textBox12.Text=m_SpecificInformation.monoblockTow;
            textBox11.Text=m_SpecificInformation.monoblockThree;

            textBox18.Text=m_SpecificInformation.zeroFilterChipOne;
            textBox34.Text=m_SpecificInformation.zeroFilterChipTow;
            textBox33.Text=m_SpecificInformation.zeroFilterChipThree;

            textBox20.Text=m_SpecificInformation.fortyFiveFilterChipOne;
            textBox10.Text=m_SpecificInformation.fortyFiveFilterChipTow;
            textBox9.Text=m_SpecificInformation.fortyFiveFilterChipThree;

            textBox17.Text=m_SpecificInformation.interfaceModuleOne;
            textBox32.Text=m_SpecificInformation.interfaceModuleTow;
            textBox31.Text=m_SpecificInformation.interfaceModuleThree;

            textBox78.Text=m_SpecificInformation.equipmentNumberOne;
            textBox77.Text=m_SpecificInformation.equipmentNumberTow;
            textBox76.Text=m_SpecificInformation.equipmentNumberThree;
            textBox75.Text=m_SpecificInformation.equipmentNumberFour;

            textBox74.Text = m_SpecificInformation.uploadQuantity.ToString();
            textBox73.Text=m_SpecificInformation.uploadTime.ToString();
            textBox72.Text = m_SpecificInformation.unqualifiedQuantity.ToString();
            textBox71.Text = m_SpecificInformation.consoleOneFirstText.ToString();
            textBox70.Text=m_SpecificInformation.consoleOneLastText;
            textBox69.Text = m_SpecificInformation.consoleTowFirstText.ToString();
            textBox68.Text=m_SpecificInformation.consoleTowLastText;
            textBox67.Text = m_SpecificInformation.consoleThreeFirstText.ToString();
            textBox66.Text=m_SpecificInformation.consoleThreeLastText;
            textBox65.Text = m_SpecificInformation.consoleFourFirstText.ToString();
            textBox64.Text=m_SpecificInformation.consoleFourLastText;
            textBox63.Text = m_SpecificInformation.dataEntryStaffFirstText.ToString();
            textBox62.Text=m_SpecificInformation.dataEntryStaffLastText;

            textBox61.Text = m_SpecificInformation.filterChipError.ToString();
            textBox55.Text = m_SpecificInformation.weldError.ToString();
            textBox60.Text = m_SpecificInformation.LDError.ToString();
            textBox38.Text = m_SpecificInformation.exceed.ToString();
            textBox59.Text = m_SpecificInformation.pressure.ToString();
            textBox37.Text = m_SpecificInformation.LD_Threshold.ToString();
            textBox58.Text = m_SpecificInformation.markingError.ToString();
            textBox57.Text = m_SpecificInformation.monoblockError.ToString();
            textBox56.Text = m_SpecificInformation.slugError.ToString();
            textBox36.Text=m_SpecificInformation.theOther;
            textBox35.Text = m_SpecificInformation.theQuantity.ToString();

            textBox23.Text=m_SpecificInformation.serialNumberOne;
            textBox24.Text=m_SpecificInformation.serialNumberTow;
            textBox25.Text=m_SpecificInformation.serialNumberThree;
            textBox28.Text=m_SpecificInformation.CASE_One;
            textBox27.Text=m_SpecificInformation.CASE_Tow;
            textBox26.Text=m_SpecificInformation.CASE_Three;
            textBox39.Text=m_SpecificInformation.LD_AddOne;
            textBox30.Text=m_SpecificInformation.LD_AddTow;
            textBox29.Text=m_SpecificInformation.LD_AddThree;
            textBox42.Text=m_SpecificInformation.LD_AddFour;
            textBox41.Text=m_SpecificInformation.LD_AddFive;
            textBox40.Text=m_SpecificInformation.LD_AddSix;
            textBox51.Text=m_SpecificInformation.LD_MinusOne;
            textBox50.Text=m_SpecificInformation.LD_MinusTow;
            textBox49.Text=m_SpecificInformation.LD_MinusThree;
            textBox48.Text=m_SpecificInformation.rangeOne;
            textBox47.Text=m_SpecificInformation.rangeTow;
            textBox46.Text=m_SpecificInformation.rangeThree;
            textBox45.Text=m_SpecificInformation.concaveCnvexOne;
            textBox44.Text=m_SpecificInformation.concaveCnvexTow;
            textBox43.Text=m_SpecificInformation.concaveCnvexThree;
            textBox54.Text=m_SpecificInformation.slugFocal;
            textBox53.Text=m_SpecificInformation.inspectionPersonal;
            textBox52.Text=m_SpecificInformation.checker;
            textBox8.Text=m_SpecificInformation.remarks;
        }
    }
}
