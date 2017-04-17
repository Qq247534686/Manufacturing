namespace Manufacturing_Execution
{
    partial class CreateAWorkOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAWorkOrder));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.button1, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            this.highlighter1.SetHighlightOnFocus(this.button1, true);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(374, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "添加/修改";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "车间编码：";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "001",
            "003",
            "003"});
            this.comboBox1.Location = new System.Drawing.Point(88, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBoxX1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(937, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "作业站信息";
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(619, 50);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.ReadOnly = true;
            this.textBoxX1.Size = new System.Drawing.Size(184, 21);
            this.textBoxX1.TabIndex = 45;
            this.textBoxX1.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.textBox3, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            this.highlighter1.SetHighlightOnFocus(this.textBox3, true);
            this.textBox3.Location = new System.Drawing.Point(401, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(121, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "工单开立";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(330, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前操作：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.comboBox12);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBox5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(937, 732);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工单资讯";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.button3, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            this.highlighter1.SetHighlightOnFocus(this.button3, true);
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(89, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 37);
            this.button3.TabIndex = 44;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(10, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(921, 526);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 20;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // comboBox12
            // 
            this.comboBox12.BackColor = System.Drawing.Color.White;
            this.comboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox12.ForeColor = System.Drawing.Color.Black;
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(659, 88);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(121, 20);
            this.comboBox12.TabIndex = 34;
            this.comboBox12.SelectedIndexChanged += new System.EventHandler(this.comboBox12_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(590, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "产品编码：";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.button2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            this.highlighter1.SetHighlightOnFocus(this.button2, true);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(659, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.ForeColor = System.Drawing.Color.Black;
            this.textBox6.Location = new System.Drawing.Point(401, 33);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(121, 21);
            this.textBox6.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(401, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 19;
            // 
            // comboBox8
            // 
            this.comboBox8.BackColor = System.Drawing.Color.White;
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.ForeColor = System.Drawing.Color.Black;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "制造流程1",
            "制造流程2",
            "制造流程3"});
            this.comboBox8.Location = new System.Drawing.Point(88, 88);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 20);
            this.comboBox8.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(17, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "制造工艺：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(330, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "投产总数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(332, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "客户名称：";
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.Color.White;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.ForeColor = System.Drawing.Color.Black;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(659, 33);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 20);
            this.comboBox5.TabIndex = 12;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(590, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "订单编号：";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ForeColor = System.Drawing.Color.Black;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "类型1",
            "类型2",
            "类型3"});
            this.comboBox2.Location = new System.Drawing.Point(88, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "工单类型：";
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = null;
            this.metroShell1.HelpButtonVisible = false;
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(1, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.SettingsButtonVisible = false;
            this.metroShell1.ShowIcon = false;
            this.metroShell1.Size = new System.Drawing.Size(965, 27);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 41;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Click += new System.EventHandler(this.metroShell1_Click);
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Location = new System.Drawing.Point(1, 650);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(965, 22);
            this.metroStatusBar1.TabIndex = 42;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // CreateAWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = new DevComponents.DotNetBar.Metro.BorderColors(System.Drawing.SystemColors.HotTrack, System.Drawing.Color.White, System.Drawing.SystemColors.HotTrack, System.Drawing.Color.Empty);
            this.BorderThickness = new DevComponents.DotNetBar.Metro.Thickness(3D, 0D, 3D, 0D);
            this.ClientSize = new System.Drawing.Size(967, 673);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateAWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateAWorkOrder";
            this.Load += new System.EventHandler(this.CreateAWorkOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Button button3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
    }
}