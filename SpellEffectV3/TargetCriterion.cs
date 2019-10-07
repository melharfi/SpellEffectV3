using DofusItemSpellEditor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellEffectV3
{
    public abstract class TargetCriterion
    {
        static readonly Dictionary<char, SpellTargetType> m_targetsMapping = new Dictionary<char, SpellTargetType>
        {
            {'C', SpellTargetType.SELF_ONLY},
            {'c', SpellTargetType.SELF},

            {'s', SpellTargetType.ALLY_MONSTER_SUMMON},
            {'j', SpellTargetType.ALLY_SUMMON},
            {'i', SpellTargetType.ALLY_NON_MONSTER_SUMMON},
            {'d', SpellTargetType.ALLY_COMPANION},
            {'m', SpellTargetType.ALLY_MONSTER},
            {'h', SpellTargetType.ALLY_SUMMONER},
            {'l', SpellTargetType.ALLY_PLAYER},

            {'a', SpellTargetType.ALLY_ALL},
            {'g', SpellTargetType.ALLY_ALL_EXCEPT_SELF},

            {'S', SpellTargetType.ENEMY_MONSTER_SUMMON},
            {'J', SpellTargetType.ENEMY_SUMMON},
            {'I', SpellTargetType.ENEMY_NON_MONSTER_SUMMON},
            {'D', SpellTargetType.ENEMY_COMPANION},
            {'M', SpellTargetType.ENEMY_MONSTER},
            {'H', SpellTargetType.ENEMY_UNKN_1},
            {'L', SpellTargetType.ENEMY_PLAYER},

            {'A', SpellTargetType.ENEMY_ALL},
        };


        public virtual bool IsDisjonction => true;

        public virtual bool CheckWhenExecute => false;

        public static TargetCriterion ParseCriterion(string str)
        {
            try
            {
                var caster = str[0] == '*';

                if (caster)
                    str = str.Remove(0, 1);

                if (m_targetsMapping.ContainsKey(str[0]))
                {
                    return new TargetTypeCriterion(m_targetsMapping[str[0]], caster);
                }

                switch (str[0])
                {
                    case 'e':
                        return new StateCriterion(int.Parse(str.Remove(0, 1)), caster, false);
                    case 'E':
                        return new StateCriterion(int.Parse(str.Remove(0, 1)), caster, true);
                    case 'f':
                        return new MonsterCriterion(int.Parse(str.Remove(0, 1)), false);
                    case 'F':
                        return new MonsterCriterion(int.Parse(str.Remove(0, 1)), true);
                    case 'v':
                        return new LifeCriterion(int.Parse(str.Remove(0, 1)), true);
                    case 'V':
                        return new LifeCriterion(int.Parse(str.Remove(0, 1)), false);
                    case 'K':
                        return new CarriedCriterion();
                    case 'T':
                        return new TelefragCriterion();
                    case 'P':
                        return new SummonerCriterion(true);
                    case 'p':
                        return new SummonerCriterion(false);
                    case 'U':
                        return new JustSummonedCriterion();
                    case 'b':
                        return new BreedCriterion(int.Parse(str.Remove(0, 1)), caster, false);
                    case 'B':
                        return new BreedCriterion(int.Parse(str.Remove(0, 1)), caster, true);
                    case 'O':
                        return new LastAttackerCriterion(true);
                    case 'o':
                        return new LastAttackerCriterion(false);
                }

                return new UnknownCriterion(str);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid target criterion : " + str, ex);
            }
        }
    }
}
