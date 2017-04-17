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
    public partial class Specifications : MetroAppForm
    {
        public Specifications()
        {
            InitializeComponent();
        }
        BLL.B_GetMethod b_GetMethod = new BLL.B_GetMethod();
        private void Specifications_Load(object sender, EventArgs e)
        {
            timer1.Start();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
        }

       

       
        /// <summary>
        /// 修改规格书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           if (!AlertInfo())
            {
                return;
            }
                M_Specifications m_Specifications = GetM_Specifications();
                string returnStr = b_GetMethod.HandleSpecifications(m_Specifications, M_SQLType.Update);
                if (returnStr.Equals("修改规格书成功"))
                {
                    ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                    ToastNotification.Show(this, returnStr, BLL.B_GetMethod.ReadImageFile(@"../../Images/success.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
                else
                {
                    ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                    ToastNotification.Show(this, returnStr, BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                }
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        private bool AlertInfo()
        {
            bool falg = true;
            if ((string.IsNullOrEmpty(txtSpecificationsName.Text) || string.IsNullOrEmpty(txtClientCode.Text) || (string.IsNullOrEmpty(txtProductModel.Text) || string.IsNullOrEmpty(txtProductCode.Text))))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "规格书,客户代码,产品型号,成品代码为必填字段!!!", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                falg = false;
                return falg;
            }
            return falg;
        }
        /// <summary>
        /// 上传规格书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (!AlertInfo())
            {
                return;
            }
            M_Specifications m_Specifications = GetM_Specifications();
            TaskDialogInfo info = new TaskDialogInfo("提示", eTaskDialogIcon.ShieldHelp, "是否确定上传规格书!!!", "", GetTaskDialogButtons());
            string returnStr = TaskDialog.Show(info).ToString();
            if (returnStr.Equals("Yes"))
            {
                string str = string.Empty; string img = string.Empty;
                str=b_GetMethod.HandleSpecifications(m_Specifications, M_SQLType.Insert);
                if (str.Equals("上传规格书成功"))
                {
                    img = @"../../Images/success.png";
                }
                else
                {
                    img = @"../../Images/Error.png";
                }
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, str, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        private eTaskDialogButton GetTaskDialogButtons()
        {
            eTaskDialogButton button = eTaskDialogButton.Ok;
                button |= eTaskDialogButton.Yes;
                button |= eTaskDialogButton.No;

            if ( button != eTaskDialogButton.Ok)
                button = button & ~(button & eTaskDialogButton.Ok);
            return button;
        }
        /// <summary>
        /// 退出规格书编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 文件查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            SpecificationsQuery specificationsQueryForm = new SpecificationsQuery(this);
            specificationsQueryForm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox8.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 设定规格书测试
        /// </summary>
        /// <param name="keyword"></param>
        public void SetSpecificationsParameter(string keyword)
        {
            M_Specifications m_Specifications = b_GetMethod.GetM_Specifications(keyword);
            txtSpecificationsName.Text=m_Specifications.specificationsName;
            txtClientCode.Text=m_Specifications.clientCode;
            txtProductModel.Text=m_Specifications.productModel;
            txtProductCode.Text=m_Specifications.productCode;
            textBox6.Text=m_Specifications.LD_If;
            comboBox1.SelectedIndex=m_Specifications.LD_Method;
            textBox5.Text=m_Specifications.LD_Po;
            comboBox2.SelectedIndex=m_Specifications.LD_Wavelength;

            comboBox3.SelectedIndex=m_Specifications.temperature;
            textBox7.Text=m_Specifications.temperatureText;

            comboBox4.SelectedIndex=m_Specifications.PT_Method;
            comboBox5.SelectedIndex=m_Specifications.PT_apt;
            comboBox6.SelectedIndex=m_Specifications.PT_code;
            textBox9.Text=m_Specifications.PT_time;
            textBox10.Text=m_Specifications.PT_Sem;
            comboBox7.SelectedIndex=m_Specifications.PT_error;
            comboBox8.SelectedIndex=m_Specifications.PT_speed;
            comboBox9.SelectedIndex=m_Specifications.PT_Wavelength;
            comboBox10.SelectedIndex=m_Specifications.PT_APDV;

            textBox12.Text=m_Specifications.pomin;
            textBox14.Text=m_Specifications.pominText;
            textBox13.Text=m_Specifications.ithmin;
            textBox18.Text=m_Specifications.vfmin;
            textBox19.Text=m_Specifications.imomin;
            textBox15.Text=m_Specifications.imominText;
            textBox20.Text=m_Specifications.esmin;
            textBox16.Text=m_Specifications.esminText;
            textBox21.Text=m_Specifications.rsmin;
            textBox22.Text=m_Specifications.pkinkmin;
            textBox23.Text=m_Specifications.kimomin;
            textBox24.Text=m_Specifications.cmmin;
            textBox25.Text=m_Specifications.themin;
            textBox26.Text=m_Specifications.sRMSmin;
            textBox27.Text=m_Specifications.tEmin;
            textBox28.Text=m_Specifications.imoKinkmin;
            textBox29.Text=m_Specifications.idarkmin;
            textBox30.Text=m_Specifications.ifmin;
            textBox31.Text=m_Specifications.handlePomin;
            textBox17.Text=m_Specifications.handlePominText;
            textBox32.Text=m_Specifications.parallelmin;

            textBox60.Text=m_Specifications.pomax;
            textBox43.Text=m_Specifications.pomaxText;
            textBox59.Text=m_Specifications.ithmax;
            textBox58.Text=m_Specifications.vfmax;
            textBox57.Text=m_Specifications.imomax;
            textBox42.Text=m_Specifications.imomaxText;
            textBox56.Text=m_Specifications.esmax;
            textBox34.Text=m_Specifications.esmaxText;
            textBox55.Text=m_Specifications.rsmax;
            textBox54.Text=m_Specifications.pkinkmax;
            textBox53.Text=m_Specifications.kimomax;
            textBox52.Text=m_Specifications.cmmax;
            textBox51.Text=m_Specifications.themax;
            textBox50.Text=m_Specifications.sRMSmax;
            textBox49.Text=m_Specifications.tEmax;
            textBox48.Text=m_Specifications.imoKinkmax;
            textBox47.Text=m_Specifications.idarkmax;
            textBox46.Text=m_Specifications.ifmax;
            textBox45.Text=m_Specifications.handlePomax;
            textBox33.Text=m_Specifications.handlePomaxText;
            textBox44.Text=m_Specifications.parallelmax;

            textBox66.Text=m_Specifications.vbrmin;
            textBox65.Text=m_Specifications.iopmin;
            textBox73.Text=m_Specifications.iopminText;
            textBox64.Text=m_Specifications.iomin;
            textBox74.Text=m_Specifications.iominText;
            textBox63.Text=m_Specifications.idpmin;
            textBox62.Text=m_Specifications.iccmin;
            textBox61.Text=m_Specifications.senmin;

            textBox72.Text=m_Specifications.vbrmax;
            textBox71.Text=m_Specifications.iopmax;
            textBox70.Text=m_Specifications.iomax;
            textBox69.Text=m_Specifications.idpmax;
            textBox68.Text=m_Specifications.iccmax;
            textBox67.Text=m_Specifications.senmax;
            textBox75.Text=m_Specifications.senmaxText;

            textBox76.Text=m_Specifications.remarks;
        }
        /// <summary>
        /// 规格书参数转对象
        /// </summary>
        /// <returns></returns>
        private M_Specifications GetM_Specifications()
        {
            M_Specifications m_Specifications = new M_Specifications();
            m_Specifications.specificationsName = txtSpecificationsName.Text;
            m_Specifications.clientCode = txtClientCode.Text;
            m_Specifications.productModel = txtProductModel.Text;
            m_Specifications.productCode = txtProductCode.Text;

            m_Specifications.LD_Method = comboBox1.SelectedIndex;
            m_Specifications.LD_Po = textBox5.Text;
            m_Specifications.LD_Wavelength = comboBox2.SelectedIndex;
            m_Specifications.LD_If = textBox6.Text;

            m_Specifications.temperature = comboBox3.SelectedIndex;
            m_Specifications.temperatureText = textBox7.Text;

            m_Specifications.PT_Method = comboBox4.SelectedIndex;
            m_Specifications.PT_apt = comboBox5.SelectedIndex;
            m_Specifications.PT_code = comboBox6.SelectedIndex;
            m_Specifications.PT_time = textBox9.Text;
            m_Specifications.PT_Sem = textBox10.Text;
            m_Specifications.PT_error = comboBox7.SelectedIndex;
            m_Specifications.PT_speed = comboBox8.SelectedIndex;
            m_Specifications.PT_Wavelength = comboBox9.SelectedIndex;
            m_Specifications.PT_APDV = comboBox10.SelectedIndex;

            m_Specifications.pomin = textBox12.Text;
            m_Specifications.pominText = textBox14.Text;
            m_Specifications.ithmin = textBox13.Text;
            m_Specifications.vfmin = textBox18.Text;
            m_Specifications.imomin = textBox19.Text;
            m_Specifications.imominText = textBox15.Text;
            m_Specifications.esmin = textBox20.Text;
            m_Specifications.esminText = textBox16.Text;
            m_Specifications.rsmin = textBox21.Text;
            m_Specifications.pkinkmin = textBox22.Text;
            m_Specifications.kimomin = textBox23.Text;
            m_Specifications.cmmin = textBox24.Text;
            m_Specifications.themin = textBox25.Text;
            m_Specifications.sRMSmin = textBox26.Text;
            m_Specifications.tEmin = textBox27.Text;
            m_Specifications.imoKinkmin = textBox28.Text;
            m_Specifications.idarkmin = textBox29.Text;
            m_Specifications.ifmin = textBox30.Text;
            m_Specifications.handlePomin = textBox31.Text;
            m_Specifications.handlePominText = textBox17.Text;
            m_Specifications.parallelmin = textBox32.Text;

            m_Specifications.pomax = textBox60.Text;
            m_Specifications.pomaxText = textBox43.Text;
            m_Specifications.ithmax = textBox59.Text;
            m_Specifications.vfmax = textBox58.Text;
            m_Specifications.imomax = textBox57.Text;
            m_Specifications.imomaxText = textBox42.Text;
            m_Specifications.esmax = textBox56.Text;
            m_Specifications.esmaxText = textBox34.Text;
            m_Specifications.rsmax = textBox55.Text;
            m_Specifications.pkinkmax = textBox54.Text;
            m_Specifications.kimomax = textBox53.Text;
            m_Specifications.cmmax = textBox52.Text;
            m_Specifications.themax = textBox51.Text;
            m_Specifications.sRMSmax = textBox50.Text;
            m_Specifications.tEmax = textBox49.Text;
            m_Specifications.imoKinkmax = textBox49.Text;
            m_Specifications.idarkmax = textBox47.Text;
            m_Specifications.ifmax = textBox46.Text;
            m_Specifications.handlePomax = textBox45.Text;
            m_Specifications.handlePomaxText = textBox33.Text;
            m_Specifications.parallelmax = textBox44.Text;

            m_Specifications.vbrmin = textBox66.Text;
            m_Specifications.iopmin = textBox65.Text;
            m_Specifications.iopminText = textBox73.Text;
            m_Specifications.iomin = textBox64.Text;
            m_Specifications.iominText = textBox74.Text;
            m_Specifications.idpmin = textBox63.Text;
            m_Specifications.iccmin = textBox62.Text;
            m_Specifications.senmin = textBox61.Text;

            m_Specifications.vbrmax = textBox72.Text;
            m_Specifications.iopmax = textBox71.Text;
            m_Specifications.iomax = textBox70.Text;
            m_Specifications.idpmax = textBox69.Text;
            m_Specifications.iccmax = textBox68.Text;
            m_Specifications.senmax = textBox67.Text;
            m_Specifications.senmaxText = textBox75.Text;

            m_Specifications.remarks = textBox76.Text;
            m_Specifications.createTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_Specifications.joinID = -1;
            return m_Specifications;
        }
    }
}
