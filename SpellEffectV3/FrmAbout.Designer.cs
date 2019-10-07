namespace SpellEffectV3
{
    partial class FrmAbout
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
            this.PLeftBorder = new System.Windows.Forms.Panel();
            this.PRightBorder = new System.Windows.Forms.Panel();
            this.PTitle = new System.Windows.Forms.Panel();
            this.LTitle = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.PFooterBorder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LSourceCode = new System.Windows.Forms.LinkLabel();
            this.PTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PLeftBorder
            // 
            this.PLeftBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.PLeftBorder.Location = new System.Drawing.Point(0, 30);
            this.PLeftBorder.Name = "PLeftBorder";
            this.PLeftBorder.Size = new System.Drawing.Size(3, 95);
            this.PLeftBorder.TabIndex = 35;
            this.PLeftBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // PRightBorder
            // 
            this.PRightBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.PRightBorder.Location = new System.Drawing.Point(542, 30);
            this.PRightBorder.Name = "PRightBorder";
            this.PRightBorder.Size = new System.Drawing.Size(3, 95);
            this.PRightBorder.TabIndex = 34;
            this.PRightBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // PTitle
            // 
            this.PTitle.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PTitle.Controls.Add(this.LTitle);
            this.PTitle.Controls.Add(this.CloseBtn);
            this.PTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTitle.Location = new System.Drawing.Point(0, 0);
            this.PTitle.Name = "PTitle";
            this.PTitle.Size = new System.Drawing.Size(545, 30);
            this.PTitle.TabIndex = 33;
            this.PTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.ForeColor = System.Drawing.Color.White;
            this.LTitle.Location = new System.Drawing.Point(219, 3);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(89, 19);
            this.LTitle.TabIndex = 13;
            this.LTitle.Text = "A propos";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(519, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(20, 20);
            this.CloseBtn.TabIndex = 13;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // PFooterBorder
            // 
            this.PFooterBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PFooterBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PFooterBorder.Location = new System.Drawing.Point(0, 125);
            this.PFooterBorder.Name = "PFooterBorder";
            this.PFooterBorder.Size = new System.Drawing.Size(545, 3);
            this.PFooterBorder.TabIndex = 32;
            this.PFooterBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Editeur de Sort, Item, Bonus de panoplie, Familier pour la version de  Stump 2.40" +
    " ou plus";
            // 
            // LSourceCode
            // 
            this.LSourceCode.AutoSize = true;
            this.LSourceCode.Location = new System.Drawing.Point(12, 92);
            this.LSourceCode.Name = "LSourceCode";
            this.LSourceCode.Size = new System.Drawing.Size(103, 13);
            this.LSourceCode.TabIndex = 39;
            this.LSourceCode.TabStop = true;
            this.LSourceCode.Text = "Code Source Github";
            this.LSourceCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LSourceCode_LinkClicked);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(545, 128);
            this.Controls.Add(this.LSourceCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PLeftBorder);
            this.Controls.Add(this.PRightBorder);
            this.Controls.Add(this.PTitle);
            this.Controls.Add(this.PFooterBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAbout";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmAbout_MouseDown);
            this.PTitle.ResumeLayout(false);
            this.PTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PLeftBorder;
        private System.Windows.Forms.Panel PRightBorder;
        private System.Windows.Forms.Panel PTitle;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel PFooterBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LSourceCode;
    }
}