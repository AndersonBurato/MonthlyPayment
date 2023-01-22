namespace TRex.MPS
{
    partial class ClaimSalaryForm
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
            this.CodeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClaimButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CodeText
            // 
            this.CodeText.Location = new System.Drawing.Point(72, 35);
            this.CodeText.Name = "CodeText";
            this.CodeText.Size = new System.Drawing.Size(250, 31);
            this.CodeText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code";
            // 
            // ClaimButton
            // 
            this.ClaimButton.Location = new System.Drawing.Point(210, 87);
            this.ClaimButton.Name = "ClaimButton";
            this.ClaimButton.Size = new System.Drawing.Size(112, 34);
            this.ClaimButton.TabIndex = 2;
            this.ClaimButton.Text = "Claim";
            this.ClaimButton.UseVisualStyleBackColor = true;
            this.ClaimButton.Click += new System.EventHandler(this.ClaimButton_Click);
            // 
            // ClaimSalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 137);
            this.Controls.Add(this.ClaimButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CodeText);
            this.Name = "ClaimSalaryForm";
            this.Text = "Claim Salary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox CodeText;
        private Label label1;
        private Button ClaimButton;
    }
}