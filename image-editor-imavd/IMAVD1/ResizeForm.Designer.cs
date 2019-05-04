namespace IMAVD1
{
    partial class ResizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeForm));
            this.numericUpDownW = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownH = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.msmR = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroButtonOk = new MetroFramework.Controls.MetroButton();
            this.metroButtonCancel = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmR)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownW
            // 
            this.numericUpDownW.Location = new System.Drawing.Point(59, 45);
            this.numericUpDownW.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownW.Name = "numericUpDownW";
            this.numericUpDownW.Size = new System.Drawing.Size(188, 20);
            this.numericUpDownW.TabIndex = 34;
            this.numericUpDownW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownW.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownH
            // 
            this.numericUpDownH.Location = new System.Drawing.Point(59, 19);
            this.numericUpDownH.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownH.Name = "numericUpDownH";
            this.numericUpDownH.Size = new System.Drawing.Size(188, 20);
            this.numericUpDownH.TabIndex = 32;
            this.numericUpDownH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownH.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.numericUpDownH);
            this.groupBox1.Controls.Add(this.numericUpDownW);
            this.groupBox1.Location = new System.Drawing.Point(10, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 77);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(29, 45);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(27, 19);
            this.metroLabel2.TabIndex = 36;
            this.metroLabel2.Text = "W:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(29, 19);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(24, 19);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "H:";
            // 
            // msmR
            // 
            this.msmR.Owner = null;
            // 
            // metroButtonOk
            // 
            this.metroButtonOk.Location = new System.Drawing.Point(69, 156);
            this.metroButtonOk.Name = "metroButtonOk";
            this.metroButtonOk.Size = new System.Drawing.Size(75, 23);
            this.metroButtonOk.TabIndex = 36;
            this.metroButtonOk.Text = "Ok";
            this.metroButtonOk.UseSelectable = true;
            this.metroButtonOk.Click += new System.EventHandler(this.metroButtonOk_Click);
            // 
            // metroButtonCancel
            // 
            this.metroButtonCancel.Location = new System.Drawing.Point(150, 156);
            this.metroButtonCancel.Name = "metroButtonCancel";
            this.metroButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCancel.TabIndex = 37;
            this.metroButtonCancel.Text = "Cancel";
            this.metroButtonCancel.UseSelectable = true;
            this.metroButtonCancel.Click += new System.EventHandler(this.metroButtonCancel_Click);
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 192);
            this.Controls.Add(this.metroButtonCancel);
            this.Controls.Add(this.metroButtonOk);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResizeForm";
            this.Resizable = false;
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownW;
        private System.Windows.Forms.NumericUpDown numericUpDownH;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Components.MetroStyleManager msmR;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButtonOk;
        private MetroFramework.Controls.MetroButton metroButtonCancel;
    }
}