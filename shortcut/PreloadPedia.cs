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
                ConfigurationPedia.SLIMEPEDIA_TITLE,
                ConfigurationPedia.SLIMEPEDIA_INTRO,
                ConfigurationPedia.SLIMEPEDIA_DIET,
                ConfigurationPedia.SLIMEPEDIA_FAVORITE,
                ConfigurationPedia.SLIMEPEDIA_SLIMEOLOGY,
                ConfigurationPedia.SLIMEPEDIA_RISKS,
                ConfigurationPedia.SLIMEPEDIA_PLORTONOMICS
            );
        }
    }
}
