namespace VendorMaintenance
{
    partial class frmState
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
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFirstZip = new System.Windows.Forms.Label();
            this.lblLastZip = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastZip = new System.Windows.Forms.TextBox();
            this.txtFirstZip = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnGetState = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(27, 17);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "State Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "State Name";
            // 
            // lblFirstZip
            // 
            this.lblFirstZip.AutoSize = true;
            this.lblFirstZip.Location = new System.Drawing.Point(27, 83);
            this.lblFirstZip.Name = "lblFirstZip";
            this.lblFirstZip.Size = new System.Drawing.Size(72, 13);
            this.lblFirstZip.TabIndex = 2;
            this.lblFirstZip.Text = "First Zip Code";
            // 
            // lblLastZip
            // 
            this.lblLastZip.AutoSize = true;
            this.lblLastZip.Location = new System.Drawing.Point(26, 115);
            this.lblLastZip.Name = "lblLastZip";
            this.lblLastZip.Size = new System.Drawing.Size(73, 13);
            this.lblLastZip.TabIndex = 3;
            this.lblLastZip.Text = "Last Zip Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(142, 17);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(142, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtLastZip
            // 
            this.txtLastZip.Location = new System.Drawing.Point(142, 112);
            this.txtLastZip.Name = "txtLastZip";
            this.txtLastZip.Size = new System.Drawing.Size(100, 20);
            this.txtLastZip.TabIndex = 6;
            // 
            // txtFirstZip
            // 
            this.txtFirstZip.Location = new System.Drawing.Point(142, 83);
            this.txtFirstZip.Name = "txtFirstZip";
            this.txtFirstZip.Size = new System.Drawing.Size(100, 20);
            this.txtFirstZip.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 162);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Enabled = false;
            this.btnModify.Location = new System.Drawing.Point(112, 162);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnGetState
            // 
            this.btnGetState.Location = new System.Drawing.Point(252, 17);
            this.btnGetState.Name = "btnGetState";
            this.btnGetState.Size = new System.Drawing.Size(75, 23);
            this.btnGetState.TabIndex = 10;
            this.btnGetState.Text = "Get State";
            this.btnGetState.UseVisualStyleBackColor = true;
            this.btnGetState.Click += new System.EventHandler(this.btnGetState_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(213, 162);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 261);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGetState);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFirstZip);
            this.Controls.Add(this.txtLastZip);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblLastZip);
            this.Controls.Add(this.lblFirstZip);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Name = "frmState";
            this.Text = "frmState";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFirstZip;
        private System.Windows.Forms.Label lblLastZip;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastZip;
        private System.Windows.Forms.TextBox txtFirstZip;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnGetState;
        private System.Windows.Forms.Button btnClear;
    }
}