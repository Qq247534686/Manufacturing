using DevComponents.DotNetBar;
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
using BLL;
using System.IO;
using Model;
namespace Manufacturing_Execution
{
    public partial class ImportWorkOrder : MetroAppForm
    {
        public ImportWorkOrder()
        {
            InitializeComponent();
        }
        BLL.B_GetMethod b_GetMethod = new BLL.B_GetMethod();
        private void ImportWorkOrder_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "excel2007|*.xlsx|excel2003|*.xls";
            openFileDialog1.CheckPathExists = true;
            textBox1.Text = openFileDialog1.FileName;
            toolTip1.ToolTipTitle = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string extension=Path.GetExtension(textBox1.Text);
            List<string> lisMessage = new List<string>();
            if (string.IsNullOrEmpty(textBox1.Text) || extension != ".xlsx")
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "请选择正确的Excel文件导入！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            if (b_GetMethod.ImportPlanMethod(textBox1.Text))
            {
                GetTable();
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "导入成功", BLL.B_GetMethod.ReadImageFile(@"../../Images/success.png"), 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter);

            }
            else
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "导入失败！！！", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
            }
        }
        private eTaskDialogButton GetTaskDialogButtons()
        {
            eTaskDialogButton button = eTaskDialogButton.Yes;
            button |= eTaskDialogButton.Close;

            if (button != eTaskDialogButton.Yes)
                button = button & ~(button & eTaskDialogButton.Yes);
            return button;
        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable("[T_ImportPlan]", "[id],[orderNumber] as 订单编号,[productName] as 产品,[client] as 客户,[productNumber] as 投产数量,[deliveryDate] as 交货日期");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["订单编号"].ReadOnly = true;
            dataGridView1.Columns["产品"].ReadOnly = true;
            dataGridView1.Columns["客户"].ReadOnly = true;
            dataGridView1.Columns["投产数量"].ReadOnly = true;
            dataGridView1.Columns["交货日期"].ReadOnly = true;
            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            M_ImportPlan m_ImportPlan = new M_ImportPlan();
            int count = Convert.ToInt16(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行
                {
                    m_ImportPlan.id += dataGridView1.Rows[i].Cells["id"].Value.ToString() + ",";
                }
                else
                {
                    continue;
                }
            }
            if (string.IsNullOrEmpty(m_ImportPlan.id))
            {
                ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
                ToastNotification.Show(this, "请勾选要删除的数据", BLL.B_GetMethod.ReadImageFile(@"../../Images/Error.png"), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
                return;
            }
            string img = string.Empty;
            string returnInfo = b_GetMethod.HandleM_ImportPlan(m_ImportPlan, M_SQLType.Delete);
            GetTable();
            img = returnInfo.Equals("删除成功") ? @"../../Images/success.png" : @"../../Images/Error.png";
            ToastNotification.CustomGlowColor = Color.FromArgb(48, 32, 22);
            ToastNotification.Show(this, returnInfo, BLL.B_GetMethod.ReadImageFile(img), 2000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {
            
        }
    }
}
