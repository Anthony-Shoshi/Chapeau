namespace ChapeauUI
{
    partial class MenuItemNote
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
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancelNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(12, 12);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(241, 104);
            this.txtNote.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(57, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelNote
            // 
            this.btnCancelNote.Location = new System.Drawing.Point(138, 132);
            this.btnCancelNote.Name = "btnCancelNote";
            this.btnCancelNote.Size = new System.Drawing.Size(75, 23);
            this.btnCancelNote.TabIndex = 2;
            this.btnCancelNote.Text = "Cancel";
            this.btnCancelNote.UseVisualStyleBackColor = true;
            this.btnCancelNote.Click += new System.EventHandler(this.btnCancelNote_Click);
            // 
            // MenuItemNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 174);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelNote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNote);
            this.Name = "MenuItemNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Special Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNote;
        private Button btnSave;
        private Button btnCancelNote;
    }
}