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
            listView1 = new System.Windows.Forms.ListView();
            orderId = new System.Windows.Forms.ColumnHeader();
            employeeName = new System.Windows.Forms.ColumnHeader();
            tableNumber = new System.Windows.Forms.ColumnHeader();
            tableStatus = new System.Windows.Forms.ColumnHeader();
            orderStatus = new System.Windows.Forms.ColumnHeader();
            orderPlacedTime = new System.Windows.Forms.ColumnHeader();
            itemQuantity = new System.Windows.Forms.ColumnHeader();
            note = new System.Windows.Forms.ColumnHeader();
            unitPrice = new System.Windows.Forms.ColumnHeader();
            menuItemName = new System.Windows.Forms.ColumnHeader();
            price = new System.Windows.Forms.ColumnHeader();
            menuType = new System.Windows.Forms.ColumnHeader();
            categoryName = new System.Windows.Forms.ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { orderId, employeeName, tableNumber, tableStatus, orderStatus, orderPlacedTime, itemQuantity, note, unitPrice, menuItemName, price, menuType, categoryName });
            listView1.Location = new System.Drawing.Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(776, 426);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // orderId
            // 
            orderId.Text = "Order Id";
            orderId.Width = 200;
            // 
            // employeeName
            // 
            employeeName.Text = "EmployeeName";
            // 
            // tableNumber
            // 
            tableNumber.Text = "Table Number";
            // 
            // tableStatus
            // 
            tableStatus.DisplayIndex = 12;
            tableStatus.Text = "Table Status";
            // 
            // orderStatus
            // 
            orderStatus.DisplayIndex = 3;
            orderStatus.Text = "Order Status";
            // 
            // orderPlacedTime
            // 
            orderPlacedTime.DisplayIndex = 4;
            orderPlacedTime.Text = "Order Placed Time";
            // 
            // itemQuantity
            // 
            itemQuantity.DisplayIndex = 5;
            itemQuantity.Text = "Item Quantity";
            // 
            // note
            // 
            note.DisplayIndex = 6;
            note.Text = "Note";
            // 
            // unitPrice
            // 
            unitPrice.DisplayIndex = 7;
            unitPrice.Text = "Unit Price";
            // 
            // menuItemName
            // 
            menuItemName.DisplayIndex = 8;
            menuItemName.Text = "Menu Item Name";
            // 
            // price
            // 
            price.DisplayIndex = 9;
            price.Text = "Price";
            // 
            // menuType
            // 
            menuType.DisplayIndex = 10;
            menuType.Text = "menuType";
            // 
            // categoryName
            // 
            categoryName.DisplayIndex = 11;
            categoryName.Text = "Category Name";
            // 
            // KitchenView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(listView1);
            Name = "KitchenView";
            Text = "KitchenView";
            Load += KitchenView_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader orderId;
        private System.Windows.Forms.ColumnHeader employeeName;
        private System.Windows.Forms.ColumnHeader tableNumber;
        private System.Windows.Forms.ColumnHeader tableStatus;
        private System.Windows.Forms.ColumnHeader orderStatus;
        private System.Windows.Forms.ColumnHeader orderPlacedTime;
        private System.Windows.Forms.ColumnHeader itemQuantity;
        private System.Windows.Forms.ColumnHeader note;
        private System.Windows.Forms.ColumnHeader unitPrice;
        private System.Windows.Forms.ColumnHeader menuItemName;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader menuType;
        private System.Windows.Forms.ColumnHeader categoryName;
    }
}