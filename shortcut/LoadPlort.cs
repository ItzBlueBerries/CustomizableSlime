using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;

namespace CustomizableSlime.shortcut
{
    internal class CustomizablePlort
    {
        public static void LoadPlort()
        {
            GameObject customizedPlort = Slime.CreatePlort(ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE, Ids.CUSTOMIZABLE_PLORT, ConfigurationPlort.PLORT_NAME, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\plort_icon.png")), ConfigPlort.PlortVacpackColor, ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE, ConfigurationPlort.PLORT_PRICE, ConfigurationPlort.PLORT_SATURATION, ConfigurationPlort.VACPACK_SIZE);
            customizedPlort.transform.localScale *= ConfigurationAdvanced.PLORT_LOCAL_SCALE;

            if (ConfigurationAdditional.RANDOM_PLORT_COLORS)
            {
                Slime.ColorPlort(Ids.CUSTOMIZABLE_PLORT, 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(), 
                    RandomFunc.RandomColor32(),
                    ConfigurationPlort.HAS_ROCKS
                );
            }
            else
            {
                Slime.ColorPlort(Ids.CUSTOMIZABLE_PLORT, ConfigPlort.PlortColorVar1, ConfigPlort.PlortColorVar2, ConfigPlort.PlortColorVar3, ConfigPlort.RockColorVar1, ConfigPlort.RockColorVar2, ConfigPlort.RockColorVar3, ConfigurationPlort.HAS_ROCKS);
            }
        }
    }
}
