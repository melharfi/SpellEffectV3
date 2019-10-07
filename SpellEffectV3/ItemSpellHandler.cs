using MySql.Data.MySqlClient;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpellEffectV3
{
    public partial class ItemSpellHandler : Form
    {
        #region moving form by mouse down
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        public static MySqlConn mysqlCon;
        List<Stump.DofusProtocol.D2oClasses.EffectInstance> Item_templates_Effects;
        List<EffectBase> Item_pets_Effects;
        int ItemTemplateEffectList_SelectedIndex = -1;
        int PetTemplateEffectList_SelectedIndex = -1;

        public ItemSpellHandler()
        {
            InitializeComponent();
        }

        private void ItemSpellHandler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["AuthentificationForm"].Show();
        }

        private void ItemSpellHandler_Load(object sender, EventArgs e)
        {
            items_templates_itemIDTB.Focus();

            
            var allValues = (Stump.DofusProtocol.Enums.EffectsEnum[])Enum.GetValues(typeof(Stump.DofusProtocol.Enums.EffectsEnum));

            foreach (var current in allValues)
            {
                items_templates_EffectEnumCB.Items.Add(current);
                items_pets_EffectEnumCB.Items.Add(current);
                spells_EffectEnumCB.Items.Add(current);
                itemsSets_templates_EffectEnumCB.Items.Add(current);
            }

            foreach(var current in Enum.GetNames(typeof(Stump.DofusProtocol.Enums.SpellShapeEnum)))
                spells_ZoneShape_CB.Items.Add(current);

            spells_critical_CB.SelectedIndex = 0;
            spells_LevelCB.SelectedIndex = 0;
        }

        #region items_templates
        private void Items_templates_effectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemTemplateEffectList_SelectedIndex = (sender as ListBox).SelectedIndex;
            Items_templates_RefreshEffect(ItemTemplateEffectList_SelectedIndex);
        }

        private void Items_templates_RefreshEffect(int index)
        {
            if (index == -1)
                return;
            items_templates_effectUidTB.Text = Item_templates_Effects[index].EffectUid.ToString();
            items_templates_zoneStopAtTargetTB.Text = Item_templates_Effects[index].ZoneStopAtTarget.ToString();
            items_templates_zoneMaxEfficiencyTB.Text = Item_templates_Effects[index].ZoneMaxEfficiency.ToString();
            items_templates_zoneEfficiencyPercentTB.Text = Item_templates_Effects[index].ZoneEfficiencyPercent.ToString();
            items_templates_zoneMinSizeTB.Text = Item_templates_Effects[index].ZoneMinSize.ToString();
            items_templates_zoneShapeTB.Text = Item_templates_Effects[index].ZoneShape.ToString();
            items_templates_zoneSizeTB.Text = Item_templates_Effects[index].ZoneSize.ToString();
            items_templates_visibleInFightLogTB.Text = Item_templates_Effects[index].VisibleInFightLog.ToString();
            items_templates_visibleInBuffUiTB.Text = Item_templates_Effects[index].VisibleInBuffUi.ToString();
            items_templates_visibleInTooltipTB.Text = Item_templates_Effects[index].VisibleInTooltip.ToString();
            items_templates_triggersTB.Text = Item_templates_Effects[index].Triggers;
            items_templates_triggerTB.Text = Item_templates_Effects[index].Trigger.ToString();
            items_templates_modificatorTB.Text = Item_templates_Effects[index].Modificator.ToString();
            items_templates_groupTB.Text = Item_templates_Effects[index].group.ToString();
            items_templates_randomTB.Text = Item_templates_Effects[index].Random.ToString();
            items_templates_delayTB.Text = Item_templates_Effects[index].Delay.ToString();
            items_templates_durationTB.Text = Item_templates_Effects[index].Duration.ToString();
            items_templates_targetMaskTB.Text = Item_templates_Effects[index].TargetMask;
            items_templates_targetIdTB.Text = Item_templates_Effects[index].TargetId.ToString();
            items_templates_effectIdTB.Text = Item_templates_Effects[index].EffectId.ToString();
            items_templates_effectElementTB.Text = Item_templates_Effects[index].EffectElement.ToString();
            items_templates_rawZoneTB.Text = Item_templates_Effects[index].RawZone;
            items_templates_DiceNumTB.Text = ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)((Item_templates_Effects)[index])).DiceNum.ToString();
            items_templates_DiceFaceTB.Text = ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)((Item_templates_Effects)[index])).DiceSide.ToString();
            items_templates_valueTB.Text = ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)((Item_templates_Effects)[index])).value.ToString();
            items_templates_EffectEnumCB.SelectedItem = (Stump.DofusProtocol.Enums.EffectsEnum)(Item_templates_Effects[index].effectId);
        }

        private void Items_templates_SaveItemEditorBtn_Click(object sender, EventArgs e)
        {
            if (ItemTemplateEffectList_SelectedIndex >= 0)
            {
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].EffectUid = Convert.ToUInt32(items_templates_effectUidTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneStopAtTarget = Convert.ToUInt32(items_templates_zoneStopAtTargetTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneMaxEfficiency = Convert.ToInt32(items_templates_zoneMaxEfficiencyTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneEfficiencyPercent = Convert.ToInt32(items_templates_zoneEfficiencyPercentTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneMinSize = Convert.ToUInt32(items_templates_zoneMinSizeTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneShape = Convert.ToUInt32(items_templates_zoneShapeTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].ZoneSize = Convert.ToUInt32(items_templates_zoneSizeTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].VisibleInFightLog = Convert.ToBoolean(items_templates_visibleInFightLogTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].VisibleInBuffUi = Convert.ToBoolean(items_templates_visibleInBuffUiTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].VisibleInTooltip = Convert.ToBoolean(items_templates_visibleInTooltipTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Triggers = items_templates_triggersTB.Text;
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Trigger = Convert.ToBoolean(items_templates_triggerTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Modificator = Convert.ToInt32(items_templates_modificatorTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].group = Convert.ToInt32(items_templates_groupTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Random = Convert.ToInt32(items_templates_randomTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Delay = Convert.ToInt32(items_templates_delayTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].Duration = Convert.ToInt32(items_templates_durationTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].TargetMask = items_templates_targetMaskTB.Text;
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].TargetId = Convert.ToInt32(items_templates_targetIdTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].EffectId = Convert.ToUInt32(items_templates_effectIdTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].EffectElement = Convert.ToInt32(items_templates_effectElementTB.Text);
                Item_templates_Effects[ItemTemplateEffectList_SelectedIndex].RawZone = items_templates_rawZoneTB.Text;
                ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)Item_templates_Effects[ItemTemplateEffectList_SelectedIndex]).DiceNum = uint.Parse(items_templates_DiceNumTB.Text);
                ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)Item_templates_Effects[ItemTemplateEffectList_SelectedIndex]).DiceSide = uint.Parse(items_templates_DiceFaceTB.Text);
                ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)Item_templates_Effects[ItemTemplateEffectList_SelectedIndex]).value = int.Parse(items_templates_valueTB.Text);
            }
            
            var toBinary = FormatterExtensions.ToBinary(Item_templates_Effects);

            mysqlCon.cmd.CommandText = "update items_templates set PossibleEffectsBin = ?hexToStr where Id = '" + items_templates_itemIDTB.Text + "'";
            MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
            fileContentParameter.Value = toBinary;
            mysqlCon.cmd.Parameters.Add(fileContentParameter);
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
            mysqlCon.cmd.Parameters.Remove(fileContentParameter);
            mysqlCon.reader.Close();

            items_templates_effectList.Items.Clear();
            foreach (var current in Item_templates_Effects)
                items_templates_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);

            items_templates_SaveItemEditorBtn.BackColor = Color.Green;

            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);

                Application.OpenForms["ItemSpellHandler"].BeginInvoke((Action)(() =>
                {
                    items_templates_SaveItemEditorBtn.BackColor = Color.LightGray; ;
                }));
            })).Start();
        }

        private void Items_templates_itemIDTB_TextChanged(object sender, EventArgs e)
        {
            int itemID = 0;
            items_templates_controlsPanel.Visible = false;
            if (!int.TryParse(items_templates_itemIDTB.Text, out itemID))
                return;

            mysqlCon.cmd.CommandText = "select PossibleEffectsBin from items_templates where Id = '" + items_templates_itemIDTB.Text + "'";
            try
            {
                mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                bool isDataFound = mysqlCon.reader.Read();
                if(isDataFound)
                {
                    var possibleEffectBin = mysqlCon.reader[0];
                    mysqlCon.reader.Close();

                    if (possibleEffectBin.ToString() == "")
                    {
                        items_templates_effectList.Items.Clear();
                        Item_templates_Effects = new List<Stump.DofusProtocol.D2oClasses.EffectInstance>();
                        Items_templates_addNewEffectBtn_Click(null, null);
                        foreach (var current in Item_templates_Effects)
                            items_templates_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);
                        items_templates_controlsPanel.Visible = true;
                    }
                    else
                    {
                        Item_templates_Effects = FormatterExtensions.ToObject<List<Stump.DofusProtocol.D2oClasses.EffectInstance>>((byte[])possibleEffectBin);
                        items_templates_effectList.Items.Clear();
                        foreach (var current in Item_templates_Effects)
                            items_templates_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);
                        items_templates_controlsPanel.Visible = true;
                    }
                }
                
                mysqlCon.reader.Close();
                mysqlCon.reader = null;

                if (items_templates_effectList.Items.Count > 0)
                    items_templates_effectList.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du traitement.\n" + ex);
                mysqlCon.reader.Close();
                mysqlCon.reader = null;
            }
        }

        private void Items_templates_EffectEnumCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = items_templates_EffectEnumCB.SelectedItem.ToString();
            int selectedEffectEnumID = (int)((Stump.DofusProtocol.Enums.EffectsEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.EffectsEnum), selectedItem));
            items_templates_effectIdTB.Text = selectedEffectEnumID.ToString();
        }

        private void Items_templates_addNewEffectBtn_Click(object sender, EventArgs e)
        {
            Stump.DofusProtocol.D2oClasses.EffectInstance newEffectInstance = new Stump.DofusProtocol.D2oClasses.EffectInstance();
            Stump.DofusProtocol.Enums.EffectsEnum defaultEffect = Stump.DofusProtocol.Enums.EffectsEnum.Effect_2;
            newEffectInstance.effectId = (uint)defaultEffect;
            newEffectInstance.trigger = false;
            newEffectInstance.visibleInBuffUi = true;
            newEffectInstance.VisibleInFightLog = true;
            newEffectInstance.VisibleInTooltip = true;

            newEffectInstance = new Stump.DofusProtocol.D2oClasses.EffectInstanceDice();
            ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)newEffectInstance).DiceNum = 0;
            ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)newEffectInstance).DiceSide = 0;
            ((Stump.DofusProtocol.D2oClasses.EffectInstanceDice)newEffectInstance).value = 0;

            Item_templates_Effects.Add(newEffectInstance);
            items_templates_effectList.Items.Add(defaultEffect);
            Item_templates_Effects[Item_templates_Effects.Count - 1].effectId = (uint)defaultEffect;
            items_templates_effectList.SelectedIndex = items_templates_effectList.Items.Count - 1;
        }

        private void Items_templates_removeEffectBtn_Click(object sender, EventArgs e)
        {
            if (items_templates_effectList.SelectedIndex > -1)
            {
                int index = items_templates_effectList.SelectedIndex;
                Item_templates_Effects.RemoveAt(index);
                items_templates_effectList.Items.RemoveAt(index);
            }
        }

        private void Items_templates_EffectEnumCB_TextUpdate(object sender, EventArgs e)
        {
            items_templates_EffectEnumCB.DroppedDown = true;
        }
        #endregion


        #region items_pets
        private void items_pets_itemIDTB_TextChanged(object sender, EventArgs e)
        {
            int itemID = 0;
            items_pets_controlsPanel.Visible = false;
            if (!int.TryParse(items_pets_itemIDTB.Text, out itemID))
            {
                return;
            }

            mysqlCon.cmd.CommandText = "select PossibleEffectsBin from items_pets where Id = '" + items_pets_itemIDTB.Text + "'";
            try
            {
                mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                bool isDataFound = mysqlCon.reader.Read();
                if (isDataFound)
                {
                    var possibleEffectBin = mysqlCon.reader[0];
                    mysqlCon.reader.Close();
                    Item_pets_Effects = FormatterExtensions.ToObject<List<Stump.Server.WorldServer.Game.Effects.Instances.EffectBase>>((byte[])possibleEffectBin);
                    items_pets_effectList.Items.Clear();
                    foreach (var current in Item_pets_Effects)
                        items_pets_effectList.Items.Add(current.EffectId);
                    items_pets_controlsPanel.Visible = true;
                }

                mysqlCon.reader.Close();
                mysqlCon.reader = null;

                if (items_pets_effectList.Items.Count > 0)
                    items_pets_effectList.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du traitement.\n" + ex);
                mysqlCon.reader.Close();
                mysqlCon.reader = null;
            }
        }

        private void Items_pets_RefreshEffect(int index)
        {
            if (index == -1)
                return;
            items_pets_DelayTB.Text = Item_pets_Effects[index].Delay.ToString();
            items_pets_DurationTB.Text = Item_pets_Effects[index].Duration.ToString();

            if (Item_pets_Effects[index].EffectFix != null)
                MessageBox.Show("EffectFix is not null.\n" + Item_pets_Effects[index].EffectFix);

            items_pets_EffectIDTB.Text = ((int)Item_pets_Effects[index].EffectId).ToString();
            items_pets_GroupTB.Text = Item_pets_Effects[index].Group.ToString();
            items_pets_HiddenTB.Text = Item_pets_Effects[index].Hidden.ToString();
            items_pets_IsDirtyTB.Text = Item_pets_Effects[index].IsDirty.ToString();
            items_pets_ModificatorTB.Text = Item_pets_Effects[index].Modificator.ToString();
            if(Item_pets_Effects[index].Template != null)
                MessageBox.Show("Template is not null which mean that 'Priority' will not throw an exception, you should add a handler for it.\n" + Item_pets_Effects[index].Template);
            
            items_pets_RandomTB.Text = Item_pets_Effects[index].Random.ToString();
            items_pets_TargetMaskTB.Text = Item_pets_Effects[index].TargetMask;

            items_pets_TriggersTB.Text = Item_pets_Effects[index].Triggers;
            items_pets_TriggerTB.Text = Item_pets_Effects[index].Trigger.ToString();
            items_pets_EfficiencyPercentTB.Text = Item_pets_Effects[index].ZoneEfficiencyPercent.ToString();
            items_pets_ZoneMaxEfficiencyTB.Text = Item_pets_Effects[index].ZoneMaxEfficiency.ToString();
            items_pets_ZoneMinSizeTB.Text = Item_pets_Effects[index].ZoneMinSize.ToString();
            items_pets_ZoneShapeTB.Text = Item_pets_Effects[index].ZoneShape.ToString();
            items_pets_ZoneSizeTB.Text = Item_pets_Effects[index].ZoneSize.ToString();
            items_pets_DiceNumTB.Text = ((EffectDice)Item_pets_Effects[index]).DiceNum.ToString();
            items_pets_DiceFaceTB.Text = ((EffectDice)Item_pets_Effects[index]).DiceFace.ToString();
            items_pets_ValueTB.Text = ((EffectDice)Item_pets_Effects[index]).Value.ToString();

            items_pets_EffectEnumCB.SelectedItem = Item_pets_Effects[index].EffectId;
        }
        #endregion

        private void items_pets_effectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PetTemplateEffectList_SelectedIndex = (sender as ListBox).SelectedIndex;
            Items_pets_RefreshEffect(PetTemplateEffectList_SelectedIndex);
        }

        private void Eff_FormClosed(object sender, FormClosedEventArgs e)
        {
            Item_pets_Effects[items_pets_effectList.SelectedIndex].EffectFix = ((Stump.Server.WorldServer.Database.Spells.SpellEffectFix)((Form)sender).Tag);
            this.Enabled = true;
        }

        private void items_pets_SaveItemEditorBtn_Click(object sender, EventArgs e)
        {
            if (PetTemplateEffectList_SelectedIndex >= 0)
            {
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Delay = int.Parse(items_pets_DelayTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Duration = int.Parse(items_pets_DurationTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].EffectId = (Stump.DofusProtocol.Enums.EffectsEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.EffectsEnum), items_pets_EffectEnumCB.SelectedItem.ToString());
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Group = int.Parse(items_pets_GroupTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Hidden = bool.Parse(items_pets_HiddenTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].IsDirty = bool.Parse(items_pets_IsDirtyTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Modificator = int.Parse(items_pets_ModificatorTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Random = int.Parse(items_pets_RandomTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].TargetMask = items_pets_TargetMaskTB.Text;
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Triggers = items_pets_TriggersTB.Text;
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].Trigger = bool.Parse(items_pets_TriggerTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].ZoneEfficiencyPercent = int.Parse(items_pets_EfficiencyPercentTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].ZoneMaxEfficiency = int.Parse(items_pets_ZoneMaxEfficiencyTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].ZoneMinSize = uint.Parse(items_pets_ZoneMinSizeTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].ZoneShape = (Stump.DofusProtocol.Enums.SpellShapeEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.SpellShapeEnum), items_pets_ZoneShapeTB.Text);
                Item_pets_Effects[PetTemplateEffectList_SelectedIndex].ZoneSize = uint.Parse(items_pets_ZoneSizeTB.Text);
                ((EffectDice)Item_pets_Effects[PetTemplateEffectList_SelectedIndex]).DiceNum = short.Parse(items_pets_DiceNumTB.Text);
                ((EffectDice)Item_pets_Effects[PetTemplateEffectList_SelectedIndex]).DiceFace = short.Parse(items_pets_DiceFaceTB.Text);
                ((EffectDice)Item_pets_Effects[PetTemplateEffectList_SelectedIndex]).Value = short.Parse(items_pets_ValueTB.Text);
            }

            var toBinary = FormatterExtensions.ToBinary(Item_pets_Effects);

            mysqlCon.cmd.CommandText = "update items_pets set PossibleEffectsBin = ?hexToStr where Id = '" + items_pets_itemIDTB.Text + "'";
            MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
            fileContentParameter.Value = toBinary;
            mysqlCon.cmd.Parameters.Add(fileContentParameter);
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
            mysqlCon.cmd.Parameters.Remove(fileContentParameter);
            mysqlCon.reader.Close();

            items_pets_effectList.Items.Clear();
            foreach (var current in Item_pets_Effects)
                items_pets_effectList.Items.Add(current.EffectId);

            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);

                Application.OpenForms["ItemSpellHandler"].BeginInvoke((Action)(() =>
                {
                    items_pets_SaveItemEditorBtn.BackColor = Color.LightGray; ;
                }));
            })).Start();
        }

        private void items_templates_effectList_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                Items_templates_removeEffectBtn_Click(null, null);
                if (items_templates_effectList.Items.Count > 0)
                    items_templates_effectList.SelectedIndex = 0;
            }
        }

        private void items_templates_effectIdTB_TextChanged(object sender, EventArgs e)
        {
            if (items_templates_effectElementTB.Text != "")
            {
                int effectID;
                if (int.TryParse(items_templates_effectIdTB.Text, out effectID))
                    items_templates_EffectEnumCB.SelectedItem = (Stump.DofusProtocol.Enums.EffectsEnum)effectID;
            }
        }

        private void items_pets_RemoveEffectBtn_Click(object sender, EventArgs e)
        {
            if (items_pets_effectList.SelectedIndex > -1)
            {
                int index = items_pets_effectList.SelectedIndex;
                Item_pets_Effects.RemoveAt(index);
                items_pets_effectList.Items.RemoveAt(index);
            }
        }

        private void items_pets_effectList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                items_pets_RemoveEffectBtn_Click(null, null);
                if (items_pets_effectList.Items.Count > 0)
                    items_pets_effectList.SelectedIndex = 0;
            }
        }

        private void items_pets_AddNewEffectBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cette option n'est pas encore intégré");
        }

        private void items_templates_upBtn_Click(object sender, EventArgs e)
        {
            if(items_templates_effectList.SelectedIndex > 0)
            {
                int oldIndex = items_templates_effectList.SelectedIndex;
                int newIndex = oldIndex - 1;

                var item = Item_templates_Effects[oldIndex];
                Item_templates_Effects.RemoveAt(oldIndex);
                Item_templates_Effects.Insert(newIndex, item);
                
                items_templates_effectList.Items.Clear();
                foreach (var current in Item_templates_Effects)
                    items_templates_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);

                items_templates_effectList.SelectedIndex = newIndex;
            }
        }

        private void spells_effectList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                spells_RemoveEffectBtn_Click(null, null);
                if (spells_effectList.Items.Count > 0)
                    spells_effectList.SelectedIndex = 0;
            }
        }

        private void spells_RemoveEffectBtn_Click(object sender, EventArgs e)
        {
            if (spells_effectList.SelectedIndex > -1)
            {
                if (spells_critical_CB.SelectedIndex == 0)
                {
                    int index = spells_effectList.SelectedIndex;
                    SpellLevelTemplate.EffectsBinInstance.m_effects.RemoveAt(index);
                    spells_effectList.Items.RemoveAt(index);
                }
                else
                {
                    int index = spells_effectList.SelectedIndex;
                    SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects.RemoveAt(index);
                    spells_effectList.Items.RemoveAt(index);
                }
            }
        }

        private void spells_AddNewEffectBtn_Click(object sender, EventArgs e)
        {
            if(spells_critical_CB.SelectedIndex == 0)
            {
                EffectDice effectDice = new EffectDice();
                effectDice.EffectId = Stump.DofusProtocol.Enums.EffectsEnum.Effect_AddAgility;
                effectDice.Hidden = false;
                effectDice.IsDirty = true;
                effectDice.TargetMask = "a,A";
                effectDice.Trigger = false;
                effectDice.Triggers = "I";
                effectDice.ZoneShape = Stump.DofusProtocol.Enums.SpellShapeEnum.L;
                effectDice.ZoneSize = 2;
                SpellLevelTemplate.EffectsBinInstance.m_effects.Add(effectDice);
                spells_effectList.Items.Add(effectDice.EffectId);
            }
            else
            {
                EffectDice effectDice = new EffectDice();
                effectDice.EffectId = Stump.DofusProtocol.Enums.EffectsEnum.Effect_AddAgility;
                effectDice.Hidden = false;
                effectDice.IsDirty = true;
                effectDice.TargetMask = "a,A";
                effectDice.Trigger = false;
                effectDice.Triggers = "I";
                effectDice.ZoneShape = Stump.DofusProtocol.Enums.SpellShapeEnum.L;
                effectDice.ZoneSize = 2;
                SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects.Add(effectDice);
                spells_effectList.Items.Add(effectDice.EffectId);
            }
            spells_effectList.SelectedIndex = spells_effectList.Items.Count - 1;
        }

        private void spell_effects_TB_KeyUp(object sender, KeyEventArgs e)
        {
            int spellID = 0;
            spells_controlsPanel.Visible = false;
            if (!int.TryParse(spell_effects_TB.Text, out spellID))
                return;

            mysqlCon.cmd.CommandText = "select " + (spells_critical_CB.SelectedIndex == 0 ? "EffectsBin" : "CriticalEffectsBin") + ",Id from spells_levels where SpellId = '" + spellID + "'";
            try
            {
                mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                int cnt = 0;
                while (mysqlCon.reader.Read())
                {
                    if (cnt == int.Parse(spells_LevelCB.Text) - 1)
                    {
                        var possibleEffectBin = mysqlCon.reader[0];
                        int id = int.Parse(mysqlCon.reader[1].ToString());
                        if (spells_critical_CB.SelectedIndex == 0)
                        {
                            SpellLevelTemplate.selectedSpell_LevelID = id;
                            SpellLevelTemplate.EffectsBinInstance.Initialize((byte[])possibleEffectBin);
                            spells_effectList.Items.Clear();
                            foreach (var current in SpellLevelTemplate.EffectsBinInstance.m_effects)
                            {
                                if (current.EffectFix != null)
                                    MessageBox.Show("Effect " + current + " a l'effet EffectFix non null, il serai alors préferable d'integrer l'affichage de ce paramètre");

                                spells_effectList.Items.Add(current.EffectId);
                            }
                            spells_controlsPanel.Visible = true;
                        }
                        else
                        {
                            SpellLevelTemplate.selectedSpell_LevelID = id;
                            if (possibleEffectBin.ToString() != "")
                            {
                                SpellLevelTemplate.CriticalEffectsBinInstance.Initialize((byte[])possibleEffectBin);
                                spells_effectList.Items.Clear();
                                foreach (var current in SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects)
                                    spells_effectList.Items.Add(current.EffectId);
                                spells_controlsPanel.Visible = true;
                            }
                            else
                            {
                                // il n y à aucune donnée blob dans le champ CriticalEffectsBin
                                spells_effectList.Items.Clear();

                                SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects = new List<EffectDice>();
                                spells_AddNewEffectBtn_Click(null, null);

                                spells_controlsPanel.Visible = true;
                            }
                        }
                        break;
                    }
                    cnt++;
                }
                mysqlCon.reader.Close();
                mysqlCon.reader = null;

                if (spells_effectList.Items.Count > 0)
                    spells_effectList.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du traitement.\n" + ex);
                mysqlCon.reader.Close();
                mysqlCon.reader = null;
            }
        }

        private void spells_LevelCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell_effects_TB_KeyUp(null, null);
        }

        private void spells_critical_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            spell_effects_TB_KeyUp(null, null);
        }

        private void spells_effectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spells_effectList.SelectedIndex == -1)
            {
                if (spells_effectList.Items.Count > 0)
                    spells_effectList.SelectedIndex = 0;
                else
                {
                    // aucun effet n'est disponible
                    return;
                }
            }
            EffectDice ed;
            if(spells_critical_CB.SelectedIndex == 0)
                ed = SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex];
            else
                ed = SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex];
            
            spells_Delay_TB.Text = ed.Delay.ToString();
            spells_DiceFace_TB.Text = ed.DiceFace.ToString();
            spells_DiceNum_TB.Text = ed.DiceNum.ToString();
            spells_Duration_TB.Text = ed.Duration.ToString();
            spells_EffectId_TB.Text = ((int)ed.EffectId).ToString();
            spells_Group_TB.Text = ed.Group.ToString();
            spells_Hidden_TB.Text = ed.Hidden.ToString();
            spells_Id_TB.Text = ed.Id.ToString();
            spells_IsDirty_TB.Text = ed.IsDirty.ToString();
            spells_Max_TB.Text = ed.Max.ToString();
            spells_Min_TB.Text = ed.Min.ToString();
            spells_Modificator_TB.Text = ed.Modificator.ToString();
            string result = "";
            try
            {
                result = ed.Priority.ToString();
            }
            catch
            {
                
            }
            spells_Priority_TB.Text = result != null ? result.ToString() : "";
            spells_Random_TB.Text = ed.Random.ToString();
            spells_TargetMask_TB.Text = ed.TargetMask;
            spells_Trigger_TB.Text = ed.Trigger.ToString();
            spells_Triggers_TB.Text = ed.Triggers.ToString();
            spells_Value_TB.Text = ed.Value.ToString();
            spells_ZoneEfficiencyPercent_TB.Text = ed.ZoneEfficiencyPercent.ToString();
            spells_ZoneMaxEfficiency_TB.Text = ed.ZoneMaxEfficiency.ToString();
            spells_ZoneMinSize_TB.Text = ed.ZoneMinSize.ToString();
            spells_ZoneShape_CB.SelectedItem = ed.ZoneShape.ToString();
            spells_ZoneSize_TB.Text = ed.ZoneSize.ToString();
            spells_EffectEnumCB.SelectedItem = ed.EffectId;
        }

        private void spells_EffectEnumCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stump.DofusProtocol.Enums.EffectsEnum selectedEffectEnum = (Stump.DofusProtocol.Enums.EffectsEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.EffectsEnum), spells_EffectEnumCB.SelectedItem.ToString());
            spells_EffectId_TB.Text = ((int)selectedEffectEnum).ToString();
        }

        private void spells_EffectId_TB_TextChanged(object sender, EventArgs e)
        {
            if (spells_EffectId_TB.Text != "")
            {
                if (int.TryParse(spells_EffectId_TB.Text, out int effectID))
                    spells_EffectEnumCB.SelectedItem = (Stump.DofusProtocol.Enums.EffectsEnum)effectID;
            }
        }

        private void spells_SaveItemEditorBtn_Click(object sender, EventArgs e)
        {
            if(spells_critical_CB.SelectedIndex == 0)
            {
                try
                {
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].EffectId = (Stump.DofusProtocol.Enums.EffectsEnum)int.Parse(spells_EffectId_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].DiceNum = short.Parse(spells_DiceNum_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].DiceFace = short.Parse(spells_DiceFace_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Value = short.Parse(spells_Value_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].ZoneShape = (Stump.DofusProtocol.Enums.SpellShapeEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.SpellShapeEnum), spells_ZoneShape_CB.SelectedItem.ToString());
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].ZoneEfficiencyPercent = int.Parse(spells_ZoneEfficiencyPercent_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].ZoneMaxEfficiency = int.Parse(spells_ZoneMaxEfficiency_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].ZoneMinSize = uint.Parse(spells_ZoneMinSize_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].ZoneSize = uint.Parse(spells_ZoneSize_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Hidden = bool.Parse(spells_Hidden_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Id = short.Parse(spells_EffectId_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].IsDirty = bool.Parse(spells_IsDirty_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Triggers = spells_Triggers_TB.Text;
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Trigger = bool.Parse(spells_Trigger_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Modificator = int.Parse(spells_Modificator_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Group = int.Parse(spells_Group_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Random = int.Parse(spells_Random_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Delay = int.Parse(spells_Delay_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Duration = int.Parse(spells_Duration_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].Priority = spells_Priority_TB.Text == "" ? 0 : int.Parse(spells_Priority_TB.Text);
                    SpellLevelTemplate.EffectsBinInstance.m_effects[spells_effectList.SelectedIndex].TargetMask = spells_TargetMask_TB.Text;

                    byte[] toBinary = EffectManager.Instance.SerializeEffects(SpellLevelTemplate.EffectsBinInstance.m_effects);
                    mysqlCon.cmd.CommandText = "update spells_levels set EffectsBin = ?hexToStr where id = '" + SpellLevelTemplate.selectedSpell_LevelID + "'";
                    MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
                    fileContentParameter.Value = toBinary;
                    mysqlCon.cmd.Parameters.Add(fileContentParameter);
                    mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                    mysqlCon.cmd.Parameters.Remove(fileContentParameter);
                    mysqlCon.reader.Close();

                    if (sender is bool && (bool)sender == true)
                        MessageBox.Show("Modifications enregistrés");

                    spell_effects_TB_KeyUp(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de conversion peux-être, vérifier la valeur d'un champ qui doit être numérique et que vous avez tapé une chaine de caractères.\n" + ex);
                }
            }
            else
            {
                try
                {
                    if(SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects.Count > 0)
                    {
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].EffectId = (Stump.DofusProtocol.Enums.EffectsEnum)int.Parse(spells_EffectId_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].DiceNum = short.Parse(spells_DiceNum_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].DiceFace = short.Parse(spells_DiceFace_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Value = short.Parse(spells_Value_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].ZoneShape = (Stump.DofusProtocol.Enums.SpellShapeEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.SpellShapeEnum), spells_ZoneShape_CB.SelectedItem.ToString());
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].ZoneEfficiencyPercent = int.Parse(spells_ZoneEfficiencyPercent_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].ZoneMaxEfficiency = int.Parse(spells_ZoneMaxEfficiency_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].ZoneMinSize = uint.Parse(spells_ZoneMinSize_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].ZoneSize = uint.Parse(spells_ZoneSize_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Hidden = bool.Parse(spells_Hidden_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Id = short.Parse(spells_EffectId_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].IsDirty = bool.Parse(spells_IsDirty_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Triggers = spells_Triggers_TB.Text;
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Trigger = bool.Parse(spells_Trigger_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Modificator = int.Parse(spells_Modificator_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Group = int.Parse(spells_Group_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Random = int.Parse(spells_Random_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Delay = int.Parse(spells_Delay_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Duration = int.Parse(spells_Duration_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].Priority = spells_Priority_TB.Text == "" ? 0 : int.Parse(spells_Priority_TB.Text);
                        SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[spells_effectList.SelectedIndex].TargetMask = spells_TargetMask_TB.Text;
                    }
                    
                    byte[] toBinary = EffectManager.Instance.SerializeEffects(SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects);
                    mysqlCon.cmd.CommandText = "update spells_levels set CriticalEffectsBin = ?hexToStr where id = '" + SpellLevelTemplate.selectedSpell_LevelID + "'";
                    MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
                    fileContentParameter.Value = toBinary;
                    mysqlCon.cmd.Parameters.Add(fileContentParameter);
                    mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                    mysqlCon.cmd.Parameters.Remove(fileContentParameter);
                    mysqlCon.reader.Close();

                    MessageBox.Show("Modifications enregistrés");
                    spell_effects_TB_KeyUp(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de caste peux-être, vérifier la valeur d'un champ qui peut être numérique et que vous avez tapé une chaine de caractères.\n" + ex);
                }
            }
        }

        private void spells_upBtn_Click(object sender, EventArgs e)
        {
            if (spells_effectList.SelectedIndex > 0)
            {
                if(spells_critical_CB.SelectedIndex == 0)
                {
                    int oldIndex = spells_effectList.SelectedIndex;
                    int newIndex = oldIndex - 1;

                    var spellEffect = SpellLevelTemplate.EffectsBinInstance.m_effects[oldIndex];
                    SpellLevelTemplate.EffectsBinInstance.m_effects.RemoveAt(oldIndex);
                    SpellLevelTemplate.EffectsBinInstance.m_effects.Insert(newIndex, spellEffect);

                    spells_effectList.Items.Clear();
                    foreach (var current in SpellLevelTemplate.EffectsBinInstance.m_effects)
                        spells_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);

                    spells_effectList.SelectedIndex = newIndex;
                }
                else
                {
                    int oldIndex = spells_effectList.SelectedIndex;
                    int newIndex = oldIndex - 1;

                    var spellEffect = SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects[oldIndex];
                    SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects.RemoveAt(oldIndex);
                    SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects.Insert(newIndex, spellEffect);

                    spells_effectList.Items.Clear();
                    foreach (var current in SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects)
                        spells_effectList.Items.Add((Stump.DofusProtocol.Enums.EffectsEnum)current.EffectId);

                    spells_effectList.SelectedIndex = newIndex;
                }
            }
        }

        private void AddNewEffectBtn_Click(object sender, EventArgs e)
        {
            if(spell_effects_TB.Text == "")
            {
                MessageBox.Show("Veuillez saisir le numéro du sort, le niveau et l'état critique ou pas svp");
            }
            else
            {
                int spellId = 0;
                if (!int.TryParse(spell_effects_TB.Text, out spellId))
                    MessageBox.Show("Valeur sort incorrecte");
                else
                {
                    //par sécurité on vérifie si le sort existe déjà, si c'est le cas le joueur dois dabord ajouter un nouveau enregistrement vide pour que apres sois remplie dans les 2 champs EffectBin et CriticalEffectBin
                    mysqlCon.cmd.CommandText = "select count(id) from spells_levels where SpellId = '" + spellId + "'";
                    mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                    mysqlCon.reader.Read();
                    long row = mysqlCon.reader.GetInt64(0);

                    mysqlCon.reader.Close();

                    if(row == 0)
                    {
                        MessageBox.Show("Le sort n°" + spellId + " n'existe pas dans la bdd.\nVeuillez d'abord ajouter un nouveau enregistrement de ce sort dans la table Spell_Level.");
                        return;
                    }
                    else if(row < spells_LevelCB.SelectedIndex + 1)
                    {
                        MessageBox.Show("Le sort n°" + spellId + " sous le level " + (spells_LevelCB.SelectedIndex + 1) + " n'existe pas.\nVeuillez d'abord ajouter un nouveau enregistrement de ce sort.");
                        return;
                    }
                    else
                    {
                        spells_effectList.Items.Clear();
                        if(spells_critical_CB.SelectedIndex == 0)
                        {
                            SpellLevelTemplate.EffectsBinInstance.m_effects.Clear();
                            spells_AddNewEffectBtn_Click(null, null);
                        }
                        else
                        {
                            SpellLevelTemplate.CriticalEffectsBinInstance.m_criticalEffects= new List<EffectDice>();
                            spells_AddNewEffectBtn_Click(null, null);
                        }

                        spells_controlsPanel.Visible = true;
                    }
                }
            }
        }

        private void items_sets_ID_l_KeyUp(object sender, KeyEventArgs e)
        {
            int items_sets_ID = 0;
            if(!int.TryParse(items_sets_ID_TB.Text, out items_sets_ID))
            {
                MessageBox.Show("Veuillez entrer une valeur numerique");
                items_sets_ID_TB.Text = "";
                return;
            }
            
            mysqlCon.cmd.CommandText = "select EffectsBin from items_sets where id = '" + items_sets_ID + "'";
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
            var effectsBinReader = mysqlCon.reader.Read();
            if(effectsBinReader == false)
            {
                MessageBox.Show("Données introuvable, veuillez vous assurer de l'ID de l'enregistrement");
                return;
            }

            var possibleEffectBin = mysqlCon.reader[0];

            ItemSetTemplate.EffectsBinInstance.Initialize((byte[])possibleEffectBin);
            var bonus = ItemSetTemplate.EffectsBinInstance.Deserialize();

            if (bonus != null)
            {
                itemsSets_templates_effectList.Items.Clear();
                itemsSets_templates_Bonus_Rank_CB.Items.Clear();

                for (int cnt = 0; cnt < ItemSetTemplate.EffectsBinInstance.Effects.Count; cnt++)
                    itemsSets_templates_Bonus_Rank_CB.Items.Add(cnt + 1);

                itemsSets_templates_controlsPanel.Visible = true;
                itemsSets_templates_Bonus_Rank_CB.SelectedIndex = 0;
            }
            mysqlCon.reader.Close();
            mysqlCon.reader = null;
        }

        private void itemsSets_templates_Bonus_Rank_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsSets_templates_RefreshEffects(itemsSets_templates_Bonus_Rank_CB.SelectedIndex);
        }

        private void ItemsSets_templates_RefreshEffects(int rankIndex)
        {
            if (rankIndex == -1)
                return;
            if(ItemSetTemplate.EffectsBinInstance.Effects.Count() > 0)
            {
                itemsSets_templates_effectList.Items.Clear();
                foreach (var current in ItemSetTemplate.EffectsBinInstance.Effects[rankIndex])
                {
                    var currentEffect = (EffectBase)current;
                    if (ItemSetTemplate.EffectsBinInstance.Effects[rankIndex].Count() > 0)
                    {
                        itemsSets_templates_effectList.Items.Add(currentEffect.EffectId);
                        itemsSets_templates_effectIdTB.Text = ((int)currentEffect.EffectId).ToString();
                        itemsSets_templates_DiceNumTB.Text = ((EffectDice)current).DiceNum.ToString();
                        itemsSets_templates_DiceFaceTB.Text = ((EffectDice)current).DiceFace.ToString();
                        itemsSets_templates_valueTB.Text = ((EffectDice)current).Value.ToString();
                        itemsSets_templates_EffectEnumCB.SelectedItem = ((EffectDice)current).EffectId;

                        itemsSets_templates_effectList.SelectedIndex = itemsSets_templates_effectList.Items.Count - 1;
                    }
                    else
                    {
                        itemsSets_templates_effectIdTB.Text = "";
                        itemsSets_templates_DiceNumTB.Text = "";
                        itemsSets_templates_DiceFaceTB.Text = "";
                        itemsSets_templates_valueTB.Text = "";
                        itemsSets_templates_EffectEnumCB.SelectedItem = "";
                    }
                }
            }
        }

        private void itemsSets_templates_effectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemsSets_templates_RefreshOneEffect(itemsSets_templates_effectList.SelectedIndex);
        }

        private void ItemsSets_templates_RefreshOneEffect(int effectIndex)
        {
            if (effectIndex == -1)
                return;
            if (ItemSetTemplate.EffectsBinInstance.Effects.Count() > 0)
            {
                var currentEffect = (ItemSetTemplate.EffectsBinInstance.Effects[itemsSets_templates_Bonus_Rank_CB.SelectedIndex][effectIndex]);//   (EffectBase)current;
                if (currentEffect != null)
                {
                    itemsSets_templates_effectIdTB.Text = ((int)currentEffect.EffectId).ToString();
                    itemsSets_templates_DiceNumTB.Text = ((EffectDice)currentEffect).DiceNum.ToString();
                    itemsSets_templates_DiceFaceTB.Text = ((EffectDice)currentEffect).DiceFace.ToString();
                    itemsSets_templates_valueTB.Text = ((EffectDice)currentEffect).Value.ToString();
                    itemsSets_templates_EffectEnumCB.SelectedItem = ((EffectDice)currentEffect).EffectId;
                }
                else
                {
                    itemsSets_templates_DiceNumTB.Text = "";
                    itemsSets_templates_DiceFaceTB.Text = "";
                    itemsSets_templates_valueTB.Text = "";
                    itemsSets_templates_EffectEnumCB.SelectedItem = "";
                }
            }
        }

        private void itemsSets_templates_SaveItemEditorBtn_Click(object sender, EventArgs e)
        {
            var current = (EffectDice)ItemSetTemplate.EffectsBinInstance.Effects[itemsSets_templates_Bonus_Rank_CB.SelectedIndex][itemsSets_templates_effectList.SelectedIndex];

            int effectID = int.Parse(itemsSets_templates_effectIdTB.Text);
            Stump.DofusProtocol.Enums.EffectsEnum currentEffectEnum = (Stump.DofusProtocol.Enums.EffectsEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.EffectsEnum), itemsSets_templates_effectIdTB.Text);
            current.EffectId = currentEffectEnum;
            current.DiceFace = short.Parse(itemsSets_templates_DiceFaceTB.Text);
            current.DiceNum = short.Parse(itemsSets_templates_DiceNumTB.Text);
            current.Value = short.Parse(itemsSets_templates_valueTB.Text);
            
            var toBinary = FormatterExtensions.ToBinary(ItemSetTemplate.EffectsBinInstance.Effects);

            mysqlCon.cmd.CommandText = "update items_sets set EffectsBin = ?hexToStr where Id = '" + items_sets_ID_TB.Text + "'";
            MySqlParameter fileContentParameter = new MySqlParameter("?hexToStr", MySqlDbType.Blob, toBinary.Length);
            fileContentParameter.Value = toBinary;
            mysqlCon.cmd.Parameters.Add(fileContentParameter);
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
            mysqlCon.cmd.Parameters.Remove(fileContentParameter);
            mysqlCon.reader.Close();

            itemsSets_templates_SaveItemEditorBtn.BackColor = Color.Green;

            ItemsSets_templates_RefreshEffects(itemsSets_templates_Bonus_Rank_CB.SelectedIndex);

            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);

                Application.OpenForms["ItemSpellHandler"].BeginInvoke((Action)(() =>
                {
                    itemsSets_templates_SaveItemEditorBtn.BackColor = Color.LightGray; ;
                }));
            })).Start();
        }

        [System.Runtime.InteropServices.DllImport("msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        static bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            // Validate buffers are the same length.
            // This also ensures that the count does not exceed the length of either buffer.  
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }

        private void itemsSets_templates_AddNewEffectBtn_Click(object sender, EventArgs e)
        {
            if(itemsSets_templates_Bonus_Rank_CB.SelectedIndex == 0)
            {
                MessageBox.Show("Impossible d'ajouter un Bonus de panoplie avec 1 seul item");
                return;
            }
            ItemSetTemplate.EffectsBinInstance.Effects[itemsSets_templates_Bonus_Rank_CB.SelectedIndex].Add(new EffectDice(Stump.DofusProtocol.Enums.EffectsEnum.Effect_2, 0, 0, 0));
            itemsSets_templates_effectList.Items.Add(Stump.DofusProtocol.Enums.EffectsEnum.Effect_2);
            ItemsSets_templates_RefreshOneEffect(itemsSets_templates_effectList.SelectedIndex);
        }

        private void itemsSets_templates_EffectEnumCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = itemsSets_templates_EffectEnumCB.SelectedItem.ToString();
            int selectedEffectEnumID = (int)((Stump.DofusProtocol.Enums.EffectsEnum)Enum.Parse(typeof(Stump.DofusProtocol.Enums.EffectsEnum), selectedItem));
            itemsSets_templates_effectIdTB.Text = selectedEffectEnumID.ToString();
        }

        private void itemsSets_templates_EffectEnumCB_TextUpdate(object sender, EventArgs e)
        {
            itemsSets_templates_EffectEnumCB.DroppedDown = true;
        }

        private void itemsSets_templates_RemoveEffectBtn_Click(object sender, EventArgs e)
        {
            ItemSetTemplate.EffectsBinInstance.Effects[itemsSets_templates_Bonus_Rank_CB.SelectedIndex].RemoveAt(itemsSets_templates_effectList.SelectedIndex);
            ItemsSets_templates_RefreshEffects(itemsSets_templates_Bonus_Rank_CB.SelectedIndex);
        }

        private void itemsSetsAddNewRowBtn_Click(object sender, EventArgs e)
        {
            AddNewItemsSetsBonusForm anisbf = new AddNewItemsSetsBonusForm();
            anisbf.Show(this);
            this.AddOwnedForm(anisbf);
            this.Enabled = false;
            anisbf.FormClosed += Anisbf_FormClosed;
        }

        private void Anisbf_FormClosed(object sender, FormClosedEventArgs e)
        {
            items_sets_ID_TB.Text = AddNewItemsSetsBonusForm.selectedID;
            items_sets_ID_l_KeyUp(null, null);
            this.Enabled = true;
        }

        private void itemsSets_templates_effectIdTB_TextChanged(object sender, EventArgs e)
        {
            if (itemsSets_templates_effectIdTB.Text != "")
            {
                int effectID;
                if (int.TryParse(itemsSets_templates_effectIdTB.Text, out effectID))
                    itemsSets_templates_EffectEnumCB.SelectedItem = (Stump.DofusProtocol.Enums.EffectsEnum)effectID;
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

        private void Items_templates_tab_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Items_templates_controlsPanel_MouseDown(object sender, MouseEventArgs e)
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