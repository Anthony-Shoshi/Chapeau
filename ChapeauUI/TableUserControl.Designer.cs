namespace ChapeauUI
{
    partial class TableUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTableLeft = new System.Windows.Forms.Panel();
            this.pnlTableTop = new System.Windows.Forms.Panel();
            this.pnlTableRight = new System.Windows.Forms.Panel();
            this.pnlTableBottom = new System.Windows.Forms.Panel();
            this.btnTableNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlTableLeft
            // 
            this.pnlTableLeft.BackColor = System.Drawing.Color.Green;
            this.pnlTableLeft.Location = new System.Drawing.Point(6, 25);
            this.pnlTableLeft.Name = "pnlTableLeft";
            this.pnlTableLeft.Size = new System.Drawing.Size(14, 77);
            this.pnlTableLeft.TabIndex = 2;
            // 
            // pnlTableTop
            // 
            this.pnlTableTop.BackColor = System.Drawing.Color.Green;
            this.pnlTableTop.Location = new System.Drawing.Point(22, 7);
            this.pnlTableTop.Name = "pnlTableTop";
            this.pnlTableTop.Size = new System.Drawing.Size(85, 12);
            this.pnlTableTop.TabIndex = 2;
            // 
            // pnlTableRight
            // 
            this.pnlTableRight.BackColor = System.Drawing.Color.Green;
            this.pnlTableRight.Location = new System.Drawing.Point(113, 25);
            this.pnlTableRight.Name = "pnlTableRight";
            this.pnlTableRight.Size = new System.Drawing.Size(13, 77);
            this.pnlTableRight.TabIndex = 3;
            // 
            // pnlTableBottom
            // 
            this.pnlTableBottom.BackColor = System.Drawing.Color.Green;
            this.pnlTableBottom.Location = new System.Drawing.Point(22, 108);
            this.pnlTableBottom.Name = "pnlTableBottom";
            this.pnlTableBottom.Size = new System.Drawing.Size(85, 13);
            this.pnlTableBottom.TabIndex = 1;
            // 
            // btnTableNo
            // 
            this.btnTableNo.BackColor = System.Drawing.Color.Green;
            this.btnTableNo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTableNo.ForeColor = System.Drawing.Color.White;
            this.btnTableNo.Location = new System.Drawing.Point(26, 25);
            this.btnTableNo.Name = "btnTableNo";
            this.btnTableNo.Size = new System.Drawing.Size(81, 77);
            this.btnTableNo.TabIndex = 4;
            this.btnTableNo.TabStop = false;
            this.btnTableNo.Text = "Table 10";
            this.btnTableNo.UseVisualStyleBackColor = false;
            this.btnTableNo.Click += new System.EventHandler(this.btnTableNo_Click);
            // 
            // TableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTableNo);
            this.Controls.Add(this.pnlTableRight);
            this.Controls.Add(this.pnlTableLeft);
            this.Controls.Add(this.pnlTableTop);
            this.Controls.Add(this.pnlTableBottom);
            this.Name = "TableUserControl";
            this.Size = new System.Drawing.Size(134, 128);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTableLeft;
        private Panel pnlTableTop;
        private Panel pnlTableRight;
        private Panel pnlTableBottom;
        private Button btnTableNo;
    }
}
