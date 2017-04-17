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
    public partial class ProductInformation : MetroAppForm
    {
        public ProductInformation()
        {
            InitializeComponent();
        }
        B_GetMethod b_GetMethod = new B_GetMethod();
        private void ProductInformation_Load(object sender, EventArgs e)
        {
            GetTable();
        }
        /// <summary>
        /// 重新加载表
        /// </summary>
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable("T_ProductInformation", "[id],[productNumber] as 产品编码,[productName] as 产品名称,[dataEntryStaff] as 录入员,[entryTime] as 录入时间");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["产品编码"].ReadOnly = true;
            dataGridView1.Columns["产品名称"].ReadOnly = true;
            dataGridView1.Columns["录入员"].ReadOnly = true;
            dataGridView1.Columns["录入时间"].ReadOnly = true;
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns["id"].Visible = false;
        }
        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxX1.Text) || string.IsNullOrEmpty(textBoxX3.Text) || string.IsNullOrEmpty(textBoxX2.Text))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, @"产品名称,产品编码，录入员不能为空！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            M_ProductInformation m_ProductInformation = new M_ProductInformation();
            m_ProductInformation.productName = textBoxX3.Text;
            m_ProductInformation.dataEntryStaff = textBoxX1.Text;
            m_ProductInformation.productNumber = textBoxX2.Text;
            string img = string.Empty;
            string returnInfo = b_GetMethod.HandleProductInformation(m_ProductInformation, M_SQLType.Insert);
            GetTable();
            img = returnInfo.Equals("产品【" + m_ProductInformation.productName + "】添加成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            M_ProductInformation m_ProductInformation = new M_ProductInformation();
            int count = Convert.ToInt16(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行
                {
                    m_ProductInformation.productName += dataGridView1.Rows[i].Cells["id"].Value.ToString() + ",";
                }
                else
                {
                    continue;
                }
            }
            if (string.IsNullOrEmpty(m_ProductInformation.productName))
            {
                return;
            }
            string img = string.Empty;
            string returnInfo = b_GetMethod.HandleProductInformation(m_ProductInformation, M_SQLType.Delete);
            GetTable();
            img = returnInfo.Equals("删除成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
