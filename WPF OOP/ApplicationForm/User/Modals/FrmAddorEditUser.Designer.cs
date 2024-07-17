namespace WPF_OOP.ApplicationForm.User.Modals
{
    partial class FrmAddorEditUser
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
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtuserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CboUserRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CboDepartment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(75, 67);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(147, 22);
            this.TxtFirstName.TabIndex = 0;
            this.TxtFirstName.TextChanged += new System.EventHandler(this.TxtFirstName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(306, 67);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(147, 22);
            this.TxtLastName.TabIndex = 2;
            this.TxtLastName.TextChanged += new System.EventHandler(this.TxtLastName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "UserName:";
            // 
            // TxtuserName
            // 
            this.TxtuserName.Location = new System.Drawing.Point(75, 132);
            this.TxtuserName.Name = "TxtuserName";
            this.TxtuserName.Size = new System.Drawing.Size(147, 22);
            this.TxtuserName.TabIndex = 4;
            this.TxtuserName.TextChanged += new System.EventHandler(this.TxtuserName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(306, 132);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(147, 22);
            this.TxtPassword.TabIndex = 6;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(405, 375);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 39);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(310, 484);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CboUserRole
            // 
            this.CboUserRole.FormattingEnabled = true;
            this.CboUserRole.Location = new System.Drawing.Point(75, 184);
            this.CboUserRole.Name = "CboUserRole";
            this.CboUserRole.Size = new System.Drawing.Size(147, 24);
            this.CboUserRole.TabIndex = 10;
            this.CboUserRole.SelectionChangeCommitted += new System.EventHandler(this.CboUserRole_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Role:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Department:";
            // 
            // CboDepartment
            // 
            this.CboDepartment.FormattingEnabled = true;
            this.CboDepartment.Location = new System.Drawing.Point(306, 184);
            this.CboDepartment.Name = "CboDepartment";
            this.CboDepartment.Size = new System.Drawing.Size(147, 24);
            this.CboDepartment.TabIndex = 12;
            this.CboDepartment.SelectionChangeCommitted += new System.EventHandler(this.CboDepartment_SelectionChangeCommitted);
            // 
            // FrmAddorEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(540, 616);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CboDepartment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CboUserRole);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtuserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFirstName);
            this.Name = "FrmAddorEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAddorEditUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddorEditUser_FormClosing);
            this.Load += new System.EventHandler(this.FrmAddorEditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtuserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CboUserRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboDepartment;
    }
}