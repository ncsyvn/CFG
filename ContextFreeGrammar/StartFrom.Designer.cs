namespace ContextFreeGrammar
{
    partial class StartFrom
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStandardized = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.Chomsky = new System.Windows.Forms.Button();
            this.panelChomsky = new System.Windows.Forms.Panel();
            this.textBoxStep1ChomskyNew = new System.Windows.Forms.TextBox();
            this.textBoxStep1ChomskyOld = new System.Windows.Forms.TextBox();
            this.textBoxStep2ChomskyNew = new System.Windows.Forms.TextBox();
            this.textBoxStep2ChomskyOld = new System.Windows.Forms.TextBox();
            this.textBoxStep3ChomskyNew = new System.Windows.Forms.TextBox();
            this.textBoxStep3ChomskyOld = new System.Windows.Forms.TextBox();
            this.labelStep3Chomsky = new System.Windows.Forms.Label();
            this.labelStep2Chomsky = new System.Windows.Forms.Label();
            this.labelStep1Chomsky = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Greibach = new System.Windows.Forms.Button();
            this.panelChomsky.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(86, 37);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(322, 120);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input CFG";
            // 
            // textBoxStandardized
            // 
            this.textBoxStandardized.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStandardized.Location = new System.Drawing.Point(86, 207);
            this.textBoxStandardized.Multiline = true;
            this.textBoxStandardized.Name = "textBoxStandardized";
            this.textBoxStandardized.ReadOnly = true;
            this.textBoxStandardized.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStandardized.Size = new System.Drawing.Size(322, 120);
            this.textBoxStandardized.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Standardized";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(86, 173);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(239, 20);
            this.textBoxFilePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Path";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(346, 173);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(62, 23);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Location = new System.Drawing.Point(116, 342);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(75, 23);
            this.buttonMin.TabIndex = 8;
            this.buttonMin.Text = "Min";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // Chomsky
            // 
            this.Chomsky.Location = new System.Drawing.Point(216, 342);
            this.Chomsky.Name = "Chomsky";
            this.Chomsky.Size = new System.Drawing.Size(75, 23);
            this.Chomsky.TabIndex = 9;
            this.Chomsky.Text = "Chomsky";
            this.Chomsky.UseVisualStyleBackColor = true;
            this.Chomsky.Click += new System.EventHandler(this.Chomsky_Click);
            // 
            // panelChomsky
            // 
            this.panelChomsky.BackColor = System.Drawing.Color.PeachPuff;
            this.panelChomsky.Controls.Add(this.label14);
            this.panelChomsky.Controls.Add(this.label13);
            this.panelChomsky.Controls.Add(this.label12);
            this.panelChomsky.Controls.Add(this.label11);
            this.panelChomsky.Controls.Add(this.label10);
            this.panelChomsky.Controls.Add(this.label9);
            this.panelChomsky.Controls.Add(this.label8);
            this.panelChomsky.Controls.Add(this.label6);
            this.panelChomsky.Controls.Add(this.label5);
            this.panelChomsky.Controls.Add(this.label4);
            this.panelChomsky.Controls.Add(this.labelStep1Chomsky);
            this.panelChomsky.Controls.Add(this.labelStep2Chomsky);
            this.panelChomsky.Controls.Add(this.labelStep3Chomsky);
            this.panelChomsky.Controls.Add(this.textBoxStep3ChomskyOld);
            this.panelChomsky.Controls.Add(this.textBoxStep3ChomskyNew);
            this.panelChomsky.Controls.Add(this.textBoxStep2ChomskyOld);
            this.panelChomsky.Controls.Add(this.textBoxStep2ChomskyNew);
            this.panelChomsky.Controls.Add(this.textBoxStep1ChomskyOld);
            this.panelChomsky.Controls.Add(this.textBoxStep1ChomskyNew);
            this.panelChomsky.Location = new System.Drawing.Point(514, 18);
            this.panelChomsky.Name = "panelChomsky";
            this.panelChomsky.Size = new System.Drawing.Size(427, 378);
            this.panelChomsky.TabIndex = 10;
            // 
            // textBoxStep1ChomskyNew
            // 
            this.textBoxStep1ChomskyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep1ChomskyNew.Location = new System.Drawing.Point(103, 61);
            this.textBoxStep1ChomskyNew.Multiline = true;
            this.textBoxStep1ChomskyNew.Name = "textBoxStep1ChomskyNew";
            this.textBoxStep1ChomskyNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep1ChomskyNew.Size = new System.Drawing.Size(128, 64);
            this.textBoxStep1ChomskyNew.TabIndex = 0;
            // 
            // textBoxStep1ChomskyOld
            // 
            this.textBoxStep1ChomskyOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep1ChomskyOld.Location = new System.Drawing.Point(279, 61);
            this.textBoxStep1ChomskyOld.Multiline = true;
            this.textBoxStep1ChomskyOld.Name = "textBoxStep1ChomskyOld";
            this.textBoxStep1ChomskyOld.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep1ChomskyOld.Size = new System.Drawing.Size(132, 64);
            this.textBoxStep1ChomskyOld.TabIndex = 1;
            // 
            // textBoxStep2ChomskyNew
            // 
            this.textBoxStep2ChomskyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep2ChomskyNew.Location = new System.Drawing.Point(103, 141);
            this.textBoxStep2ChomskyNew.Multiline = true;
            this.textBoxStep2ChomskyNew.Name = "textBoxStep2ChomskyNew";
            this.textBoxStep2ChomskyNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep2ChomskyNew.Size = new System.Drawing.Size(128, 93);
            this.textBoxStep2ChomskyNew.TabIndex = 2;
            // 
            // textBoxStep2ChomskyOld
            // 
            this.textBoxStep2ChomskyOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep2ChomskyOld.Location = new System.Drawing.Point(280, 141);
            this.textBoxStep2ChomskyOld.Multiline = true;
            this.textBoxStep2ChomskyOld.Name = "textBoxStep2ChomskyOld";
            this.textBoxStep2ChomskyOld.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep2ChomskyOld.Size = new System.Drawing.Size(128, 93);
            this.textBoxStep2ChomskyOld.TabIndex = 3;
            // 
            // textBoxStep3ChomskyNew
            // 
            this.textBoxStep3ChomskyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep3ChomskyNew.Location = new System.Drawing.Point(103, 252);
            this.textBoxStep3ChomskyNew.Multiline = true;
            this.textBoxStep3ChomskyNew.Name = "textBoxStep3ChomskyNew";
            this.textBoxStep3ChomskyNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep3ChomskyNew.Size = new System.Drawing.Size(128, 111);
            this.textBoxStep3ChomskyNew.TabIndex = 4;
            // 
            // textBoxStep3ChomskyOld
            // 
            this.textBoxStep3ChomskyOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep3ChomskyOld.Location = new System.Drawing.Point(280, 253);
            this.textBoxStep3ChomskyOld.Multiline = true;
            this.textBoxStep3ChomskyOld.Name = "textBoxStep3ChomskyOld";
            this.textBoxStep3ChomskyOld.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStep3ChomskyOld.Size = new System.Drawing.Size(128, 110);
            this.textBoxStep3ChomskyOld.TabIndex = 5;
            // 
            // labelStep3Chomsky
            // 
            this.labelStep3Chomsky.AutoSize = true;
            this.labelStep3Chomsky.Location = new System.Drawing.Point(34, 266);
            this.labelStep3Chomsky.Name = "labelStep3Chomsky";
            this.labelStep3Chomsky.Size = new System.Drawing.Size(41, 13);
            this.labelStep3Chomsky.TabIndex = 6;
            this.labelStep3Chomsky.Text = "Bước 3";
            // 
            // labelStep2Chomsky
            // 
            this.labelStep2Chomsky.AutoSize = true;
            this.labelStep2Chomsky.Location = new System.Drawing.Point(34, 164);
            this.labelStep2Chomsky.Name = "labelStep2Chomsky";
            this.labelStep2Chomsky.Size = new System.Drawing.Size(41, 13);
            this.labelStep2Chomsky.TabIndex = 7;
            this.labelStep2Chomsky.Text = "Bước 2";
            // 
            // labelStep1Chomsky
            // 
            this.labelStep1Chomsky.AutoSize = true;
            this.labelStep1Chomsky.Location = new System.Drawing.Point(32, 59);
            this.labelStep1Chomsky.Name = "labelStep1Chomsky";
            this.labelStep1Chomsky.Size = new System.Drawing.Size(41, 13);
            this.labelStep1Chomsky.TabIndex = 8;
            this.labelStep1Chomsky.Text = "Bước 1";
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.PeachPuff;
            this.panelInput.Controls.Add(this.Greibach);
            this.panelInput.Controls.Add(this.label7);
            this.panelInput.Controls.Add(this.textBoxInput);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.Chomsky);
            this.panelInput.Controls.Add(this.textBoxStandardized);
            this.panelInput.Controls.Add(this.buttonMin);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.buttonOpenFile);
            this.panelInput.Controls.Add(this.textBoxFilePath);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Location = new System.Drawing.Point(32, 19);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(431, 377);
            this.panelInput.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "L(G\')";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "L(G)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(192, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Chomsky";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(185, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Input";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Đưa vào L(G\')";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "những suy dẫn";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "đã thỏa mãn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Xử lý các kí hiệu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "kết thúc";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Rút gọn về dạng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "A->BC";
            // 
            // Greibach
            // 
            this.Greibach.Location = new System.Drawing.Point(311, 343);
            this.Greibach.Name = "Greibach";
            this.Greibach.Size = new System.Drawing.Size(75, 23);
            this.Greibach.TabIndex = 13;
            this.Greibach.Text = "Greibach";
            this.Greibach.UseVisualStyleBackColor = true;
            // 
            // StartFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 708);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelChomsky);
            this.Name = "StartFrom";
            this.panelChomsky.ResumeLayout(false);
            this.panelChomsky.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStandardized;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button Chomsky;
        private System.Windows.Forms.Panel panelChomsky;
        private System.Windows.Forms.Label labelStep1Chomsky;
        private System.Windows.Forms.Label labelStep2Chomsky;
        private System.Windows.Forms.Label labelStep3Chomsky;
        private System.Windows.Forms.TextBox textBoxStep3ChomskyOld;
        private System.Windows.Forms.TextBox textBoxStep3ChomskyNew;
        private System.Windows.Forms.TextBox textBoxStep2ChomskyOld;
        private System.Windows.Forms.TextBox textBoxStep2ChomskyNew;
        private System.Windows.Forms.TextBox textBoxStep1ChomskyOld;
        private System.Windows.Forms.TextBox textBoxStep1ChomskyNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Greibach;
    }
}

