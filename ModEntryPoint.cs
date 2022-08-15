using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomizableSlime.shortcut;
using System.IO;

namespace CustomizableSlime
{
    public class Main : ModEntryPoint
    {

        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            Checks.AssetsCheck();
            if (ConfigurationSlime.CAN_LARGOFY)
            { CustomizableLargos.CreateIdentifiables(); }
            TranslationPatcher.AddUITranslation("m.foodgroup.plorts", "Plorts");
            TranslationPatcher.AddUITranslation("m.foodgroup.nontarrgold_slimes", "Slimes");
            CustomizablePedia.PreLoadPredia();
            shortcut.CustomizableSlime.PreloadSpawn();
        }

        public override void Load()
        {
            /*CustomizableSlime.LoadCustomizedSlime();
            CustomizablePlort.LoadCustomizedPlort();*/

            shortcut.CustomizableSlime.LoadSlime();
            CustomizablePlort.LoadPlort();

            if (ConfigurationSlime.CAN_LARGOFY)
            { CustomizableLargos.LoadLargos(); }
        }

        public override void PostLoad()
        {

        }

    }
}