namespace ChapeauUI
{
    partial class WaiterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaiterView));
            topMenu = new Panel();
            pnlMenuMenu = new Panel();
            lblMenuMenu = new Label();
            pictureBoxMenuMenu = new PictureBox();
            pnlTableMenu = new Panel();
            lblTableMenu = new Label();
            pictureBoxTableMenu = new PictureBox();
            lblUsername = new Label();
            imgLogo = new PictureBox();
            tableLayoutPanelTable = new TableLayoutPanel();
            topMenu.SuspendLayout();
            pnlMenuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenuMenu).BeginInit();
            pnlTableMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTableMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            SuspendLayout();
            // 
            // topMenu
            // 
            topMenu.BackColor = Color.FromArgb(113, 161, 209);
            topMenu.Controls.Add(pnlMenuMenu);
            topMenu.Controls.Add(pnlTableMenu);
            topMenu.Controls.Add(lblUsername);
            topMenu.Controls.Add(imgLogo);
            topMenu.Dock = DockStyle.Top;
            topMenu.Location = new Point(0, 0);
            topMenu.Margin = new Padding(6, 6, 6, 6);
            topMenu.Name = "topMenu";
            topMenu.Size = new Size(1486, 117);
            topMenu.TabIndex = 1;
            // 
            // pnlMenuMenu
            // 
            pnlMenuMenu.BackColor = Color.FromArgb(192, 255, 255);
            pnlMenuMenu.Controls.Add(lblMenuMenu);
            pnlMenuMenu.Controls.Add(pictureBoxMenuMenu);
            pnlMenuMenu.Location = new Point(394, 4);
            pnlMenuMenu.Margin = new Padding(6, 6, 6, 6);
            pnlMenuMenu.Name = "pnlMenuMenu";
            pnlMenuMenu.Size = new Size(111, 107);
            pnlMenuMenu.TabIndex = 3;
            // 
            // lblMenuMenu
            // 
            lblMenuMenu.AutoSize = true;
            lblMenuMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuMenu.Location = new Point(15, 62);
            lblMenuMenu.Margin = new Padding(6, 0, 6, 0);
            lblMenuMenu.Name = "lblMenuMenu";
            lblMenuMenu.Size = new Size(90, 37);
            lblMenuMenu.TabIndex = 1;
            lblMenuMenu.Text = "Menu";

            // 
            // pictureBoxMenuMenu
            // 
            pictureBoxMenuMenu.Image = (Image)resources.GetObject("pictureBoxMenuMenu.Image");
            pictureBoxMenuMenu.Location = new Point(20, -2);
            pictureBoxMenuMenu.Margin = new Padding(6, 6, 6, 6);
            pictureBoxMenuMenu.Name = "pictureBoxMenuMenu";
            pictureBoxMenuMenu.Size = new Size(72, 75);
            pictureBoxMenuMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMenuMenu.TabIndex = 0;
            pictureBoxMenuMenu.TabStop = false;

            // 
            // pnlTableMenu
            // 
            pnlTableMenu.BackColor = Color.FromArgb(192, 255, 255);
            pnlTableMenu.Controls.Add(lblTableMenu);
            pnlTableMenu.Controls.Add(pictureBoxTableMenu);
            pnlTableMenu.Location = new Point(253, 4);
            pnlTableMenu.Margin = new Padding(6, 6, 6, 6);
            pnlTableMenu.Name = "pnlTableMenu";
            pnlTableMenu.Size = new Size(111, 107);
            pnlTableMenu.TabIndex = 2;
            // 
            // lblTableMenu
            // 
            lblTableMenu.AutoSize = true;
            lblTableMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTableMenu.Location = new Point(7, 62);
            lblTableMenu.Margin = new Padding(6, 0, 6, 0);
            lblTableMenu.Name = "lblTableMenu";
            lblTableMenu.Size = new Size(98, 37);
            lblTableMenu.TabIndex = 1;
            lblTableMenu.Text = "Tables";

            // 
            // pictureBoxTableMenu
            // 
            pictureBoxTableMenu.Image = (Image)resources.GetObject("pictureBoxTableMenu.Image");
            pictureBoxTableMenu.Location = new Point(20, 0);
            pictureBoxTableMenu.Margin = new Padding(6, 6, 6, 6);
            pictureBoxTableMenu.Name = "pictureBoxTableMenu";
            pictureBoxTableMenu.Size = new Size(72, 75);
            pictureBoxTableMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTableMenu.TabIndex = 0;
            pictureBoxTableMenu.TabStop = false;

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsername.ImageAlign = ContentAlignment.MiddleRight;
            lblUsername.Location = new Point(1354, 36);
            lblUsername.Margin = new Padding(6, 0, 6, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(107, 45);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Maria";
            // 
            // imgLogo
            // 
            imgLogo.BackgroundImage = Properties.Resources.logo;
            imgLogo.BackgroundImageLayout = ImageLayout.Zoom;
            imgLogo.Location = new Point(6, 6);
            imgLogo.Margin = new Padding(6, 6, 6, 6);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(186, 107);
            imgLogo.TabIndex = 0;
            imgLogo.TabStop = false;
            // 
            // tableLayoutPanelTable
            // 
            tableLayoutPanelTable.AutoScroll = true;
            tableLayoutPanelTable.ColumnCount = 5;
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.Dock = DockStyle.Fill;
            tableLayoutPanelTable.Location = new Point(0, 0);
            tableLayoutPanelTable.Margin = new Padding(6, 6, 6, 6);
            tableLayoutPanelTable.Name = "tableLayoutPanelTable";
            tableLayoutPanelTable.RowCount = 2;
            tableLayoutPanelTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelTable.Size = new Size(1486, 960);
            tableLayoutPanelTable.TabIndex = 2;
            // 
            // WaiterView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(topMenu);
            Controls.Add(tableLayoutPanelTable);
            Margin = new Padding(6, 6, 6, 6);
            Name = "WaiterView";
            Text = "Chapeau - Restaurant Ordering System";
            topMenu.ResumeLayout(false);
            topMenu.PerformLayout();
            pnlMenuMenu.ResumeLayout(false);
            pnlMenuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenuMenu).EndInit();
            pnlTableMenu.ResumeLayout(false);
            pnlTableMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTableMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel topMenu;
        private PictureBox imgLogo;
        private Label lblUsername;
        private TableLayoutPanel tableLayoutPanelTable;
        private Panel pnlTableMenu;
        private Label lblTableMenu;
        private PictureBox pictureBoxTableMenu;
        private Panel pnlMenuMenu;
        private Label lblMenuMenu;
        private PictureBox pictureBoxMenuMenu;
    }
}