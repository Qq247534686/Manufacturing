using BLL;
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
    public partial class SpecificInformationQuery : MetroAppForm
    {
        SpecificInformation specificInformation;
        private delegate void SetParameter(string keyword);
        B_GetMethod b_GetMethod = new B_GetMethod();
        public SpecificInformationQuery(SpecificInformation specificInformation)
        {
            InitializeComponent();
            this.specificInformation = specificInformation;
        }

        private void SpecificInformationQuery_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = b_GetMethod.GetTable("[T_SpecificInformation]", "[workOrderNumberOne] as 随工单序号,[workOrderNumberTow] as 备货单号,[contractNumber] as 合同书编号,[specificationNumber] as 规格书编号,[tbleNumber] 表格编号");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                string selectValue = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                SetParameter setParameter = new SetParameter(specificInformation.SetSpecificInformationParameter);
                setParameter.Invoke(selectValue);
            }
            catch (Exception error)
            {
                B_GetMethod.LogWrite(error.ToString());
            }
        }
    }
}
