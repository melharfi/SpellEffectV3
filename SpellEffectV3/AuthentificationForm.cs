using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpellEffectV3
{
    public partial class AuthentificationForm : Form
    {
        public static string userDB;
        public static string passwordDB;
        public static string adresseDB;
        public static string DBName;
        #region moving form by mouse down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        public AuthentificationForm()
        {
            InitializeComponent();
        }

        private void connection_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("Entrer le d'utilisateur");
                return;
            }
            else if (DB.Text == "")
            {
                MessageBox.Show("Entrer la Base de donné");
                return;
            }
            else if (Ip.Text == "")
            {
                MessageBox.Show("Entrer l'adresse Ip");
                return;
            }

            MySqlConn mysqlCon = new MySqlConn(username.Text, Password.Text, DB.Text, Ip.Text);

            if (mysqlCon.conn.State == ConnectionState.Open)
            {
                userDB = username.Text;
                passwordDB = Password.Text;
                adresseDB = Ip.Text;
                DBName = DB.Text;
                this.Hide();

                ItemSpellHandler.mysqlCon = mysqlCon;

                ItemSpellHandler ish = new ItemSpellHandler();
                ish.Show();
            }
        }

        private void username_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                connection_Click(null, null);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        private void PTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AuthentificationForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
