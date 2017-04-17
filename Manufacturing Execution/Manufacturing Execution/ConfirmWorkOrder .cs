using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
    public partial class ConfirmWorkOrder : MetroAppForm
    {
        public ConfirmWorkOrder()
        {
            InitializeComponent();
        }
        BLL.B_GetMethod b_GetMethod = new BLL.B_GetMethod();
        private void ConfirmWorkOrder_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0) return;
            comboBox1.DataSource = b_GetMethod.GetList("T_CerateWorkOrder", "orderMD5Number", "");
            DataTable dt = PaddingData(comboBox1.SelectedItem.ToString());
            dataGridView1.DataSource=dt;
            proccessBar();
        }

        private DataTable PaddingData(string p)
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable_ConfirmWorkOrder("T_CerateWorkOrder", "id,orderMD5Number as 工单编号,totalProduction as 投产总数,poductCode as 产品名称,customerName as 客户名称,[isConfirm] as 是否已确认", "[orderMD5Number]='" + comboBox1.SelectedItem.ToString() + "'");
            return dt;
        }
        private void proccessBar(){
            if (dataGridView1.RowCount <= 0)
            {
                return;
            }
            dataGridView1.Columns["id"].Visible = false;
            DataGridViewProgressBarXColumn rowsProgressBar;
            int columnsNumber = dataGridView1.Columns.Count - 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                rowsProgressBar = new DataGridViewProgressBarXColumn();
                //rowsProgressBar.Width = 10;
                Random random = new Random();
                int s = random.Next(0,100);
                dataGridView1.Rows[i].Cells[0].Value = s;
                dataGridView1.Rows[i].Cells[0].ToolTipText = s.ToString()+"%";
                if(dataGridView1.Rows[i].Cells[columnsNumber].Value.ToString().Equals("否"))
                {
                    dataGridView1.Rows[i].Cells[columnsNumber].Style.ForeColor=Color.Red;
                }
                else{
                     dataGridView1.Rows[i].Cells[columnsNumber].Style.ForeColor=Color.Green;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = PaddingData(comboBox1.SelectedItem.ToString());
            dataGridView1.DataSource = dt;
            proccessBar();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string messInfo = string.Empty;
            string img = string.Empty;
            if (dataGridView1.SelectedRows.Count > 1)
            {
                string selectCellArray = string.Empty;
                int selectRows = dataGridView1.SelectedRows.Count;
                for (int i = 0; i < selectRows; i++)
                {
                    selectCellArray+="'"+dataGridView1.SelectedRows[i].Cells[2].Value.ToString()+"',";
                }
                if (b_GetMethod.UpdateWorkOrder(selectCellArray.TrimEnd(',')))
                {
                    messInfo = "操作成功"; img = @"../../Images/success.png";
                    DataTable dt = new DataTable();
                    dt = b_GetMethod.GetTable("T_CerateWorkOrder", "id,orderMD5Number as 工单编号,totalProduction as 投产总数,poductCode as 产品名称,customerName as 客户名称,[isConfirm] as 是否已确认");
                    dataGridView1.DataSource = dt;
                    proccessBar();
                }
                else
                {
                    messInfo = "操作失败"; img = @"../../Images/Error.png";
                }
            }
            else
            {
                string selectID = dataGridView1.SelectedCells[2].Value.ToString();

                if (b_GetMethod.UpdateWorkOrder("'"+selectID+"'"))
                {
                    messInfo = "操作成功"; img = @"../../Images/success.png";
                    DataTable dt = new DataTable();
                    dt = b_GetMethod.GetTable("T_CerateWorkOrder", "id,orderMD5Number as 工单编号,totalProduction as 投产总数,poductCode as 产品名称,customerName as 客户名称,[isConfirm] as 是否已确认");
                    dataGridView1.DataSource = dt;
                    proccessBar();
                }
                else
                {
                    messInfo = "操作失败"; img = @"../../Images/Error.png";
                }
            }
            ToastNotification.Show(this, messInfo, BLL.B_GetMethod.ReadImageFile(img), 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter);
        }
    }
}
