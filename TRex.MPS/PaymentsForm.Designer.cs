namespace TRex.MPS
{
    partial class PaymentsForm
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
            this.EmployeeCheckedList = new System.Windows.Forms.CheckedListBox();
            this.SendPaymentCodes = new System.Windows.Forms.Button();
            this.MonthYearPaymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmployeeCheckedList
            // 
            this.EmployeeCheckedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeCheckedList.FormattingEnabled = true;
            this.EmployeeCheckedList.Location = new System.Drawing.Point(12, 48);
            this.EmployeeCheckedList.Name = "EmployeeCheckedList";
            this.EmployeeCheckedList.Size = new System.Drawing.Size(1219, 508);
            this.EmployeeCheckedList.TabIndex = 0;
            // 
            // SendPaymentCodes
            // 
            this.SendPaymentCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendPaymentCodes.Location = new System.Drawing.Point(1012, 579);
            this.SendPaymentCodes.Name = "SendPaymentCodes";
            this.SendPaymentCodes.Size = new System.Drawing.Size(219, 34);
            this.SendPaymentCodes.TabIndex = 1;
            this.SendPaymentCodes.Text = "Send Payment Codes";
            this.SendPaymentCodes.UseVisualStyleBackColor = true;
            this.SendPaymentCodes.Click += new System.EventHandler(this.SendPaymentCodes_Click);
            // 
            // MonthYearPaymentDateTimePicker
            // 
            this.MonthYearPaymentDateTimePicker.CustomFormat = "MM/yyyy";
            this.MonthYearPaymentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthYearPaymentDateTimePicker.Location = new System.Drawing.Point(195, 11);
            this.MonthYearPaymentDateTimePicker.MaxDate = DateTime.Now.Date.AddMonths(1);
            this.MonthYearPaymentDateTimePicker.Name = "MonthYearPaymentDateTimePicker";
            this.MonthYearPaymentDateTimePicker.Size = new System.Drawing.Size(212, 31);
            this.MonthYearPaymentDateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Month/Year Payment";
            // 
            // PaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MonthYearPaymentDateTimePicker);
            this.Controls.Add(this.SendPaymentCodes);
            this.Controls.Add(this.EmployeeCheckedList);
            this.Name = "PaymentsForm";
            this.Text = "PaymentsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox EmployeeCheckedList;
        private Button SendPaymentCodes;
        private DateTimePicker MonthYearPaymentDateTimePicker;
        private Label label1;
    }
}