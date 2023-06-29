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
            noNewOrdersLabel = new Label();
            headerPanel = new Panel();
            refreshButton = new Button();
            label2 = new Label();
            userNameLabel = new Label();
            viewTypeLabel = new Label();
            label1 = new Label();
            orderTypeCombo = new ComboBox();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.AutoScroll = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Controls.Add(noNewOrdersLabel);
            mainPanel.Location = new Point(5, 94);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1056, 459);
            mainPanel.TabIndex = 0;
            // 
            // noNewOrdersLabel
            // 
            noNewOrdersLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            noNewOrdersLabel.AutoSize = true;
            noNewOrdersLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
            noNewOrdersLabel.Location = new Point(373, 182);
            noNewOrdersLabel.Name = "noNewOrdersLabel";
            noNewOrdersLabel.Size = new Size(317, 54);
            noNewOrdersLabel.TabIndex = 6;
            noNewOrdersLabel.Text = "No new Orders.";
            noNewOrdersLabel.Visible = false;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(refreshButton);
            headerPanel.Controls.Add(label2);
            headerPanel.Controls.Add(userNameLabel);
            headerPanel.Controls.Add(viewTypeLabel);
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(orderTypeCombo);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1061, 80);
            headerPanel.TabIndex = 1;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(269, 43);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(769, 15);
            label2.Name = "label2";
            label2.Size = new Size(127, 21);
            label2.TabIndex = 4;
            label2.Text = "Employee Name:";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userNameLabel.Location = new Point(913, 15);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(0, 21);
            userNameLabel.TabIndex = 3;
            // 
            // viewTypeLabel
            // 
            viewTypeLabel.AutoSize = true;
            viewTypeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            viewTypeLabel.Location = new Point(29, 15);
            viewTypeLabel.Name = "viewTypeLabel";
            viewTypeLabel.Size = new Size(0, 21);
            viewTypeLabel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 46);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Order type";
            // 
            // orderTypeCombo
            // 
            orderTypeCombo.FormattingEnabled = true;
            orderTypeCombo.Location = new Point(117, 43);
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
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel headerPanel;
        private Label label1;
        private ComboBox orderTypeCombo;
        private Label viewTypeLabel;
        private Label userNameLabel;
        private Label label2;
        private Button refreshButton;
        private Label noNewOrdersLabel;
    }
}