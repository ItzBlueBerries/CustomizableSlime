using SRML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SRML.SR.SlimeRegistry;

namespace CustomizableSlime.shortcut
{
    internal class CustomizableLargos
    {
        public static void CreateIdentifiables()
        {
            LargoIds.CUSTOMIZABLE_PINK_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_PINK_LARGO");
            LargoIds.CUSTOMIZABLE_ROCK_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_ROCK_LARGO");
            LargoIds.CUSTOMIZABLE_TABBY_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_TABBY_LARGO");
            LargoIds.CUSTOMIZABLE_BOOM_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_BOOM_LARGO");
            LargoIds.CUSTOMIZABLE_CRYSTAL_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_CRYSTAL_LARGO");
            LargoIds.CUSTOMIZABLE_DERVISH_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_DERVISH_LARGO");
            LargoIds.CUSTOMIZABLE_FIRE_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_FIRE_LARGO");
            LargoIds.CUSTOMIZABLE_PUDDLE_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_PUDDLE_LARGO");
            LargoIds.CUSTOMIZABLE_HONEY_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_HONEY_LARGO");
            LargoIds.CUSTOMIZABLE_HUNTER_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_HUNTER_LARGO");
            LargoIds.CUSTOMIZABLE_MOSAIC_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_MOSAIC_LARGO");
            LargoIds.CUSTOMIZABLE_PHOSPHOR_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_PHOSPHOR_LARGO");
            LargoIds.CUSTOMIZABLE_QUANTUM_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_QUANTUM_LARGO");
            LargoIds.CUSTOMIZABLE_RAD_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_RAD_LARGO");
            LargoIds.CUSTOMIZABLE_SABER_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_SABER_LARGO");
            LargoIds.CUSTOMIZABLE_TANGLE_LARGO = SRML.SR.IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), "CUSTOMIZABLE_TANGLE_LARGO");
        }

        public static void LoadLargos()
        {
            LargoProps array =
            LargoProps.REPLACE_BASE_MAT_AS_SLIME2 |
            LargoProps.RECOLOR_BASE_MAT_AS_SLIME1 |
            LargoProps.RECOLOR_SLIME2_ADDON_MATS |
            LargoProps.SWAP_EYES |
            LargoProps.SWAP_MOUTH |
            LargoProps.GENERATE_NAME;

            CraftLargo(LargoIds.CUSTOMIZABLE_PINK_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.PINK_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_ROCK_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.ROCK_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_TABBY_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.TABBY_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_BOOM_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.BOOM_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_CRYSTAL_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.CRYSTAL_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_DERVISH_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.DERVISH_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_FIRE_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.FIRE_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_PUDDLE_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.PUDDLE_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_HONEY_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.HONEY_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_HUNTER_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.HUNTER_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_MOSAIC_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.MOSAIC_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_PHOSPHOR_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.PHOSPHOR_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_QUANTUM_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.QUANTUM_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_RAD_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.RAD_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_SABER_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.SABER_SLIME, array);
            CraftLargo(LargoIds.CUSTOMIZABLE_TANGLE_LARGO, Ids.CUSTOMIZABLE_SLIME, Identifiable.Id.TANGLE_SLIME, array);
        }
    }
}
