namespace SpellEffectV3
{
    partial class AddNewItemsSetsBonusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItemsSetsBonusForm));
            this.label1 = new System.Windows.Forms.Label();
            this.itemsSets_ItemsCSV_TB = new System.Windows.Forms.TextBox();
            this.addNewItemsSetsBonusRowBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameIDTB = new System.Windows.Forms.TextBox();
            this.BonusIsSecretTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.items_set_row_idTB = new System.Windows.Forms.TextBox();
            this.PLeftBorder = new System.Windows.Forms.Panel();
            this.PRightBorder = new System.Windows.Forms.Panel();
            this.PTitle = new System.Windows.Forms.Panel();
            this.LTitle = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.PFooterBorder = new System.Windows.Forms.Panel();
            this.PTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ItemsCSV \"TemplateId des items de la panoplie séparés par virgule ,\"";
            // 
            // itemsSets_ItemsCSV_TB
            // 
            this.itemsSets_ItemsCSV_TB.Location = new System.Drawing.Point(387, 72);
            this.itemsSets_ItemsCSV_TB.Name = "itemsSets_ItemsCSV_TB";
            this.itemsSets_ItemsCSV_TB.Size = new System.Drawing.Size(407, 20);
            this.itemsSets_ItemsCSV_TB.TabIndex = 1;
            this.itemsSets_ItemsCSV_TB.Leave += new System.EventHandler(this.itemsSets_ItemsCSV_TB_Leave);
            // 
            // addNewItemsSetsBonusRowBtn
            // 
            this.addNewItemsSetsBonusRowBtn.Location = new System.Drawing.Point(299, 183);
            this.addNewItemsSetsBonusRowBtn.Name = "addNewItemsSetsBonusRowBtn";
            this.addNewItemsSetsBonusRowBtn.Size = new System.Drawing.Size(262, 34);
            this.addNewItemsSetsBonusRowBtn.TabIndex = 2;
            this.addNewItemsSetsBonusRowBtn.Text = "Ajouter";
            this.addNewItemsSetsBonusRowBtn.UseVisualStyleBackColor = true;
            this.addNewItemsSetsBonusRowBtn.Click += new System.EventHandler(this.addNewItemsSetsBonusRowBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NameID";
            // 
            // nameIDTB
            // 
            this.nameIDTB.Location = new System.Drawing.Point(136, 129);
            this.nameIDTB.Name = "nameIDTB";
            this.nameIDTB.Size = new System.Drawing.Size(87, 20);
            this.nameIDTB.TabIndex = 4;
            // 
            // BonusIsSecretTB
            // 
            this.BonusIsSecretTB.Location = new System.Drawing.Point(136, 158);
            this.BonusIsSecretTB.Name = "BonusIsSecretTB";
            this.BonusIsSecretTB.Size = new System.Drawing.Size(22, 20);
            this.BonusIsSecretTB.TabIndex = 6;
            this.BonusIsSecretTB.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "BonusIsSecret";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "0 par defaut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(164, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(484, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Assurer vous que la table Items_sets à le champ ID en Autoincrement";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(462, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Facultatif, Laisser vide ou récuperer l\'id du nom de panoplie depuis le fichier i" +
    "18n avec un editeur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ID";
            // 
            // items_set_row_idTB
            // 
            this.items_set_row_idTB.Enabled = false;
            this.items_set_row_idTB.Location = new System.Drawing.Point(136, 99);
            this.items_set_row_idTB.Name = "items_set_row_idTB";
            this.items_set_row_idTB.Size = new System.Drawing.Size(49, 20);
            this.items_set_row_idTB.TabIndex = 11;
            // 
            // PLeftBorder
            // 
            this.PLeftBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.PLeftBorder.Location = new System.Drawing.Point(0, 30);
            this.PLeftBorder.Name = "PLeftBorder";
            this.PLeftBorder.Size = new System.Drawing.Size(3, 194);
            this.PLeftBorder.TabIndex = 39;
            // 
            // PRightBorder
            // 
            this.PRightBorder.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.PRightBorder.Location = new System.Drawing.Point(806, 30);
            this.PRightBorder.Name = "PRightBorder";
            this.PRightBorder.Size = new System.Drawing.Size(3, 194);
            this.PRightBorder.TabIndex = 38;
            // 
            // PTitle
            // 
            this.PTitle.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PTitle.Controls.Add(this.LTitle);
            this.PTitle.Controls.Add(this.CloseBtn);
            this.PTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTitle.Location = new System.Drawing.Point(0, 0);
            this.PTitle.Name = "PTitle";
            this.PTitle.Size = new System.Drawing.Size(809, 30);
            this.PTitle.TabIndex = 37;
            this.PTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTitle_MouseDown);
            // 
            // LTitle
            // 
            this.LTitle.AutoSize = true;
            this.LTitle.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitle.ForeColor = System.Drawing.Color.White;
            this.LTitle.Location = new System.Drawing.Point(306, 4);
            this.LTitle.Name = "LTitle";
            this.LTitle.Size = new System.Drawing.Size(179, 19);
            this.LTitle.TabIndex = 13;
            this.LTitle.Text = "Bonus de panoplie";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(786, 4);
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
            this.PFooterBorder.Location = new System.Drawing.Point(0, 224);
            this.PFooterBorder.Name = "PFooterBorder";
            this.PFooterBorder.Size = new System.Drawing.Size(809, 3);
            this.PFooterBorder.TabIndex = 36;
            // 
            // AddNewItemsSetsBonusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 227);
            this.Controls.Add(this.PLeftBorder);
            this.Controls.Add(this.PRightBorder);
            this.Controls.Add(this.PTitle);
            this.Controls.Add(this.PFooterBorder);
            this.Controls.Add(this.items_set_row_idTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BonusIsSecretTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameIDTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addNewItemsSetsBonusRowBtn);
            this.Controls.Add(this.itemsSets_ItemsCSV_TB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewItemsSetsBonusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un nouveau bonus de panoplie";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddNewItemsSetsBonusForm_MouseDown);
            this.PTitle.ResumeLayout(false);
            this.PTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemsSets_ItemsCSV_TB;
        private System.Windows.Forms.Button addNewItemsSetsBonusRowBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameIDTB;
        private System.Windows.Forms.TextBox BonusIsSecretTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox items_set_row_idTB;
        private System.Windows.Forms.Panel PLeftBorder;
        private System.Windows.Forms.Panel PRightBorder;
        private System.Windows.Forms.Panel PTitle;
        private System.Windows.Forms.Label LTitle;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel PFooterBorder;
    }
}