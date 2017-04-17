using BLL;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_Execution
{
    public partial class SpecificationsQuery : MetroAppForm
    {
        Specifications specifications;
        private delegate void SetParameter(string keyword);
        public SpecificationsQuery(Specifications specifications)
        {
            InitializeComponent();
            this.specifications = specifications;
        }
        BLL.B_GetMethod b_GetMethod = new BLL.B_GetMethod();
        private void SpecificationsQuery_Load(object sender, EventArgs e)
        {
            string tableName = "[dbo].[T_Specifications]";
            string selectColumns = "[specificationsName] as 规格书,[clientCode] as 客户代码,[productModel] as 产品型号,[productCode] as 成品编码";
            dataGridView1.DataSource = b_GetMethod.GetTable(tableName, selectColumns);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string selectValue = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                SetParameter setParameter = new SetParameter(specifications.SetSpecificationsParameter);
                setParameter.Invoke(selectValue);
            }
            catch(Exception error)
            {
                B_GetMethod.LogWrite(error.ToString());
            }
        }
    }
}
