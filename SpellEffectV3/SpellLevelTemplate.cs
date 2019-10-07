using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellEffectV3
{
    public static class SpellLevelTemplate
    {
        public static int selectedSpell_LevelID;

        public static class EffectsBinInstance
        {
            public static byte[] m_effectsBin;
            public static List<EffectDice> m_effects;

            public static void Initialize(byte[] value)
            {
                m_effectsBin = value;
                m_effects = EffectManager.Instance.DeserializeEffects(EffectsBin).Cast<EffectDice>().ToList();
            }

            private static byte[] EffectsBin
            {
                get { return m_effectsBin; }
                set
                {
                    m_effectsBin = value;
                    m_effects = EffectManager.Instance.DeserializeEffects(EffectsBin).Cast<EffectDice>().ToList();
                }
            }
        }

        public static class CriticalEffectsBinInstance
        {
            public static byte[] m_criticalEffectsBin;
            public static List<EffectDice> m_criticalEffects;

            public static void Initialize(byte[] value)
            {
                m_criticalEffectsBin = value;
                m_criticalEffects = EffectManager.Instance.DeserializeEffects(CriticalEffectsBin).Cast<EffectDice>().ToList();
            }

            private static byte[] CriticalEffectsBin
            {
                get { return m_criticalEffectsBin; }
                set
                {
                    m_criticalEffectsBin = value;
                    m_criticalEffects = EffectManager.Instance.DeserializeEffects(CriticalEffectsBin).Cast<EffectDice>().ToList();
                }
            }
        }
    }
}
