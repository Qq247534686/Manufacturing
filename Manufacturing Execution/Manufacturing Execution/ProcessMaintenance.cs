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
    public partial class ProcessMaintenance : MetroAppForm
    {
        public ProcessMaintenance()
        {
            InitializeComponent();
        }
        B_GetMethod b_GetMethod = new B_GetMethod();
        private void ProcessMaintenance_Load(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Gray;
            textBox4.BackColor = Color.Gray;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "维护失败:请检查工单或产品代码是否存在！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            M_ProcessMaintenance m_ProcessMaintenance = new M_ProcessMaintenance();
            m_ProcessMaintenance.productID = textBox1.Text;
            m_ProcessMaintenance.inputPersonnel = textBox2.Text;
            m_ProcessMaintenance.workOrder = textBox3.Text;
            m_ProcessMaintenance.productCode = textBox4.Text;
            m_ProcessMaintenance.theProcess = comboBox1.SelectedItem.ToString();
            m_ProcessMaintenance.productionProcesses = comboBox2.SelectedItem.ToString();
            string returnInfo = b_GetMethod.SaveOrUpdateM_ProcessMaintenance(m_ProcessMaintenance) == true ? "维护成功" : "维护失败";
            string img=returnInfo=="维护成功"?@"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            M_ProcessMaintenance m_ProcessMaintenance=b_GetMethod.GetM_ProcessMaintenance(textBox1.Text);
            if (m_ProcessMaintenance == null)
            {
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                return;
            }
            else
            {
                textBox3.Text = m_ProcessMaintenance.workOrder;
                textBox4.Text = m_ProcessMaintenance.productCode;
            }
        }
    }
}
