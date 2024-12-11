namespace winforms_3
{
    partial class MainTable
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewMainTable = new System.Windows.Forms.DataGridView();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSourceCars = new System.Windows.Forms.BindingSource(this.components);
            this.menuStripFile = new System.Windows.Forms.MenuStrip();
            this.faleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCars)).BeginInit();
            this.menuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMainTable
            // 
            this.dataGridViewMainTable.AutoGenerateColumns = false;
            this.dataGridViewMainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brand,
            this.model,
            this.power,
            this.maxSpeed,
            this.type});
            this.dataGridViewMainTable.DataSource = this.bindingSourceCars;
            this.dataGridViewMainTable.Location = new System.Drawing.Point(10, 134);
            this.dataGridViewMainTable.Name = "dataGridViewMainTable";
            this.dataGridViewMainTable.Size = new System.Drawing.Size(777, 304);
            this.dataGridViewMainTable.TabIndex = 0;
            this.dataGridViewMainTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMainTable_CellValueChanged);
            this.dataGridViewMainTable.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewMainTable_RowHeaderMouseDoubleClick);
            // 
            // brand
            // 
            this.brand.DataPropertyName = "m_brand";
            this.brand.HeaderText = "brand";
            this.brand.Name = "brand";
            // 
            // model
            // 
            this.model.DataPropertyName = "m_model";
            this.model.HeaderText = "model";
            this.model.Name = "model";
            // 
            // power
            // 
            this.power.DataPropertyName = "m_power";
            this.power.HeaderText = "power";
            this.power.Name = "power";
            // 
            // maxSpeed
            // 
            this.maxSpeed.DataPropertyName = "m_maxSpeed";
            this.maxSpeed.HeaderText = "max speed";
            this.maxSpeed.Name = "maxSpeed";
            // 
            // type
            // 
            this.type.DataPropertyName = "m_type";
            this.type.HeaderText = "type";
            this.type.Items.AddRange(new object[] {
            "PassengerCar",
            "Truck"});
            this.type.Name = "type";
            // 
            // menuStripFile
            // 
            this.menuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faleToolStripMenuItem});
            this.menuStripFile.Location = new System.Drawing.Point(0, 0);
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(800, 24);
            this.menuStripFile.TabIndex = 1;
            this.menuStripFile.Text = "menuStrip1";
            // 
            // faleToolStripMenuItem
            // 
            this.faleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveListToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.faleToolStripMenuItem.Name = "faleToolStripMenuItem";
            this.faleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.faleToolStripMenuItem.Text = "File";
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.saveListToolStripMenuItem.Text = "Save List";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.SaveListToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.dataGridViewMainTable);
            this.Controls.Add(this.menuStripFile);
            this.MainMenuStrip = this.menuStripFile;
            this.Name = "MainTable";
            this.Text = "MainTable";
            this.Load += new System.EventHandler(this.MainTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCars)).EndInit();
            this.menuStripFile.ResumeLayout(false);
            this.menuStripFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMainTable;
        private System.Windows.Forms.BindingSource bindingSourceCars;
        private System.Windows.Forms.MenuStrip menuStripFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn power;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSpeed;
        private System.Windows.Forms.DataGridViewComboBoxColumn type;
        private System.Windows.Forms.ToolStripMenuItem faleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

