namespace VendorMaintenance
{
    partial class frmAddModifyState
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFirstZip = new System.Windows.Forms.TextBox();
            this.txtLastZip = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFirstZip = new System.Windows.Forms.Label();
            this.lblLastZip = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtFirstZip
            // 
            this.txtFirstZip.Location = new System.Drawing.Point(124, 72);
            this.txtFirstZip.Name = "txtFirstZip";
            this.txtFirstZip.Size = new System.Drawing.Size(100, 20);
            this.txtFirstZip.TabIndex = 2;
            // 
            // txtLastZip
            // 
            this.txtLastZip.Location = new System.Drawing.Point(124, 98);
            this.txtLastZip.Name = "txtLastZip";
            this.txtLastZip.Size = new System.Drawing.Size(100, 20);
            this.txtLastZip.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(58, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 13);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "State Code";
        
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(58, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "State Name";
            // 
            // lblFirstZip
            // 
            this.lblFirstZip.AutoSize = true;
            this.lblFirstZip.Location = new System.Drawing.Point(21, 72);
            this.lblFirstZip.Name = "lblFirstZip";
            this.lblFirstZip.Size = new System.Drawing.Size(100, 13);
            this.lblFirstZip.TabIndex = 6;
            this.lblFirstZip.Text = "State First Zip Code";
            // 
            // lblLastZip
            // 
            this.lblLastZip.AutoSize = true;
            this.lblLastZip.Location = new System.Drawing.Point(21, 98);
            this.lblLastZip.Name = "lblLastZip";
            this.lblLastZip.Size = new System.Drawing.Size(101, 13);
            this.lblLastZip.TabIndex = 7;
            this.lblLastZip.Text = "State Last Zip Code";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(12, 145);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmAddModifyState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblLastZip);
            this.Controls.Add(this.lblFirstZip);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtLastZip);
            this.Controls.Add(this.txtFirstZip);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Name = "frmAddModifyState";
            this.Text = "frmAddModifyState";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFirstZip;
        private System.Windows.Forms.TextBox txtLastZip;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFirstZip;
        private System.Windows.Forms.Label lblLastZip;
        private System.Windows.Forms.Button btnAccept;
    }
}