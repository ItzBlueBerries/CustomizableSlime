using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using static OtherFunc;

namespace CustomizableSlime.shortcut
{
    internal class CustomizablePlort
    {
        public static void LoadPlort()
        {
            var PlortTopC = StringToByte(ConfigurationPlort.PLORT_TOP_COLOR_RGB);
            var PlortMidC = StringToByte(ConfigurationPlort.PLORT_MIDDLE_COLOR_RGB);
            var PlortBotC = StringToByte(ConfigurationPlort.PLORT_BOTTOM_COLOR_RGB);
            var VacC = StringToByte(ConfigurationPlort.PLORT_VAC_COLOR_RGB);

            var RocksTopC = StringToByte(ConfigurationPlort.ROCKS_TOP_COLOR_RGB);
            var RocksMidC = StringToByte(ConfigurationPlort.ROCKS_MIDDLE_COLOR_RGB);
            var RocksBotC = StringToByte(ConfigurationPlort.ROCKS_BOTTOM_COLOR_RGB);

            GameObject customizedPlort = Slime.CreatePlort(ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE, Ids.CUSTOMIZABLE_PLORT, ConfigurationPlort.PLORT_NAME, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\plort_icon.png")), new Color32(VacC[0], VacC[1], VacC[2], byte.MaxValue), ConfigurationPlort.PLORT_PRICE, ConfigurationPlort.PLORT_SATURATION, ConfigurationPlort.VACPACK_SIZE);
            customizedPlort.transform.localScale *= ConfigurationAdvanced.PLORT_LOCAL_SCALE;

            if (ConfigurationAdditional.RANDOM_PLORT_COLORS)
            {
                Slime.ColorPlort(Ids.CUSTOMIZABLE_PLORT, 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(),
                    ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE,
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(),
                    ConfigurationPlort.HAS_ROCKS
                );
            }
            else
            {
                Slime.ColorPlort(Ids.CUSTOMIZABLE_PLORT,
                    new Color32(PlortTopC[0], PlortTopC[1], PlortTopC[2], byte.MaxValue),
                    new Color32(PlortMidC[0], PlortMidC[1], PlortMidC[2], byte.MaxValue),
                    new Color32(PlortBotC[0], PlortBotC[1], PlortBotC[2], byte.MaxValue),
                    ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE,
                    new Color32(RocksTopC[0], RocksTopC[1], RocksTopC[2], byte.MaxValue),
                    new Color32(RocksMidC[0], RocksMidC[1], RocksMidC[2], byte.MaxValue),
                    new Color32(RocksBotC[0], RocksBotC[1], RocksBotC[2], byte.MaxValue), 
                    ConfigurationPlort.HAS_ROCKS
                );
            }
        }
    }
}
