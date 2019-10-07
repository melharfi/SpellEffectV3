using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Stump.Server.WorldServer.Game.Effects.Instances;

namespace SpellEffectV3
{
    public partial class AddNewItemsSetsBonusForm : Form
    {
        #region moving form by mouse down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public static string selectedID = "";
        public AddNewItemsSetsBonusForm()
        {
            InitializeComponent();
        }

        private void addNewItemsSetsBonusRowBtn_Click(object sender, EventArgs e)
        {
            if (items_set_row_idTB.Text != "")
            {
                ItemSpellHandler.mysqlCon.cmd.CommandText = "select count(id) from items_Sets where id = '" + items_set_row_idTB.Text + "'";
                ItemSpellHandler.mysqlCon.reader = ItemSpellHandler.mysqlCon.cmd.ExecuteReader();
                var data = ItemSpellHandler.mysqlCon.reader.Read();

                var itemSetId = ItemSpellHandler.mysqlCon.reader[0];
                if (int.Parse(itemSetId.ToString()) == -1)
                {
                    MessageBox.Show("Il existe déjà un enregistrement/panoplie définie dans la table items_sets avec l'id " + items_set_row_idTB.Text + ".\nAu cas ou vous souhaiter comme meme inserer cette enregistrement, il faut utiliser un autre id.\nPour ceci il faut supprimer les anciens id associés a ces items dans la colonne itemSetId dans la table items_templates et mettre la valeur -1");
                    return;
                }
            }
            ItemSpellHandler.mysqlCon.reader.Close();

            List<List<EffectBase>> effectBases = new List<List<EffectBase>>(itemsSets_ItemsCSV_TB.Text.Split(',').Count());
            for(int cnt = 0; cnt < effectBases.Capacity; cnt++)
            {
                effectBases.Add(new List<EffectBase>());
            }

            var toBinary = FormatterExtensions.ToBinary(effectBases);
            if (items_set_row_idTB.Text != "")
                ItemSpellHandler.mysqlCon.cmd.CommandText = "INSERT INTO `items_sets` (`id`,`ItemsCSV`, `NameId`, `BonusIsSecret`, `EffectsBin`) VALUES('" + items_set_row_idTB.Text + "', '" + itemsSets_ItemsCSV_TB.Text + "', '" + nameIDTB.Text + "', '" + BonusIsSecretTB.Text + "',?hexToStr)";
            else
                ItemSpellHandler.mysqlCon.cmd.CommandText = "INSERT INTO `items_sets` (`ItemsCSV`, `NameId`, `BonusIsSecret`, `EffectsBin`) VALUES('" + itemsSets_ItemsCSV_TB.Text + "', '" + nameIDTB.Text + "', '" + BonusIsSecretTB.Text + "',?hexToStr)";
            MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
            
            fileContentParameter.Value = toBinary;
            ItemSpellHandler.mysqlCon.cmd.Parameters.Add(fileContentParameter);
            ItemSpellHandler.mysqlCon.reader = ItemSpellHandler.mysqlCon.cmd.ExecuteReader();
            ItemSpellHandler.mysqlCon.cmd.Parameters.Remove(fileContentParameter);
            ItemSpellHandler.mysqlCon.reader.Close();
            MessageBox.Show("Enregistrement Effectué avec succè");
            selectedID = items_set_row_idTB.Text;
            this.Close();
        }

        private void itemsSets_ItemsCSV_TB_Leave(object sender, EventArgs e)
        {
            if (itemsSets_ItemsCSV_TB.Text != "")
            {
                string result = "";
                foreach(string current in itemsSets_ItemsCSV_TB.Text.Split(','))
                {
                    ItemSpellHandler.mysqlCon.cmd.CommandText = "select ItemSetId from items_templates where id = '" + current + "'";
                    ItemSpellHandler.mysqlCon.reader = ItemSpellHandler.mysqlCon.cmd.ExecuteReader();
                    var data = ItemSpellHandler.mysqlCon.reader.Read();
                    if (data == false)
                    {
                        MessageBox.Show("L'Item n° " + current + " est introuvable dans la table Items_Templates.\nVous pouvez comme même définir cette panoplie mais l'item est absent dans le jeu.\nL'id qui sera généré automatiquement il faut l'associer a la valeur ItemSetId de cet item ultérieurement.");
                        result = "notExist";
                        ItemSpellHandler.mysqlCon.reader.Close();
                        ItemSpellHandler.mysqlCon.reader = null;
                        break;
                    }

                    var itemSetId = ItemSpellHandler.mysqlCon.reader[0];
                    if (itemSetId.ToString() == "-1")
                    {
                        MessageBox.Show("L'Item n° " + current + " n'est associé a aucune panoplie 'ItemSetId=-1'.\nVeuillez lui associer un numéro non existant dans la table items_sets 'colone id' qui sois le même pour tout les items de cette pano.");
                        result = "notAssociatedToSet";
                        ItemSpellHandler.mysqlCon.reader.Close();
                        ItemSpellHandler.mysqlCon.reader = null;
                        break;
                    }
                    else
                    {
                        if(result != "" && result != itemSetId.ToString())
                        {
                            MessageBox.Show("Les items n'ont pas tous la même valeur ItemSetId\nIl faut unifier la valeur ItemSetId pour tout les items dans la table items_templates, colonne 'ItemSetId'");
                            break;
                        }
                        result = itemSetId.ToString();
                    }
                    ItemSpellHandler.mysqlCon.reader.Close();
                    ItemSpellHandler.mysqlCon.reader = null;
                }

                if(int.TryParse(result, out int i))
                {
                    items_set_row_idTB.Text = result;
                }
            }
        }

        private void PTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AddNewItemsSetsBonusForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}