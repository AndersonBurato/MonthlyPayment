namespace TRex.MPS
{
    partial class ClaimedPaymentForm
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
            this.ClaimedPaymentslistBox = new System.Windows.Forms.ListBox();
            this.PaymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ClaimedPaymentslistBox
            // 
            this.ClaimedPaymentslistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClaimedPaymentslistBox.FormattingEnabled = true;
            this.ClaimedPaymentslistBox.ItemHeight = 25;
            this.ClaimedPaymentslistBox.Location = new System.Drawing.Point(12, 49);
            this.ClaimedPaymentslistBox.Name = "ClaimedPaymentslistBox";
            this.ClaimedPaymentslistBox.Size = new System.Drawing.Size(943, 529);
            this.ClaimedPaymentslistBox.TabIndex = 0;
            // 
            // PaymentDateTimePicker
            // 
            this.PaymentDateTimePicker.CustomFormat = "MM/yyyy";
            this.PaymentDateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.PaymentDateTimePicker.Name = "PaymentDateTimePicker";
            this.PaymentDateTimePicker.Size = new System.Drawing.Size(300, 31);
            this.PaymentDateTimePicker.TabIndex = 1;
            this.PaymentDateTimePicker.ValueChanged += new System.EventHandler(this.PaymentDateTimePicker_ValueChanged);
            // 
            // ClaimedPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 605);
            this.Controls.Add(this.PaymentDateTimePicker);
            this.Controls.Add(this.ClaimedPaymentslistBox);
            this.Name = "ClaimedPaymentForm";
            this.Text = "GeneratedCodesForm";
            this.Load += new System.EventHandler(this.ClaimedPaymentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox ClaimedPaymentslistBox;
        private DateTimePicker PaymentDateTimePicker;
    }
}