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
            imgLogo = new PictureBox();
            lblUsername = new Label();
            tableLayoutPanelTable = new TableLayoutPanel();
            pnlMenu = new Panel();
            lblOrderItems = new Label();
            pnlOrderItemList = new Panel();
            lblOrderTable = new Label();
            tabControlMenu = new TabControl();
            pnlMenuCrud = new Panel();
            lblMenuList = new Label();
            btnEditMenuItem = new Button();
            btnDeleteMenuItem = new Button();
            lblAddMenuPageHeading = new Label();
            pnlMenuList = new Panel();
            pnlMenuAddUpdate = new Panel();
            btnMenuItemUpdate = new Button();
            textBoxStock = new TextBox();
            label1 = new Label();
            btnAddMenu = new Button();
            comboBoxMenuType = new ComboBox();
            comboBoxMenuCategory = new ComboBox();
            radioButtonIsAlcoNo = new RadioButton();
            radioButtonIsAlcoYes = new RadioButton();
            textBoxMenuPrice = new TextBox();
            textBoxMenuItemName = new TextBox();
            lblMenuIsAlco = new Label();
            lblMenuType = new Label();
            lblMenuCat = new Label();
            lblMenuPrice = new Label();
            lblMenuName = new Label();
            topMenu.SuspendLayout();
            pnlMenuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMenuMenu).BeginInit();
            pnlTableMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTableMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            pnlMenu.SuspendLayout();
            pnlMenuCrud.SuspendLayout();
            pnlMenuAddUpdate.SuspendLayout();
            SuspendLayout();
            // 
            // topMenu
            // 
            topMenu.BackColor = Color.FromArgb(113, 161, 209);
            topMenu.Controls.Add(pnlMenuMenu);
            topMenu.Controls.Add(pnlTableMenu);
            topMenu.Controls.Add(imgLogo);
            topMenu.Controls.Add(lblUsername);
            topMenu.Dock = DockStyle.Top;
            topMenu.Location = new Point(0, 0);
            topMenu.Margin = new Padding(6);
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
            pnlMenuMenu.Margin = new Padding(6);
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
            lblMenuMenu.Click += lblMenuMenu_Click;
            // 
            // pictureBoxMenuMenu
            // 
            pictureBoxMenuMenu.Image = (Image)resources.GetObject("pictureBoxMenuMenu.Image");
            pictureBoxMenuMenu.Location = new Point(20, -2);
            pictureBoxMenuMenu.Margin = new Padding(6);
            pictureBoxMenuMenu.Name = "pictureBoxMenuMenu";
            pictureBoxMenuMenu.Size = new Size(72, 75);
            pictureBoxMenuMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMenuMenu.TabIndex = 0;
            pictureBoxMenuMenu.TabStop = false;
            pictureBoxMenuMenu.Click += pictureBoxMenuMenu_Click;
            // 
            // pnlTableMenu
            // 
            pnlTableMenu.BackColor = Color.FromArgb(192, 255, 255);
            pnlTableMenu.Controls.Add(lblTableMenu);
            pnlTableMenu.Controls.Add(pictureBoxTableMenu);
            pnlTableMenu.Location = new Point(253, 4);
            pnlTableMenu.Margin = new Padding(6);
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
            lblTableMenu.Click += lblTableMenu_Click;
            // 
            // pictureBoxTableMenu
            // 
            pictureBoxTableMenu.Image = (Image)resources.GetObject("pictureBoxTableMenu.Image");
            pictureBoxTableMenu.Location = new Point(20, 0);
            pictureBoxTableMenu.Margin = new Padding(6);
            pictureBoxTableMenu.Name = "pictureBoxTableMenu";
            pictureBoxTableMenu.Size = new Size(72, 75);
            pictureBoxTableMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTableMenu.TabIndex = 0;
            pictureBoxTableMenu.TabStop = false;
            pictureBoxTableMenu.Click += pictureBoxTableMenu_Click;
            // 
            // imgLogo
            // 
            imgLogo.BackgroundImage = Properties.Resources.logo;
            imgLogo.BackgroundImageLayout = ImageLayout.Zoom;
            imgLogo.Location = new Point(6, 4);
            imgLogo.Margin = new Padding(6);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(186, 107);
            imgLogo.TabIndex = 0;
            imgLogo.TabStop = false;
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
            // tableLayoutPanelTable
            // 
            tableLayoutPanelTable.AutoScroll = true;
            tableLayoutPanelTable.ColumnCount = 5;
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTable.Location = new Point(0, 190);
            tableLayoutPanelTable.Margin = new Padding(6);
            tableLayoutPanelTable.Name = "tableLayoutPanelTable";
            tableLayoutPanelTable.RowCount = 2;
            tableLayoutPanelTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelTable.Size = new Size(1486, 770);
            tableLayoutPanelTable.TabIndex = 2;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.White;
            pnlMenu.Controls.Add(lblOrderItems);
            pnlMenu.Controls.Add(pnlOrderItemList);
            pnlMenu.Controls.Add(lblOrderTable);
            pnlMenu.Controls.Add(tabControlMenu);
            pnlMenu.Location = new Point(0, 113);
            pnlMenu.Margin = new Padding(6);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(1486, 847);
            pnlMenu.TabIndex = 0;
            // 
            // lblOrderItems
            // 
            lblOrderItems.AutoSize = true;
            lblOrderItems.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrderItems.Location = new Point(966, 13);
            lblOrderItems.Margin = new Padding(6, 0, 6, 0);
            lblOrderItems.Name = "lblOrderItems";
            lblOrderItems.Size = new Size(249, 54);
            lblOrderItems.TabIndex = 3;
            lblOrderItems.Text = "Order Items";
            // 
            // pnlOrderItemList
            // 
            pnlOrderItemList.BorderStyle = BorderStyle.Fixed3D;
            pnlOrderItemList.Location = new Point(966, 79);
            pnlOrderItemList.Margin = new Padding(6);
            pnlOrderItemList.Name = "pnlOrderItemList";
            pnlOrderItemList.Size = new Size(494, 736);
            pnlOrderItemList.TabIndex = 2;
            // 
            // lblOrderTable
            // 
            lblOrderTable.AutoSize = true;
            lblOrderTable.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrderTable.Location = new Point(22, 11);
            lblOrderTable.Margin = new Padding(6, 0, 6, 0);
            lblOrderTable.Name = "lblOrderTable";
            lblOrderTable.Size = new Size(327, 54);
            lblOrderTable.TabIndex = 1;
            lblOrderTable.Text = "Order - Table 10";
            // 
            // tabControlMenu
            // 
            tabControlMenu.Location = new Point(22, 79);
            tabControlMenu.Margin = new Padding(6);
            tabControlMenu.Name = "tabControlMenu";
            tabControlMenu.SelectedIndex = 0;
            tabControlMenu.Size = new Size(932, 740);
            tabControlMenu.TabIndex = 0;
            // 
            // pnlMenuCrud
            // 
            pnlMenuCrud.BackColor = Color.LightGray;
            pnlMenuCrud.Controls.Add(lblMenuList);
            pnlMenuCrud.Controls.Add(btnEditMenuItem);
            pnlMenuCrud.Controls.Add(btnDeleteMenuItem);
            pnlMenuCrud.Controls.Add(lblAddMenuPageHeading);
            pnlMenuCrud.Controls.Add(pnlMenuList);
            pnlMenuCrud.Controls.Add(pnlMenuAddUpdate);
            pnlMenuCrud.Dock = DockStyle.Fill;
            pnlMenuCrud.Location = new Point(0, 0);
            pnlMenuCrud.Margin = new Padding(6);
            pnlMenuCrud.Name = "pnlMenuCrud";
            pnlMenuCrud.Size = new Size(1486, 960);
            pnlMenuCrud.TabIndex = 4;
            // 
            // lblMenuList
            // 
            lblMenuList.AutoSize = true;
            lblMenuList.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuList.Location = new Point(663, 124);
            lblMenuList.Margin = new Padding(6, 0, 6, 0);
            lblMenuList.Name = "lblMenuList";
            lblMenuList.Size = new Size(207, 54);
            lblMenuList.TabIndex = 3;
            lblMenuList.Text = "Menu List";
            // 
            // btnEditMenuItem
            // 
            btnEditMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            btnEditMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditMenuItem.ForeColor = SystemColors.ButtonFace;
            btnEditMenuItem.Location = new Point(663, 828);
            btnEditMenuItem.Margin = new Padding(6);
            btnEditMenuItem.Name = "btnEditMenuItem";
            btnEditMenuItem.Size = new Size(260, 85);
            btnEditMenuItem.TabIndex = 15;
            btnEditMenuItem.Text = "Edit";
            btnEditMenuItem.UseVisualStyleBackColor = false;
            btnEditMenuItem.Visible = false;
            btnEditMenuItem.Click += btnEditMenuItem_Click;
            // 
            // btnDeleteMenuItem
            // 
            btnDeleteMenuItem.BackColor = Color.FromArgb(192, 0, 0);
            btnDeleteMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteMenuItem.ForeColor = SystemColors.ButtonFace;
            btnDeleteMenuItem.Location = new Point(966, 828);
            btnDeleteMenuItem.Margin = new Padding(6);
            btnDeleteMenuItem.Name = "btnDeleteMenuItem";
            btnDeleteMenuItem.Size = new Size(260, 85);
            btnDeleteMenuItem.TabIndex = 14;
            btnDeleteMenuItem.Text = "Delete";
            btnDeleteMenuItem.UseVisualStyleBackColor = false;
            btnDeleteMenuItem.Visible = false;
            btnDeleteMenuItem.Click += btnDeleteMenuItem_Click;
            // 
            // lblAddMenuPageHeading
            // 
            lblAddMenuPageHeading.AutoSize = true;
            lblAddMenuPageHeading.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblAddMenuPageHeading.Location = new Point(20, 124);
            lblAddMenuPageHeading.Margin = new Padding(6, 0, 6, 0);
            lblAddMenuPageHeading.Name = "lblAddMenuPageHeading";
            lblAddMenuPageHeading.Size = new Size(220, 54);
            lblAddMenuPageHeading.TabIndex = 0;
            lblAddMenuPageHeading.Text = "Add Menu";
            // 
            // pnlMenuList
            // 
            pnlMenuList.Location = new Point(663, 209);
            pnlMenuList.Margin = new Padding(6);
            pnlMenuList.Name = "pnlMenuList";
            pnlMenuList.Size = new Size(791, 589);
            pnlMenuList.TabIndex = 2;
            // 
            // pnlMenuAddUpdate
            // 
            pnlMenuAddUpdate.BorderStyle = BorderStyle.Fixed3D;
            pnlMenuAddUpdate.Controls.Add(btnMenuItemUpdate);
            pnlMenuAddUpdate.Controls.Add(textBoxStock);
            pnlMenuAddUpdate.Controls.Add(label1);
            pnlMenuAddUpdate.Controls.Add(btnAddMenu);
            pnlMenuAddUpdate.Controls.Add(comboBoxMenuType);
            pnlMenuAddUpdate.Controls.Add(comboBoxMenuCategory);
            pnlMenuAddUpdate.Controls.Add(radioButtonIsAlcoNo);
            pnlMenuAddUpdate.Controls.Add(radioButtonIsAlcoYes);
            pnlMenuAddUpdate.Controls.Add(textBoxMenuPrice);
            pnlMenuAddUpdate.Controls.Add(textBoxMenuItemName);
            pnlMenuAddUpdate.Controls.Add(lblMenuIsAlco);
            pnlMenuAddUpdate.Controls.Add(lblMenuType);
            pnlMenuAddUpdate.Controls.Add(lblMenuCat);
            pnlMenuAddUpdate.Controls.Add(lblMenuPrice);
            pnlMenuAddUpdate.Controls.Add(lblMenuName);
            pnlMenuAddUpdate.Location = new Point(22, 209);
            pnlMenuAddUpdate.Margin = new Padding(6);
            pnlMenuAddUpdate.Name = "pnlMenuAddUpdate";
            pnlMenuAddUpdate.Size = new Size(576, 699);
            pnlMenuAddUpdate.TabIndex = 1;
            // 
            // btnMenuItemUpdate
            // 
            btnMenuItemUpdate.BackColor = Color.FromArgb(113, 161, 209);
            btnMenuItemUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuItemUpdate.Location = new Point(32, 557);
            btnMenuItemUpdate.Margin = new Padding(6);
            btnMenuItemUpdate.Name = "btnMenuItemUpdate";
            btnMenuItemUpdate.Size = new Size(490, 105);
            btnMenuItemUpdate.TabIndex = 14;
            btnMenuItemUpdate.Text = "Update";
            btnMenuItemUpdate.UseVisualStyleBackColor = false;
            btnMenuItemUpdate.Click += btnMenuItemUpdate_Click;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(251, 378);
            textBoxStock.Margin = new Padding(0);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(268, 39);
            textBoxStock.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(32, 378);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(102, 45);
            label1.TabIndex = 12;
            label1.Text = "Stock";
            // 
            // btnAddMenu
            // 
            btnAddMenu.BackColor = Color.FromArgb(113, 161, 209);
            btnAddMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddMenu.Location = new Point(32, 557);
            btnAddMenu.Margin = new Padding(6);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.Size = new Size(490, 105);
            btnAddMenu.TabIndex = 11;
            btnAddMenu.Text = "Add";
            btnAddMenu.UseVisualStyleBackColor = false;
            btnAddMenu.Click += btnAddMenu_Click;
            // 
            // comboBoxMenuType
            // 
            comboBoxMenuType.FormattingEnabled = true;
            comboBoxMenuType.Location = new Point(251, 292);
            comboBoxMenuType.Margin = new Padding(0);
            comboBoxMenuType.Name = "comboBoxMenuType";
            comboBoxMenuType.Size = new Size(268, 40);
            comboBoxMenuType.TabIndex = 10;
            // 
            // comboBoxMenuCategory
            // 
            comboBoxMenuCategory.FormattingEnabled = true;
            comboBoxMenuCategory.Location = new Point(251, 205);
            comboBoxMenuCategory.Margin = new Padding(0);
            comboBoxMenuCategory.Name = "comboBoxMenuCategory";
            comboBoxMenuCategory.Size = new Size(268, 40);
            comboBoxMenuCategory.TabIndex = 9;
            // 
            // radioButtonIsAlcoNo
            // 
            radioButtonIsAlcoNo.AutoSize = true;
            radioButtonIsAlcoNo.Checked = true;
            radioButtonIsAlcoNo.Location = new Point(340, 463);
            radioButtonIsAlcoNo.Margin = new Padding(0);
            radioButtonIsAlcoNo.Name = "radioButtonIsAlcoNo";
            radioButtonIsAlcoNo.Size = new Size(77, 36);
            radioButtonIsAlcoNo.TabIndex = 8;
            radioButtonIsAlcoNo.TabStop = true;
            radioButtonIsAlcoNo.Text = "No";
            radioButtonIsAlcoNo.UseVisualStyleBackColor = true;
            radioButtonIsAlcoNo.CheckedChanged += radioButtonIsAlcoNo_CheckedChanged;
            // 
            // radioButtonIsAlcoYes
            // 
            radioButtonIsAlcoYes.AutoSize = true;
            radioButtonIsAlcoYes.Location = new Point(251, 463);
            radioButtonIsAlcoYes.Margin = new Padding(0);
            radioButtonIsAlcoYes.Name = "radioButtonIsAlcoYes";
            radioButtonIsAlcoYes.Size = new Size(79, 36);
            radioButtonIsAlcoYes.TabIndex = 7;
            radioButtonIsAlcoYes.Text = "Yes";
            radioButtonIsAlcoYes.UseVisualStyleBackColor = true;
            radioButtonIsAlcoYes.CheckedChanged += radioButtonIsAlcoYes_CheckedChanged;
            // 
            // textBoxMenuPrice
            // 
            textBoxMenuPrice.Location = new Point(251, 117);
            textBoxMenuPrice.Margin = new Padding(0);
            textBoxMenuPrice.Name = "textBoxMenuPrice";
            textBoxMenuPrice.Size = new Size(268, 39);
            textBoxMenuPrice.TabIndex = 6;
            // 
            // textBoxMenuItemName
            // 
            textBoxMenuItemName.Location = new Point(251, 32);
            textBoxMenuItemName.Margin = new Padding(0);
            textBoxMenuItemName.Name = "textBoxMenuItemName";
            textBoxMenuItemName.Size = new Size(268, 39);
            textBoxMenuItemName.TabIndex = 5;
            // 
            // lblMenuIsAlco
            // 
            lblMenuIsAlco.AutoSize = true;
            lblMenuIsAlco.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuIsAlco.Location = new Point(32, 463);
            lblMenuIsAlco.Margin = new Padding(0);
            lblMenuIsAlco.Name = "lblMenuIsAlco";
            lblMenuIsAlco.Size = new Size(206, 45);
            lblMenuIsAlco.TabIndex = 4;
            lblMenuIsAlco.Text = "Is Alcoholic?";
            // 
            // lblMenuType
            // 
            lblMenuType.AutoSize = true;
            lblMenuType.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuType.Location = new Point(32, 288);
            lblMenuType.Margin = new Padding(0);
            lblMenuType.Name = "lblMenuType";
            lblMenuType.Size = new Size(92, 45);
            lblMenuType.TabIndex = 3;
            lblMenuType.Text = "Type";
            // 
            // lblMenuCat
            // 
            lblMenuCat.AutoSize = true;
            lblMenuCat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuCat.Location = new Point(32, 201);
            lblMenuCat.Margin = new Padding(0);
            lblMenuCat.Name = "lblMenuCat";
            lblMenuCat.Size = new Size(157, 45);
            lblMenuCat.TabIndex = 2;
            lblMenuCat.Text = "Category";
            // 
            // lblMenuPrice
            // 
            lblMenuPrice.AutoSize = true;
            lblMenuPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuPrice.Location = new Point(32, 117);
            lblMenuPrice.Margin = new Padding(0);
            lblMenuPrice.Name = "lblMenuPrice";
            lblMenuPrice.Size = new Size(94, 45);
            lblMenuPrice.TabIndex = 1;
            lblMenuPrice.Text = "Price";
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenuName.Location = new Point(32, 32);
            lblMenuName.Margin = new Padding(0);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(185, 45);
            lblMenuName.TabIndex = 0;
            lblMenuName.Text = "Item Name";
            // 
            // WaiterView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(topMenu);
            Controls.Add(pnlMenuCrud);
            Controls.Add(tableLayoutPanelTable);
            Controls.Add(pnlMenu);
            Margin = new Padding(6);
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
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlMenuCrud.ResumeLayout(false);
            pnlMenuCrud.PerformLayout();
            pnlMenuAddUpdate.ResumeLayout(false);
            pnlMenuAddUpdate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel topMenu;
        private PictureBox imgLogo;
        private Label lblUsername;
        private TableLayoutPanel tableLayoutPanelTable;
        private Panel pnlMenu;
        private TabControl tabControlMenu;
        private Panel pnlTableMenu;
        private Label lblTableMenu;
        private PictureBox pictureBoxTableMenu;
        private Panel pnlMenuMenu;
        private Label lblMenuMenu;
        private PictureBox pictureBoxMenuMenu;
        private Panel pnlMenuCrud;
        private Label lblAddMenuPageHeading;
        private Panel pnlMenuAddUpdate;
        private RadioButton radioButtonIsAlcoNo;
        private RadioButton radioButtonIsAlcoYes;
        private TextBox textBoxMenuPrice;
        private TextBox textBoxMenuItemName;
        private Label lblMenuIsAlco;
        private Label lblMenuType;
        private Label lblMenuCat;
        private Label lblMenuPrice;
        private Label lblMenuName;
        private Button btnAddMenu;
        private ComboBox comboBoxMenuType;
        private ComboBox comboBoxMenuCategory;
        private Panel pnlMenuList;
        private Label lblMenuList;
        private TextBox textBoxStock;
        private Label label1;
        private Button btnDeleteMenuItem;
        private Button btnEditMenuItem;
        private Button btnMenuItemUpdate;
        private Label lblOrderTable;
        private Label lblOrderItems;
        private Panel pnlOrderItemList;
    }
}