namespace Manufacturing_Execution
{
    partial class ImportWorkOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWorkOrder));
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.metroShell1.Size = new System.Drawing.Size(634, 27);
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
            this.metroShell1.TabIndex = 42;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.TitleText = "导入计划";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "excel2007|*.xlsx|excel2003|*.xls";
            this.openFileDialog1.Title = "选择导入计划";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(336, 49);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(83, 21);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX1.TabIndex = 44;
            this.buttonX1.Text = "打开";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(435, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "导入";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.textBox1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue);
            this.highlighter1.SetHighlightOnFocus(this.textBox1, true);
            this.textBox1.Location = new System.Drawing.Point(40, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(282, 21);
            this.textBox1.TabIndex = 46;
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
            this.dataGridView1.Location = new System.Drawing.Point(1, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(634, 295);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.MultiSelectChanged += new System.EventHandler(this.dataGridView1_MultiSelectChanged);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 20F;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 20;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(534, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // ImportWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = new DevComponents.DotNetBar.Metro.BorderColors(System.Drawing.SystemColors.HotTrack, System.Drawing.Color.Empty, System.Drawing.SystemColors.HotTrack, System.Drawing.SystemColors.HotTrack);
            this.BorderThickness = new DevComponents.DotNetBar.Metro.Thickness(3D, 0D, 3D, 3D);
            this.ClientSize = new System.Drawing.Size(636, 401);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ImportWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportWorkOrder";
            this.Load += new System.EventHandler(this.ImportWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Button button2;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
    }
}