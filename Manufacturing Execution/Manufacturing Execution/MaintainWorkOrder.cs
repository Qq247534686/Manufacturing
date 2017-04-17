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
    public partial class MaintainWorkOrder : MetroAppForm
    {
        public MaintainWorkOrder()
        {
            InitializeComponent();
        }
        B_GetMethod b_GetMethod = new B_GetMethod();
        private void MaintainWorkOrder_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1 .Enabled= checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox5.ReadOnly = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox2.Checked;
            if (!checkBox2.Checked)
            {
                numericUpDown1.Value = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox3.Checked;
            if (!checkBox1.Checked)
            {
                textBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "产品，工单，产品序列号不能为空", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                 return;
            }
            M_MaintainWorkOrder m_MaintainWorkOrder = new M_MaintainWorkOrder();
            m_MaintainWorkOrder.settingInformation = checkBox1.Checked ? 1 : 0;
            m_MaintainWorkOrder.productSerialNumberLength = checkBox2.Checked ==true? 1 : 0;
            m_MaintainWorkOrder.productSerialNumberprefix = checkBox3.Checked == true ? 1 : 0;
            m_MaintainWorkOrder.settingInformationText = textBox1.Text;
            m_MaintainWorkOrder.productSerialNumberText = (int)numericUpDown1.Value;
            m_MaintainWorkOrder.productSerialNumberprefixText = textBox3.Text;
            m_MaintainWorkOrder.productName = textBox4.Text;
            m_MaintainWorkOrder.workOrder = textBox5.Text;
            m_MaintainWorkOrder.isAcceptableQualityLevel = radioButton1.Checked==true ? 1 : 0;
            m_MaintainWorkOrder.serialNumber = textBox6.Text;
            string returnInfo = b_GetMethod.MaintainWorkOrder(m_MaintainWorkOrder, M_SQLType.Insert);
            GetTable();
            string img = returnInfo.Equals("添加成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);

        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable("[T_MaintainWorkOrder]", "[id],[productName] as 产品,[workOrder] as 工单,[serialNumber] as 产品序列号");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["产品"].ReadOnly = true;
            dataGridView1.Columns["工单"].ReadOnly = true;
            dataGridView1.Columns["产品序列号"].ReadOnly = true;
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns["id"].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
            textBox5.Text= textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int length = (int)numericUpDown1.Value;
            if (length != 0 && numericUpDown1.Enabled)
            {
                textBox6.MaxLength = length;
            }
            else
            {
                textBox6.MaxLength = 100;
            }
        }

     
    }
}
