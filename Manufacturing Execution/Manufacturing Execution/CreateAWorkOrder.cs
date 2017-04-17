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
using Model;
using DevComponents.DotNetBar;
using System.Security.Cryptography;

namespace Manufacturing_Execution
{
    public partial class CreateAWorkOrder : MetroAppForm
    {
        public CreateAWorkOrder()
        {
            InitializeComponent();
        }
        BLL.B_GetMethod b_GetMethod = new BLL.B_GetMethod();
        private void CreateAWorkOrder_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex=0;
            comboBox2.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            GetTable();
            comboBox5.DataSource = b_GetMethod.GetList("T_ImportPlan", "orderNumber","");
            if (comboBox5.Items.Count<=0) return;
            List<string> comData = new List<string>();
            comData = b_GetMethod.GetListProductNumber(comboBox5.SelectedItem.ToString());
            comboBox12.DataSource = comData == null ? new List<string>() : comData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M_CreateAWorkOrder m_CreateAWorkOrder = new M_CreateAWorkOrder();
            m_CreateAWorkOrder.shopCode = comboBox1.SelectedItem.ToString();
            m_CreateAWorkOrder.currentOperation = textBox3.Text;
            m_CreateAWorkOrder.singleType = comboBox2.SelectedItem.ToString();
            m_CreateAWorkOrder.totalProduction = textBox6.Text;
            m_CreateAWorkOrder.orderNumber = comboBox5.SelectedItem.ToString();
            m_CreateAWorkOrder.manufacturingProcess = comboBox8.SelectedItem.ToString();
            m_CreateAWorkOrder.customerName = textBox1.Text;
            m_CreateAWorkOrder.poductCode = comboBox12.SelectedItem.ToString();
            m_CreateAWorkOrder.orderMD5Number = GetMD5(DateTime.Now.ToString());
            m_CreateAWorkOrder.createTime = DateTime.Now;
            string returnInfo = b_GetMethod.CreateWorkOrder(m_CreateAWorkOrder, M_SQLType.Insert);
            GetTable();
            string img = returnInfo.Equals("添加成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);



        }
        public  string GetMD5(string myString)
        {
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            //byte[] targetData = md5.ComputeHash(fromData);
            //string byte2String = null;

            //for (int i = 0; i < targetData.Length; i++)
            //{
            //    byte2String += targetData[i].ToString("x");
            //}
            //return byte2String;
            string str=DateTime.Now.ToString("yyyyMMddHHmmss")+new Random().Next(1, 1000).ToString();
            return str;
        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable("[T_CerateWorkOrder]", "[id],[orderMD5Number] as 工单编号,[singleType] as 工单类型,[shopCode] as 车间编码,[currentOperation] as 当前操作,[totalProduction] as 投产总数,[orderNumber] as 订单编号,[manufacturingProcess] as 制造工艺,[poductCode] as 产品编码,[customerName] as 客户编码,[isConfirm] as 是否确认,[createTime] as 创建日期");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["工单编号"].ReadOnly = true;
            dataGridView1.Columns["工单类型"].ReadOnly = true;
            dataGridView1.Columns["车间编码"].ReadOnly = true;
            dataGridView1.Columns["当前操作"].ReadOnly = true;
            dataGridView1.Columns["投产总数"].ReadOnly = true;
            dataGridView1.Columns["订单编号"].ReadOnly = true;
            dataGridView1.Columns["制造工艺"].ReadOnly = true;
            dataGridView1.Columns["产品编码"].ReadOnly = true;
            dataGridView1.Columns["客户编码"].ReadOnly = true;
            dataGridView1.Columns["创建日期"].ReadOnly = true;
            dataGridView1.Columns["是否确认"].ReadOnly = true;
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns["id"].Visible = false;
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> comData = new List<string>();
            comData =b_GetMethod.GetListProductNumber(comboBox5.SelectedItem.ToString());
            comboBox12.DataSource = comData == null ? new List<string>() : comData;
            GetKeFu();
        }
        private void GetKeFu()
        {
            string str1 = comboBox5.SelectedItem.ToString();
            string str2 = comboBox12.SelectedItem.ToString();
            List<string> list=new List<string>();
            list=b_GetMethod.GetKeFu("select top 1 [client],[productNumber] from T_ImportPlan where orderNumber='"+str1+"' and productName=(select top 1 b.[productName] from T_JoinT_ImportPlan as b  where b.[productNumber]='"+str2+"')");
            if (list.Count <= 0) return;
            textBox1.Text = list[0].ToString();
            textBox6.Text = list[1].ToString();
            
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetKeFu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            M_CreateAWorkOrder m_CreateAWorkOrder = new M_CreateAWorkOrder();
            int count = Convert.ToInt16(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行
                {
                    m_CreateAWorkOrder.id += dataGridView1.Rows[i].Cells["id"].Value.ToString() + ",";
                }
                else
                {
                    continue;
                }
            }
            if (string.IsNullOrEmpty(m_CreateAWorkOrder.id))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "请勾选要删除的数据", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            string img = string.Empty;
            string returnInfo = b_GetMethod.CreateWorkOrder(m_CreateAWorkOrder, M_SQLType.Delete);
            GetTable();
            img = returnInfo.Equals("删除成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }

    }
}
