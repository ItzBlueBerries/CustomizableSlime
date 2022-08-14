using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomizableSlime.shortcut
{
    internal class ConfigSlime
    {

        // - VAC & SPLAT COLOR - \\

        public static Color32 VacpackColor = new Color32(
            ConfigurationVacSplat.SLIME_VAC_COLOR_R,
            ConfigurationVacSplat.SLIME_VAC_COLOR_G,
            ConfigurationVacSplat.SLIME_VAC_COLOR_B,
            byte.MaxValue
         );

        public static Color32 SplatColor1 = new Color32(
            ConfigurationVacSplat.SPLAT_TOP_COLOR_R,
            ConfigurationVacSplat.SPLAT_TOP_COLOR_G,
            ConfigurationVacSplat.SPLAT_TOP_COLOR_B,
            byte.MaxValue
        );

        public static Color32 SplatColor2 = new Color32(
            ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_R,
            ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_G,
            ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_B, byte.MaxValue
        );

        public static Color32 SplatColor3 = new Color32(
            ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_R,
            ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_G,
            ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_B,
            byte.MaxValue
        );

        // - SLIME COLOR - \\

        public static Color32 SlimeColorVar1 = new Color32(
            ConfigurationSlime.SLIME_TOP_COLOR_R,
            ConfigurationSlime.SLIME_TOP_COLOR_G,
            ConfigurationSlime.SLIME_TOP_COLOR_B,
            byte.MaxValue
        );

        public static Color32 SlimeColorVar2 = new Color32(
            ConfigurationSlime.SLIME_MIDDLE_COLOR_R,
            ConfigurationSlime.SLIME_MIDDLE_COLOR_G,
            ConfigurationSlime.SLIME_MIDDLE_COLOR_B,
            byte.MaxValue
        );

        public static Color32 SlimeColorVar3 = new Color32(
            ConfigurationSlime.SLIME_BOTTOM_COLOR_R,
            ConfigurationSlime.SLIME_BOTTOM_COLOR_G,
            ConfigurationSlime.SLIME_BOTTOM_COLOR_B,
            byte.MaxValue
        );

        // - FACE - \\

        public static Color32 MouthColorVar1 = new Color32(
            ConfigurationSlime.MOUTH_TOP_COLOR_R, 
            ConfigurationSlime.MOUTH_TOP_COLOR_G, 
            ConfigurationSlime.MOUTH_TOP_COLOR_B, 
            byte.MaxValue
        );

        public static Color32 MouthColorVar2 = new Color32(
            ConfigurationSlime.MOUTH_MIDDLE_COLOR_R, 
            ConfigurationSlime.MOUTH_MIDDLE_COLOR_G, 
            ConfigurationSlime.MOUTH_MIDDLE_COLOR_B, 
            byte.MaxValue
        );

        public static Color32 MouthColorVar3 = new Color32(ConfigurationSlime.MOUTH_BOTTOM_COLOR_R, 
            ConfigurationSlime.MOUTH_BOTTOM_COLOR_G, 
            ConfigurationSlime.MOUTH_BOTTOM_COLOR_B, 
            byte.MaxValue
        );

        public static Color32 EyesColorVar1 = new Color32(
            ConfigurationSlime.EYES_TOP_COLOR_R, 
            ConfigurationSlime.EYES_TOP_COLOR_G, 
            ConfigurationSlime.EYES_TOP_COLOR_B, 
            byte.MaxValue
        );

        public static Color32 EyesColorVar2 = new Color32(
            ConfigurationSlime.EYES_MIDDLE_COLOR_R, 
            ConfigurationSlime.EYES_MIDDLE_COLOR_G, 
            ConfigurationSlime.EYES_MIDDLE_COLOR_B, 
            byte.MaxValue
        );

        public static Color32 EyesColorVar3 = new Color32(
            ConfigurationSlime.EYES_BOTTOM_COLOR_R, 
            ConfigurationSlime.EYES_BOTTOM_COLOR_G,
            ConfigurationSlime.EYES_BOTTOM_COLOR_B, 
            byte.MaxValue
        );
    }

    public class ConfigPlort
    {
        
        // - VAC COLOR - \\

        public static Color32 PlortVacpackColor = new Color32(
            ConfigurationVacSplat.PLORT_VAC_COLOR_R,
            ConfigurationVacSplat.PLORT_VAC_COLOR_G,
            ConfigurationVacSplat.PLORT_VAC_COLOR_B,
            byte.MaxValue
         );

        // - PLORT COLOR - \\

        public static Color32 PlortColorVar1 = new Color32(
            ConfigurationPlort.TOP_COLOR_R,
            ConfigurationPlort.TOP_COLOR_G,
            ConfigurationPlort.TOP_COLOR_B,
            byte.MaxValue
        );

        public static Color32 PlortColorVar2 = new Color32(
            ConfigurationPlort.MIDDLE_COLOR_R,
            ConfigurationPlort.MIDDLE_COLOR_G,
            ConfigurationPlort.MIDDLE_COLOR_B,
            byte.MaxValue
        );

        public static Color32 PlortColorVar3 = new Color32(
            ConfigurationPlort.BOTTOM_COLOR_R,
            ConfigurationPlort.BOTTOM_COLOR_G,
            ConfigurationPlort.BOTTOM_COLOR_B,
            byte.MaxValue
        );

        // - ROCK ADDITIONAL COLOR - \\

        public static Color32 RockColorVar1 = new Color32(
            ConfigurationPlort.ROCKS_TOP_COLOR_R,
            ConfigurationPlort.ROCKS_TOP_COLOR_G,
            ConfigurationPlort.ROCKS_TOP_COLOR_B,
            byte.MaxValue
        );

        public static Color32 RockColorVar2 = new Color32(
            ConfigurationPlort.ROCKS_MIDDLE_COLOR_R,
            ConfigurationPlort.ROCKS_MIDDLE_COLOR_G,
            ConfigurationPlort.ROCKS_MIDDLE_COLOR_B,
            byte.MaxValue
        );

        public static Color32 RockColorVar3 = new Color32(
            ConfigurationPlort.ROCKS_BOTTOM_COLOR_R,
            ConfigurationPlort.ROCKS_BOTTOM_COLOR_G,
            ConfigurationPlort.ROCKS_BOTTOM_COLOR_B,
            byte.MaxValue
        );
    }

    public class ConfigStruct
    {
        // - RAD AURA - \\

        public static Color32 RadAuraMiddle = new Color32(
            ConfigurationStrucConfig.RAD_AURA_MIDDLE_R,
            ConfigurationStrucConfig.RAD_AURA_MIDDLE_G,
            ConfigurationStrucConfig.RAD_AURA_MIDDLE_B,
            byte.MaxValue
        );

        public static Color32 RadAuraEdge = new Color32(
            ConfigurationStrucConfig.RAD_AURA_EDGE_R,
            ConfigurationStrucConfig.RAD_AURA_EDGE_G,
            ConfigurationStrucConfig.RAD_AURA_EDGE_B,
            byte.MaxValue
        );
    }
}
