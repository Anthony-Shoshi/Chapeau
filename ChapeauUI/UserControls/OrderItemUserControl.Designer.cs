namespace ChapeauUI.UserControls
{
    partial class OrderItemUserControl
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
            this.lblMenuItemName = new System.Windows.Forms.Label();
            this.lblQnty = new System.Windows.Forms.Label();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMenuItemName
            // 
            this.lblMenuItemName.AutoEllipsis = true;
            this.lblMenuItemName.AutoSize = true;
            this.lblMenuItemName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMenuItemName.Location = new System.Drawing.Point(8, 10);
            this.lblMenuItemName.MaximumSize = new System.Drawing.Size(140, 15);
            this.lblMenuItemName.Name = "lblMenuItemName";
            this.lblMenuItemName.Size = new System.Drawing.Size(125, 15);
            this.lblMenuItemName.TabIndex = 0;
            this.lblMenuItemName.Text = "Menu Item Menu Item Menu Item Menu Item";
            // 
            // lblQnty
            // 
            this.lblQnty.AutoSize = true;
            this.lblQnty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQnty.Location = new System.Drawing.Point(189, 20);
            this.lblQnty.Name = "lblQnty";
            this.lblQnty.Size = new System.Drawing.Size(17, 19);
            this.lblQnty.TabIndex = 1;
            this.lblQnty.Text = "1";
            // 
            // btnIncrement
            // 
            this.btnIncrement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIncrement.Location = new System.Drawing.Point(210, 16);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(25, 26);
            this.btnIncrement.TabIndex = 2;
            this.btnIncrement.Text = "+";
            this.btnIncrement.UseVisualStyleBackColor = true;
            // 
            // btnDecrement
            // 
            this.btnDecrement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecrement.Location = new System.Drawing.Point(160, 16);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(25, 26);
            this.btnDecrement.TabIndex = 3;
            this.btnDecrement.Text = "-";
            this.btnDecrement.UseVisualStyleBackColor = true;
            // 
            // lblNote
            // 
            this.lblNote.AutoEllipsis = true;
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(8, 31);
            this.lblNote.MaximumSize = new System.Drawing.Size(140, 15);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(64, 15);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "comments";
            // 
            // OrderItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnDecrement);
            this.Controls.Add(this.btnIncrement);
            this.Controls.Add(this.lblQnty);
            this.Controls.Add(this.lblMenuItemName);
            this.Name = "OrderItemUserControl";
            this.Size = new System.Drawing.Size(247, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMenuItemName;
        private Label lblQnty;
        private Button btnIncrement;
        private Button btnDecrement;
        private Label lblNote;
    }
}
