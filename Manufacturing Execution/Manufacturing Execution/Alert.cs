using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_Execution
{
    public partial class Alert : MetroAppForm
    {
        public Alert(string str,string ingStr)
        {
            InitializeComponent();
            pictureBox1.Image = ReadImageFile(ingStr);
            this.Text = "提示";
            //labelX1.TextAlignment = StringAlignment.Center;
            labelX1.Text = str;
        }
        public Bitmap ReadImageFile(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }
        private void Alert_Load(object sender, EventArgs e)
        {
            metroShell3.BackColor = Color.Red;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
