using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModEnchantments
{
    class MetaData
    {
        public MetaData(string[] input)
        {
            _enchantments = new Dictionary<string, Enchant>()
            {
                {"ef",new Enchant("Efficency","DIG_SPEED")},
                {"un",new Enchant("Unbreaking","DURABILITY")},
                {"fo",new Enchant("Fortune","LOOT_BONUS_BLOCKS")},
                {"st",new Enchant("Silk Touch","SILK_TOUCH")},
                {"lr",new Enchant("Lure","LURE")},
                {"lc",new Enchant("Luck of the Sea","Luck")},
                {"po",new Enchant("Power","ARROW_DAMAGE")},
                {"fl",new Enchant("Flame","ARROW_FIRE")},
                {"pu",new Enchant("Punch","ARROW_KNOCKBACK")},
                {"in",new Enchant("Infinity","ARROW_INFINITE")},
                {"kn",new Enchant("Knockback","KNOCKBACK")},
                {"sh",new Enchant("Sharpness","DAMAGE_ALL")},
                {"sm",new Enchant("Smite","DAMAGE_UNDEAD")},
                {"fa",new Enchant("Fire Aspect","FIRE_ASPECT")},
                {"ba",new Enchant("Bane of Arthropods","DAMAGE_ARTHROPODS")},
                {"pr",new Enchant("Protection","PROTECTION_ENVIRONMENTAL")},
                {"pp",new Enchant("Projectile Protection","PROTECTION_PROJECTILE")},
                {"aa",new Enchant("Aqua Affinity","WATER_WORKER")},
                {"re",new Enchant("Respiration","OXYGEN")},
                {"fp",new Enchant("Fire Protection","PROTECTION_FIRE")},
                {"bp",new Enchant("Blast Protection","PROTECTION_EXPLOSIONS")},
                {"th",new Enchant("Throns","THORNS")}
            };

            this._input = input;
            _output = new List<string>();

            genYAML();            
        }

        public string[] input { set { _input = value; } }
        private string[] _input;

        private List<string> _output;
        public List<string> output { get { return this._output; } }

        private string[] _enchantForm = {
                                     "    enchantments:",
                                     "      ",
                                     "        type: ",
                                     "        level: ",
                                     "        probability: "
                                   };

        private Dictionary<string, Enchant> _enchantments;

        public void genYAML()
        {
            foreach (string line in _input)
            {
                string[] splt = line.Split(':');
                string[] mats = splt[0].Split(';');
                StringBuilder sb = new StringBuilder();

                if (mats.Length > 0)
                {
                    sb.Append("  Enchanter_");
                    sb.Append(mats[0].Replace(' ', '_'));
                    sb.Append(":");
                    _output.Add(sb.ToString());
                    sb.Clear();

                    sb.Append("    name: Enchanter ");
                    sb.Append(mats[0]);
                    _output.Add(sb.ToString());
                    sb.Clear();

                    sb.Append("    production_time: 10");
                    _output.Add(sb.ToString());
                    sb.Clear();

                    sb.Append("    inputs:");
                    _output.Add(sb.ToString());
                    sb.Clear();

                    for (int i = 1; i < mats.Length; i = i + 2)
                    {

                        {
                            sb.Append("      ");
                            sb.Append(mats[i]);
                            sb.Append(":");
                            _output.Add(sb.ToString());
                            sb.Clear();

                            sb.Append("        material: ");
                            sb.Append(mats[i].ToUpper().Replace(' ', '_'));
                            _output.Add(sb.ToString());
                            sb.Clear();

                            sb.Append("        amount: ");
                            sb.Append(mats[i + 1]);
                            _output.Add(sb.ToString());
                            sb.Clear();
                        }
                    }
                }

                //Output

                for (int i = 1; i < mats.Length; i++)
                {
                    if (mats[i].Equals(mats[0]))
                    {
                        sb.Append("    outputs:");
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append("      Enchanted ");
                        sb.Append(mats[i]);
                        sb.Append(":");
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append("        material: ");
                        sb.Append(mats[i].ToUpper().Replace(' ', '_'));
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append("        amount: ");
                        sb.Append(mats[i + 1]);
                        _output.Add(sb.ToString());
                        sb.Clear();
                    }
                }


                //Enchantments
                if (splt.Length > 0)
                {
                    sb.Append(_enchantForm[0]);
                    _output.Add(sb.ToString());
                    sb.Clear();
                }

                foreach (string ench in splt)
                {
                    if (!splt[0].Equals(ench))
                    {
                        string[] info = ench.Split(';');

                        sb.Append(_enchantForm[1]);
                        sb.Append(_enchantments[info[0]].name);
                        sb.Append(" ");
                        sb.Append(info[1]);
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append(_enchantForm[2]);
                        sb.Append(_enchantments[info[0]].bukkit);
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append(_enchantForm[3]);
                        sb.Append(info[1]);
                        _output.Add(sb.ToString());
                        sb.Clear();

                        sb.Append(_enchantForm[4]);
                        sb.Append(info[2]);
                        _output.Add(sb.ToString());
                        sb.Clear();
                    }
                }
            }
        }
    }
}
