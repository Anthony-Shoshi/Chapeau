namespace ChapeauUI.Components
{
    partial class KitchenWidgets
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
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            orderTimeLabel = new Label();
            tableNumberLabel = new Label();
            waitingTimeLabel = new Label();
            priorityLabel = new Label();
            labOrderSn = new Label();
            labBarmanName = new Label();
            labwaitername = new Label();
            orderTime = new Label();
            labWaitingTime = new Label();
            labTableName = new Label();
            panelButtom = new Panel();
            btnUpdate = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            panelButtom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTop.BackColor = SystemColors.ActiveCaptionText;
            panelTop.Controls.Add(orderTimeLabel);
            panelTop.Controls.Add(tableNumberLabel);
            panelTop.Controls.Add(waitingTimeLabel);
            panelTop.Controls.Add(priorityLabel);
            panelTop.Controls.Add(labOrderSn);
            panelTop.Controls.Add(labBarmanName);
            panelTop.Controls.Add(labwaitername);
            panelTop.Controls.Add(orderTime);
            panelTop.Controls.Add(labWaitingTime);
            panelTop.Controls.Add(labTableName);
            panelTop.Location = new Point(7, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(547, 110);
            panelTop.TabIndex = 0;
            // 
            // orderTimeLabel
            // 
            orderTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            orderTimeLabel.ForeColor = SystemColors.ControlLight;
            orderTimeLabel.Location = new Point(455, 9);
            orderTimeLabel.Name = "orderTimeLabel";
            orderTimeLabel.Size = new Size(91, 21);
            orderTimeLabel.TabIndex = 9;
            // 
            // tableNumberLabel
            // 
            tableNumberLabel.AutoSize = true;
            tableNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tableNumberLabel.ForeColor = SystemColors.ControlLight;
            tableNumberLabel.Location = new Point(53, 36);
            tableNumberLabel.Name = "tableNumberLabel";
            tableNumberLabel.Size = new Size(0, 21);
            tableNumberLabel.TabIndex = 8;
            // 
            // waitingTimeLabel
            // 
            waitingTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            waitingTimeLabel.ForeColor = SystemColors.ControlLight;
            waitingTimeLabel.Location = new Point(266, 9);
            waitingTimeLabel.Name = "waitingTimeLabel";
            waitingTimeLabel.Size = new Size(91, 21);
            waitingTimeLabel.TabIndex = 7;
            // 
            // priorityLabel
            // 
            priorityLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            priorityLabel.ForeColor = SystemColors.ControlLight;
            priorityLabel.Location = new Point(118, 4);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(38, 30);
            priorityLabel.TabIndex = 6;
            // 
            // labOrderSn
            // 
            labOrderSn.AutoSize = true;
            labOrderSn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labOrderSn.ForeColor = SystemColors.ButtonHighlight;
            labOrderSn.Location = new Point(2, 4);
            labOrderSn.Name = "labOrderSn";
            labOrderSn.Size = new Size(119, 21);
            labOrderSn.TabIndex = 5;
            labOrderSn.Text = "Order Priority #";
            // 
            // labBarmanName
            // 
            labBarmanName.AutoSize = true;
            labBarmanName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labBarmanName.ForeColor = SystemColors.ButtonHighlight;
            labBarmanName.Location = new Point(366, 39);
            labBarmanName.Name = "labBarmanName";
            labBarmanName.Size = new Size(50, 15);
            labBarmanName.TabIndex = 3;
            labBarmanName.Text = "Barman";
            // 
            // labwaitername
            // 
            labwaitername.AutoSize = true;
            labwaitername.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labwaitername.ForeColor = SystemColors.ButtonHighlight;
            labwaitername.Location = new Point(163, 39);
            labwaitername.Name = "labwaitername";
            labwaitername.Size = new Size(45, 15);
            labwaitername.TabIndex = 2;
            labwaitername.Text = "Waiter";
            // 
            // orderTime
            // 
            orderTime.AutoSize = true;
            orderTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            orderTime.ForeColor = SystemColors.ControlLightLight;
            orderTime.Location = new Point(366, 4);
            orderTime.Name = "orderTime";
            orderTime.Size = new Size(89, 21);
            orderTime.TabIndex = 1;
            orderTime.Text = "Order Time";
            // 
            // labWaitingTime
            // 
            labWaitingTime.AutoSize = true;
            labWaitingTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labWaitingTime.ForeColor = SystemColors.ControlLightLight;
            labWaitingTime.Location = new Point(162, 4);
            labWaitingTime.Name = "labWaitingTime";
            labWaitingTime.Size = new Size(101, 21);
            labWaitingTime.TabIndex = 1;
            labWaitingTime.Text = "Waiting Time";
            // 
            // labTableName
            // 
            labTableName.AutoSize = true;
            labTableName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labTableName.ForeColor = SystemColors.ControlLightLight;
            labTableName.Location = new Point(7, 39);
            labTableName.Name = "labTableName";
            labTableName.Size = new Size(36, 15);
            labTableName.TabIndex = 0;
            labTableName.Text = "Table";
            // 
            // panelButtom
            // 
            panelButtom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButtom.BackColor = SystemColors.HighlightText;
            panelButtom.Controls.Add(btnUpdate);
            panelButtom.Location = new Point(7, 56);
            panelButtom.Margin = new Padding(3, 2, 3, 2);
            panelButtom.Name = "panelButtom";
            panelButtom.Size = new Size(547, 390);
            panelButtom.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.HotTrack;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(201, 349);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(137, 38);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // KitchenWidgets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(panelButtom);
            Controls.Add(panelTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KitchenWidgets";
            Size = new Size(570, 454);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelButtom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Label labWaitingTime;
        private System.Windows.Forms.Label labTableName;
        private System.Windows.Forms.Label labBarmanName;
        private System.Windows.Forms.Label labwaitername;
        private System.Windows.Forms.Label labOrderSn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label orderTime;
        private Label priorityLabel;
        private Label waitingTimeLabel;
        private System.Windows.Forms.Timer timer1;
        private Label tableNumberLabel;
        private Label orderTimeLabel;
    }
}
