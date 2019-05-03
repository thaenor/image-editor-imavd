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
            this.okResizeBtn = new System.Windows.Forms.Button();
            this.cancelResizeBtn = new System.Windows.Forms.Button();
            this.numericUpDownW = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownH = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okResizeBtn
            // 
            this.okResizeBtn.Location = new System.Drawing.Point(76, 158);
            this.okResizeBtn.Name = "okResizeBtn";
            this.okResizeBtn.Size = new System.Drawing.Size(56, 23);
            this.okResizeBtn.TabIndex = 0;
            this.okResizeBtn.Text = "Ok";
            this.okResizeBtn.UseVisualStyleBackColor = true;
            this.okResizeBtn.Click += new System.EventHandler(this.okResizeBtn_Click);
            // 
            // cancelResizeBtn
            // 
            this.cancelResizeBtn.Location = new System.Drawing.Point(155, 158);
            this.cancelResizeBtn.Name = "cancelResizeBtn";
            this.cancelResizeBtn.Size = new System.Drawing.Size(56, 23);
            this.cancelResizeBtn.TabIndex = 1;
            this.cancelResizeBtn.Text = "Cancel";
            this.cancelResizeBtn.UseVisualStyleBackColor = true;
            this.cancelResizeBtn.Click += new System.EventHandler(this.cancelResizeBtn_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "W:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "H:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownH);
            this.groupBox1.Controls.Add(this.numericUpDownW);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 77);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize Image";
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 192);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelResizeBtn);
            this.Controls.Add(this.okResizeBtn);
            this.Name = "ResizeForm";
            this.Resizable = false;
            this.Text = "Resize";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okResizeBtn;
        private System.Windows.Forms.Button cancelResizeBtn;
        private System.Windows.Forms.NumericUpDown numericUpDownW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}