using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomizableSlime.shortcut;
using System.IO;
using static ShortcutLib.Shortcut;
using static ShortcutLib.Debugging;
using CustomizableSlime.behaviours;
using UnityEngine;
using SRML.Utils;
using SRML.SR.SaveSystem;

namespace CustomizableSlime
{
    public class Main : ModEntryPoint
    {
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            Checks.AssetsCheck();
            Enum.Parse(typeof(Identifiable.Id), ConfigurationSlime.WHAT_SLIME_PRODUCES);
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
            shortcut.CustomizableSlime.LoadStyle();

            if (ConfigurationSlime.CAN_LARGOFY)
            { CustomizableLargos.LoadLargos(); }
        }

        public override void PostLoad() { }
    }
}