namespace SpellEffectV3
{
    partial class AuthentificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthentificationForm));
            this.label6 = new System.Windows.Forms.Label();
            this.connection = new System.Windows.Forms.Button();
            this.Ip = new System.Windows.Forms.TextBox();
            this.DB = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PFooterBorder = new System.Windows.Forms.Panel();
            this.PLeftBorder = new System.Windows.Forms.Panel();
            this.PRightBorder = new System.Windows.Forms.Panel();
            this.PTitle = new System.Windows.Forms.Panel();
            this.LTitle = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.LAbout = new System.Windows.Forms.Label();
            this.PTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(220, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "By : Th3-m0RpH3R";
            // 
            // connection
            // 
            this.connection.Location = new System.Drawing.Point(124, 184);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(115, 30);
            this.connection.TabIndex = 9;
            this.connection.Text = "Connexion";
            this.connection.UseVisualStyleBackColor = true;
            this.connection.Click += new System.EventHandler(this.connection_Click);
            // 
            // Ip
            // 
            this.Ip.Location = new System.Drawing.Point(201, 73);
            this.Ip.Name = "Ip";
            this.Ip.Size = new System.Drawing.Size(100, 20);
            this.Ip.TabIndex = 8;
            this.Ip.Text = "localhost";
            // 
            // DB
            // 
            this.DB.Location = new System.Drawing.Point(201, 147);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(100, 20);
            this.DB.TabIndex = 7;
            this.DB.Text = "world";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(201, 123);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 20);
            this.Password.TabIndex = 6;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(201, 99);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 5;
            this.username.Text = "root";
            this.username.KeyUp += new System.Windows.Forms.KeyEventHandler(this.username_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adresse IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base de donnée";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom d\'utilisateur";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(72, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identifiant Base de donnée";
            // 
            // PFooterBorder
            // 
            this.PFooterBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PFooterBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PFooterBorder.Location = new System.Drawing.Point(0, 251);
            this.PFooterBorder.Name = "PFooterBorder";
            this.PFooterBorder.Size = new System.Drawing.Size(348, 3);
            this.PFooterBorder.TabIndex = 27;
            // 
            // PLeftBorder
            // 
            this.PLeftBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.PLeftBorder.Location = new System.Drawing.Point(0, 30);
            this.PLeftBorder.Name = "PLeftBorder";
            this.PLeftBorder.Size = new System.Drawing.Size(3, 221);
            this.PLeftBorder.TabIndex = 31;
            // 
            // PRightBorder
            // 
            this.PRightBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.PRightBorder.Location = new System.Drawing.Point(345, 30);
            this.PRightBorder.Name = "PRightBorder";
            this.PRightBorder.Size = new System.Drawing.Size(3, 221);
            this.PRightBorder.TabIndex = 30;
            // 
            // PTitle
            // 
            this.PTitle.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PTitle.Controls.Add(this.LTitle);
            this.PTitle.Controls.Add(this.CloseBtn);
            this.PTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTitle.Location = new System.Drawing.Point(0, 0);
            this.PTitle.Name = "PTitle";
            this.PTitle.Size = new System.Drawing.Size(348, 30);
            this.PTitle.TabIndex = 29;
            this.PTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.ForeColor = System.Drawing.Color.White;
            this.LTitle.Location = new System.Drawing.Point(89, 6);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(159, 19);
            this.LTitle.TabIndex = 13;
            this.LTitle.Text = "Spell Effect v3";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(323, 5);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(20, 20);
            this.CloseBtn.TabIndex = 13;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // LAbout
            // 
            this.LAbout.AutoSize = true;
            this.LAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAbout.ForeColor = System.Drawing.Color.Maroon;
            this.LAbout.Location = new System.Drawing.Point(12, 232);
            this.LAbout.Name = "LAbout";
            this.LAbout.Size = new System.Drawing.Size(57, 13);
            this.LAbout.TabIndex = 32;
            this.LAbout.Text = "A propos";
            this.LAbout.Click += new System.EventHandler(this.LAbout_Click);
            // 
            // AuthentificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(348, 254);
            this.Controls.Add(this.LAbout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PLeftBorder);
            this.Controls.Add(this.connection);
            this.Controls.Add(this.PRightBorder);
            this.Controls.Add(this.Ip);
            this.Controls.Add(this.PTitle);
            this.Controls.Add(this.DB);
            this.Controls.Add(this.PFooterBorder);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthentificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentification";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AuthentificationForm_MouseDown);
            this.PTitle.ResumeLayout(false);
            this.PTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button connection;
        private System.Windows.Forms.TextBox Ip;
        private System.Windows.Forms.TextBox DB;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PFooterBorder;
        private System.Windows.Forms.Panel PLeftBorder;
        private System.Windows.Forms.Panel PRightBorder;
        private System.Windows.Forms.Panel PTitle;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label LAbout;
    }
}