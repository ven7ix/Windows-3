namespace winforms_3
{
    partial class BrandTable
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
            this.dataGridViewTruck = new System.Windows.Forms.DataGridView();
            this.brandTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSpeedTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licencePlateTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wheelsTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trunkVolumeTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPassenger = new System.Windows.Forms.DataGridView();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licencePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multimedia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airbags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTruck
            // 
            this.dataGridViewTruck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTruck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brandTruck,
            this.modelTruck,
            this.powerTruck,
            this.maxSpeedTruck,
            this.licencePlateTruck,
            this.wheelsTruck,
            this.trunkVolumeTruck});
            this.dataGridViewTruck.Location = new System.Drawing.Point(13, 32);
            this.dataGridViewTruck.Name = "dataGridViewTruck";
            this.dataGridViewTruck.Size = new System.Drawing.Size(775, 151);
            this.dataGridViewTruck.TabIndex = 0;
            // 
            // brandTruck
            // 
            this.brandTruck.HeaderText = "brandTruck";
            this.brandTruck.Name = "brandTruck";
            // 
            // modelTruck
            // 
            this.modelTruck.HeaderText = "modelTruck";
            this.modelTruck.Name = "modelTruck";
            // 
            // powerTruck
            // 
            this.powerTruck.HeaderText = "powerTruck";
            this.powerTruck.Name = "powerTruck";
            // 
            // maxSpeedTruck
            // 
            this.maxSpeedTruck.HeaderText = "maxSpeedTruck";
            this.maxSpeedTruck.Name = "maxSpeedTruck";
            // 
            // licencePlateTruck
            // 
            this.licencePlateTruck.HeaderText = "licencePlateTruck";
            this.licencePlateTruck.Name = "licencePlateTruck";
            // 
            // wheelsTruck
            // 
            this.wheelsTruck.HeaderText = "wheelsTruck";
            this.wheelsTruck.Name = "wheelsTruck";
            // 
            // trunkVolumeTruck
            // 
            this.trunkVolumeTruck.HeaderText = "trunkVolumeTruck";
            this.trunkVolumeTruck.Name = "trunkVolumeTruck";
            // 
            // dataGridViewPassenger
            // 
            this.dataGridViewPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brand,
            this.model,
            this.power,
            this.maxSpeed,
            this.licencePlate,
            this.multimedia,
            this.airbags});
            this.dataGridViewPassenger.Location = new System.Drawing.Point(12, 220);
            this.dataGridViewPassenger.Name = "dataGridViewPassenger";
            this.dataGridViewPassenger.Size = new System.Drawing.Size(775, 150);
            this.dataGridViewPassenger.TabIndex = 1;
            // 
            // brand
            // 
            this.brand.HeaderText = "brand";
            this.brand.Name = "brand";
            // 
            // model
            // 
            this.model.HeaderText = "model";
            this.model.Name = "model";
            // 
            // power
            // 
            this.power.HeaderText = "power";
            this.power.Name = "power";
            // 
            // maxSpeed
            // 
            this.maxSpeed.HeaderText = "max speed";
            this.maxSpeed.Name = "maxSpeed";
            // 
            // licencePlate
            // 
            this.licencePlate.HeaderText = "licence plate";
            this.licencePlate.Name = "licencePlate";
            // 
            // multimedia
            // 
            this.multimedia.HeaderText = "multimedia";
            this.multimedia.Name = "multimedia";
            // 
            // airbags
            // 
            this.airbags.HeaderText = "airbags";
            this.airbags.Name = "airbags";
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.TimerLoad_Tick);
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(2, 387);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(798, 61);
            this.progressBarLoad.TabIndex = 2;
            // 
            // BrandTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBarLoad);
            this.Controls.Add(this.dataGridViewPassenger);
            this.Controls.Add(this.dataGridViewTruck);
            this.Name = "BrandTable";
            this.Text = "BrandTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTruck;
        private System.Windows.Forms.DataGridView dataGridViewPassenger;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSpeedTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn licencePlateTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn wheelsTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn trunkVolumeTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn power;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn licencePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn multimedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn airbags;
        private System.Windows.Forms.ProgressBar progressBarLoad;
    }
}