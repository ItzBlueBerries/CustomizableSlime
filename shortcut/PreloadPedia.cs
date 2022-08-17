using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableSlime.shortcut
{
    internal class CustomizablePedia
    {
        public static void PreLoadPredia()
        {
            ShortcutLib.Shortcut.Translate.CreateSlimepedia(
                Ids.CUSTOMIZABLE_SLIME,
                Ids.CUSTOMIZABLE_SLIME_ENTRY,
                OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png")),
                ConfigurationSlime.SLIMEPEDIA_TITLE,
                ConfigurationSlime.SLIMEPEDIA_INTRO,
                ConfigurationSlime.SLIMEPEDIA_DIET,
                ConfigurationSlime.SLIMEPEDIA_FAVORITE,
                ConfigurationSlime.SLIMEPEDIA_SLIMEOLOGY,
                ConfigurationSlime.SLIMEPEDIA_RISKS,
                ConfigurationSlime.SLIMEPEDIA_PLORTONOMICS
            );
        }
    }
}
