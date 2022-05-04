namespace ISI.Window
{
    partial class MAS000RegisterForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richtextBoxAddress = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.textBoxFNAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNationID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPassWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCPassWord = new System.Windows.Forms.TextBox();
            this.btCF = new System.Windows.Forms.Button();
            this.bdsRegister = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdsRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(743, 52);
            this.label1.TabIndex = 14;
            this.label1.Text = "Register Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNO
            // 
            this.textBoxNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNO.Location = new System.Drawing.Point(305, 359);
            this.textBoxNO.MaxLength = 10;
            this.textBoxNO.Multiline = true;
            this.textBoxNO.Name = "textBoxNO";
            this.textBoxNO.Size = new System.Drawing.Size(323, 30);
            this.textBoxNO.TabIndex = 99;
            this.textBoxNO.TextChanged += new System.EventHandler(this.textBoxNO_TextChanged);
            this.textBoxNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNO_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(52, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 48);
            this.label6.TabIndex = 98;
            this.label6.Text = "Phone Numble :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEmail.Location = new System.Drawing.Point(305, 315);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(323, 30);
            this.textBoxEmail.TabIndex = 97;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(176, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 48);
            this.label5.TabIndex = 96;
            this.label5.Text = "Email :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richtextBoxAddress
            // 
            this.richtextBoxAddress.Location = new System.Drawing.Point(305, 224);
            this.richtextBoxAddress.MaxLength = 100;
            this.richtextBoxAddress.Name = "richtextBoxAddress";
            this.richtextBoxAddress.Size = new System.Drawing.Size(323, 70);
            this.richtextBoxAddress.TabIndex = 95;
            this.richtextBoxAddress.Text = "";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(136, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 48);
            this.label4.TabIndex = 94;
            this.label4.Text = "Address* :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLName
            // 
            this.textBoxLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxLName.Location = new System.Drawing.Point(305, 133);
            this.textBoxLName.MaxLength = 24;
            this.textBoxLName.Multiline = true;
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(323, 30);
            this.textBoxLName.TabIndex = 93;
            this.textBoxLName.TextChanged += new System.EventHandler(this.textBoxLName_TextChanged);
            // 
            // textBoxFNAME
            // 
            this.textBoxFNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxFNAME.Location = new System.Drawing.Point(305, 83);
            this.textBoxFNAME.MaxLength = 24;
            this.textBoxFNAME.Multiline = true;
            this.textBoxFNAME.Name = "textBoxFNAME";
            this.textBoxFNAME.Size = new System.Drawing.Size(323, 30);
            this.textBoxFNAME.TabIndex = 92;
            this.textBoxFNAME.TextChanged += new System.EventHandler(this.textBoxFNAME_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(86, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 37);
            this.label3.TabIndex = 91;
            this.label3.Text = "Last Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(105, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 48);
            this.label2.TabIndex = 90;
            this.label2.Text = "First Name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNationID
            // 
            this.textBoxNationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNationID.Location = new System.Drawing.Point(305, 179);
            this.textBoxNationID.MaxLength = 13;
            this.textBoxNationID.Multiline = true;
            this.textBoxNationID.Name = "textBoxNationID";
            this.textBoxNationID.Size = new System.Drawing.Size(323, 30);
            this.textBoxNationID.TabIndex = 102;
            this.textBoxNationID.TextChanged += new System.EventHandler(this.textBoxNationID_TextChanged);
            this.textBoxNationID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNationID_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(80, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 37);
            this.label8.TabIndex = 101;
            this.label8.Text = "National ID :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(146, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 48);
            this.label7.TabIndex = 103;
            this.label7.Text = "ID :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxID.Location = new System.Drawing.Point(305, 407);
            this.textBoxID.MaxLength = 20;
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(323, 30);
            this.textBoxID.TabIndex = 104;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(107, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 48);
            this.label9.TabIndex = 105;
            this.label9.Text = "Password :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPassWord.Location = new System.Drawing.Point(305, 455);
            this.textBoxPassWord.MaxLength = 20;
            this.textBoxPassWord.Multiline = true;
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.Size = new System.Drawing.Size(323, 30);
            this.textBoxPassWord.TabIndex = 106;
            this.textBoxPassWord.TextChanged += new System.EventHandler(this.textBoxPassWord_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(-47, 493);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(346, 48);
            this.label10.TabIndex = 107;
            this.label10.Text = "Confirm Password :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCPassWord
            // 
            this.textBoxCPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCPassWord.Location = new System.Drawing.Point(305, 505);
            this.textBoxCPassWord.MaxLength = 20;
            this.textBoxCPassWord.Multiline = true;
            this.textBoxCPassWord.Name = "textBoxCPassWord";
            this.textBoxCPassWord.Size = new System.Drawing.Size(323, 30);
            this.textBoxCPassWord.TabIndex = 108;
            this.textBoxCPassWord.TextChanged += new System.EventHandler(this.textBoxCPassWord_TextChanged);
            // 
            // btCF
            // 
            this.btCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btCF.Location = new System.Drawing.Point(360, 558);
            this.btCF.Name = "btCF";
            this.btCF.Size = new System.Drawing.Size(153, 36);
            this.btCF.TabIndex = 109;
            this.btCF.Text = "Confirm";
            this.btCF.UseVisualStyleBackColor = true;
            this.btCF.Click += new System.EventHandler(this.btCF_Click);
            // 
            // MAS000RegisterForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(743, 632);
            this.Controls.Add(this.btCF);
            this.Controls.Add(this.textBoxCPassWord);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPassWord);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxNationID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxNO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richtextBoxAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLName);
            this.Controls.Add(this.textBoxFNAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAS000RegisterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MAS000RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAS000RegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.MAS000RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richtextBoxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.TextBox textBoxFNAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNationID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPassWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCPassWord;
        private System.Windows.Forms.Button btCF;
        private System.Windows.Forms.BindingSource bdsRegister;
    }
}