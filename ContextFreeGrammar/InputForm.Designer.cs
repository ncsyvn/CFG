namespace ContextFreeGrammar
{
    partial class InputForm
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.buttonSimplify = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxStandardized = new System.Windows.Forms.TextBox();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInput.BackgroundImage = global::ContextFreeGrammar.Properties.Resources._0;
            this.panelInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInput.Controls.Add(this.buttonSimplify);
            this.panelInput.Controls.Add(this.pictureBox2);
            this.panelInput.Controls.Add(this.pictureBox1);
            this.panelInput.Controls.Add(this.textBoxInput);
            this.panelInput.Controls.Add(this.buttonOpenFile);
            this.panelInput.Controls.Add(this.textBoxStandardized);
            this.panelInput.Controls.Add(this.textBoxFilePath);
            this.panelInput.Location = new System.Drawing.Point(4, 2);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(487, 398);
            this.panelInput.TabIndex = 12;
            // 
            // buttonSimplify
            // 
            this.buttonSimplify.BackColor = System.Drawing.Color.Lime;
            this.buttonSimplify.Location = new System.Drawing.Point(193, 364);
            this.buttonSimplify.Name = "buttonSimplify";
            this.buttonSimplify.Size = new System.Drawing.Size(75, 23);
            this.buttonSimplify.TabIndex = 15;
            this.buttonSimplify.Text = "Simplify";
            this.buttonSimplify.UseVisualStyleBackColor = false;
            this.buttonSimplify.Click += new System.EventHandler(this.buttonSimplify_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::ContextFreeGrammar.Properties.Resources._3;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(83, 203);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 31);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ContextFreeGrammar.Properties.Resources._4;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(83, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 25);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxInput
            // 
            this.textBoxInput.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInput.Location = new System.Drawing.Point(83, 45);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(322, 120);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.Lime;
            this.buttonOpenFile.Location = new System.Drawing.Point(343, 176);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(62, 23);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxStandardized
            // 
            this.textBoxStandardized.BackColor = System.Drawing.Color.SpringGreen;
            this.textBoxStandardized.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStandardized.Location = new System.Drawing.Point(83, 233);
            this.textBoxStandardized.Multiline = true;
            this.textBoxStandardized.Name = "textBoxStandardized";
            this.textBoxStandardized.ReadOnly = true;
            this.textBoxStandardized.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStandardized.Size = new System.Drawing.Size(322, 120);
            this.textBoxStandardized.TabIndex = 3;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(83, 177);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(262, 20);
            this.textBoxFilePath.TabIndex = 5;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 403);
            this.Controls.Add(this.panelInput);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputForm";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxStandardized;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonSimplify;
    }
}