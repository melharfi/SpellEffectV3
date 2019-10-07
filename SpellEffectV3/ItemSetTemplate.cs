//using DofusItemSpellEditor.Items;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellEffectV3
{
    public static class ItemSetTemplate
    {
        public static int rowID;

        public static class EffectsBinInstance
        {
            public static List<EffectDice> m_effects;
            public static byte[] m_effectsBin;

            public static void Initialize(byte[] value)
            {
                m_effectsBin = value;
            }

            public static List<List<EffectBase>> Deserialize()
            {
                return Effects = m_effectsBin.ToObject<List<List<EffectBase>>>();
            }

            public static List<List<EffectBase>> Effects
            {
                get;
                set;
            }
        }
    }
}
