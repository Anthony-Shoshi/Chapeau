namespace ChapeauUI
{
    partial class KitchenView
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
            mainPanel = new Panel();
            headerPanel = new Panel();
            label1 = new Label();
            orderTypeCombo = new ComboBox();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.AutoScroll = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Location = new Point(5, 66);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1056, 487);
            mainPanel.TabIndex = 0;
            mainPanel.Paint += mainPanel_Paint;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(orderTypeCombo);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1061, 48);
            headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 15);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Order type";
            // 
            // orderTypeCombo
            // 
            orderTypeCombo.FormattingEnabled = true;
            orderTypeCombo.Location = new Point(100, 12);
            orderTypeCombo.Name = "orderTypeCombo";
            orderTypeCombo.Size = new Size(121, 23);
            orderTypeCombo.TabIndex = 0;
            orderTypeCombo.SelectedIndexChanged += orderTypeCombo_SelectedIndexChanged;
            // 
            // KitchenView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 682);
            Controls.Add(headerPanel);
            Controls.Add(mainPanel);
            Name = "KitchenView";
            Text = "KitchenView";
            Load += KitchenView_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel headerPanel;
        private Label label1;
        private ComboBox orderTypeCombo;
    }
}