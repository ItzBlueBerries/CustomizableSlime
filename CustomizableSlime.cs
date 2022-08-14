using SRML.SR;
using SRML.SR.Utils;
using SRML.Utils;
using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CustomizableSlime
{
    class CustomizableSlime
    {
        public static (SlimeDefinition, GameObject) CreateSlime(Identifiable.Id SlimeId, String SlimeName)
        {
            // DEFINE
            SlimeDefinition customizedDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE); // make sure to make slimeNameDefiniton your slime name btw-
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(customizedDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
                Ids.CUSTOMIZABLE_PLORT
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
                ConfigurationSlime.WHAT_SLIME_EATS
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[] { ConfigurationSlime.ADDITIONAL_FOOD_SLIME_EATS };
            slimeDefinition.Diet.Favorites = new Identifiable.Id[] { ConfigurationSlime.FAVORITE_SLIME_EATS };
            slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk

            if (ConfigurationSlime.TARR_SUPPORT)
            {
                // TARR SUPPORT (this is if you want it)
                SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
                slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
                {
                    Ids.CUSTOMIZABLE_SLIME
                };
            }

            slimeDefinition.CanLargofy = ConfigurationSlime.CAN_LARGOFY;
            slimeDefinition.FavoriteToys = new Identifiable.Id[] { ConfigurationSlime.FAVORITE_SLIME_TOY };
            slimeDefinition.Name = ConfigurationSlime.SLIME_NAME;
            slimeDefinition.IdentifiableId = Ids.CUSTOMIZABLE_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(ConfigurationSlime.WHAT_SLIME_ACTS_LIKE));
            slimeObject.name = ConfigurationSlime.SLIME_NAME;
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = Ids.CUSTOMIZABLE_SLIME;
            // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(customizedDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;

            /* -- RAD AURA --

            if (ConfigurationStructure.RAD_AURA)
            {
                if (ConfigurationCheck.IS_DERVISH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                } else if (ConfigurationCheck.IS_CRYSTAL_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_FIRE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_GLITCH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_HONEY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_HUNTER_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_LUCKY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_RAD_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0])
                    };
                }
                else if (ConfigurationCheck.IS_ROCK_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_TABBY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_TANGLE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
            }

            // --- TABBY EARS AND TAIL --- \\

            if (ConfigurationStructure.TABBY_EARS_AND_TAIL)
            {
                if (ConfigurationCheck.IS_DERVISH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_CRYSTAL_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_FIRE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_GLITCH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_HONEY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_HUNTER_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_LUCKY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_RAD_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_ROCK_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else if (ConfigurationCheck.IS_TABBY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0])
                    };
                }
                else if (ConfigurationCheck.IS_TANGLE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
                else
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[1])
                    };
                }
            }

            // -- LUCKY COIN -- \\

            if (ConfigurationStructure.LUCKY_COIN)
            {
                if (ConfigurationCheck.IS_DERVISH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_CRYSTAL_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_FIRE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_GLITCH_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_HONEY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_HUNTER_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_LUCKY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[2]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_RAD_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_ROCK_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_TABBY_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else if (ConfigurationCheck.IS_TANGLE_SLIME)
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(slimeAppearance.Structures[1]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
                else
                {
                    slimeAppearance.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(slimeAppearance.Structures[0]),
                        new SlimeAppearanceStructure(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).GetAppearanceForSet(SlimeAppearance.AppearanceSaveSet.CLASSIC).Structures[2])
                    };
                }
            }*/

            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    Color SlimeColorVar1 = new Color32(ConfigurationSlime.SLIME_TOP_COLOR_R, ConfigurationSlime.SLIME_TOP_COLOR_G, ConfigurationSlime.SLIME_TOP_COLOR_B, byte.MaxValue);
                    Color SlimeColorVar2 = new Color32(ConfigurationSlime.SLIME_MIDDLE_COLOR_R, ConfigurationSlime.SLIME_MIDDLE_COLOR_G, ConfigurationSlime.SLIME_MIDDLE_COLOR_B, byte.MaxValue);
                    Color SlimeColorVar3 = new Color32(ConfigurationSlime.SLIME_BOTTOM_COLOR_R, ConfigurationSlime.SLIME_BOTTOM_COLOR_G, ConfigurationSlime.SLIME_BOTTOM_COLOR_B, byte.MaxValue);

                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", SlimeColorVar1);
                    material.SetColor("_MiddleColor", SlimeColorVar2);
                    material.SetColor("_BottomColor", SlimeColorVar3);
                    slimeAppearanceStructure.DefaultMaterials[0] = material;

                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.RAD_SLIME)
                    {
                        Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                        material2.SetColor("_MiddleColor", SlimeColorVar1);
                        material2.SetColor("_EdgeColor", SlimeColorVar2);
                        slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                    }

                    /* -- RAD AURA -- \\

                    if (ConfigurationStructure.RAD_AURA)
                    {
                        if (ConfigurationCheck.IS_DERVISH_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_LUCKY_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_FIRE_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_GLITCH_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HONEY_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HUNTER_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_RAD_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_ROCK_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TABBY_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TANGLE_SLIME)
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else
                        {
                            Color RadColorVar1 = new Color32(ConfigurationStrucConfig.RAD_AURA_MIDDLE_R, ConfigurationStrucConfig.RAD_AURA_MIDDLE_G, ConfigurationStrucConfig.RAD_AURA_MIDDLE_B, byte.MaxValue);
                            Color RadColorVar2 = new Color32(ConfigurationStrucConfig.RAD_AURA_EDGE_R, ConfigurationStrucConfig.RAD_AURA_EDGE_G, ConfigurationStrucConfig.RAD_AURA_EDGE_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_MiddleColor", RadColorVar1);
                            material2.SetColor("_EdgeColor", RadColorVar2);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                    }

                    // -- TABBY EARS AND TAIL -- \\

                    if (ConfigurationStructure.TABBY_EARS_AND_TAIL)
                    {
                        if (ConfigurationCheck.IS_DERVISH_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_LUCKY_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_FIRE_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_GLITCH_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HONEY_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HUNTER_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_RAD_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_ROCK_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TABBY_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TANGLE_SLIME)
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else
                        {
                            Color TabbyColorVar1 = new Color32(ConfigurationStrucConfig.TABBY_TOP_COLOR_R, ConfigurationStrucConfig.TABBY_TOP_COLOR_G, ConfigurationStrucConfig.TABBY_TOP_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar2 = new Color32(ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_R, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_G, ConfigurationStrucConfig.TABBY_MIDDLE_COLOR_B, byte.MaxValue);
                            Color TabbyColorVar3 = new Color32(ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_R, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_G, ConfigurationStrucConfig.TABBY_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TABBY_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", TabbyColorVar1);
                            material2.SetColor("_MiddleColor", TabbyColorVar2);
                            material2.SetColor("_BottomColor", TabbyColorVar3);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                    }

                    // -- LUCKY COIN -- \\

                    if (ConfigurationStructure.LUCKY_COIN)
                    {
                        if (ConfigurationCheck.IS_DERVISH_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_LUCKY_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_FIRE_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_GLITCH_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HONEY_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_HUNTER_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_PHOSPHOR_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[3].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_RAD_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_ROCK_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TABBY_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                        else if (ConfigurationCheck.IS_TANGLE_SLIME)
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[2].DefaultMaterials[0] = material2;
                        }
                        else
                        {
                            Color CoinColorVar1 = new Color32(ConfigurationStrucConfig.COIN_TOP_COLOR_R, ConfigurationStrucConfig.COIN_TOP_COLOR_G, ConfigurationStrucConfig.COIN_TOP_COLOR_B, byte.MaxValue);
                            Color CoinColorVar2 = new Color32(ConfigurationStrucConfig.COIN_MIDDLE_COLOR_R, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_G, ConfigurationStrucConfig.COIN_MIDDLE_COLOR_B, byte.MaxValue);
                            Color CoinColorVar3 = new Color32(ConfigurationStrucConfig.COIN_BOTTOM_COLOR_R, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_G, ConfigurationStrucConfig.COIN_BOTTOM_COLOR_B, byte.MaxValue);
                            Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.LUCKY_SLIME).AppearancesDefault[0].Structures[2].DefaultMaterials[0]);
                            material2.SetColor("_TopColor", CoinColorVar1);
                            material2.SetColor("_MiddleColor", CoinColorVar2);
                            material2.SetColor("_BottomColor", CoinColorVar3);
                            slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
                        }
                    }*/
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];

                Color MouthColorVar1 = new Color32(ConfigurationSlime.MOUTH_TOP_COLOR_R, ConfigurationSlime.MOUTH_TOP_COLOR_G, ConfigurationSlime.MOUTH_TOP_COLOR_B, byte.MaxValue);
                Color MouthColorVar2 = new Color32(ConfigurationSlime.MOUTH_MIDDLE_COLOR_R, ConfigurationSlime.MOUTH_MIDDLE_COLOR_G, ConfigurationSlime.MOUTH_MIDDLE_COLOR_B, byte.MaxValue);
                Color MouthColorVar3 = new Color32(ConfigurationSlime.MOUTH_BOTTOM_COLOR_R, ConfigurationSlime.MOUTH_BOTTOM_COLOR_G, ConfigurationSlime.MOUTH_BOTTOM_COLOR_B, byte.MaxValue);

                Color EyesColorVar1 = new Color32(ConfigurationSlime.EYES_TOP_COLOR_R, ConfigurationSlime.EYES_TOP_COLOR_G, ConfigurationSlime.EYES_TOP_COLOR_B, byte.MaxValue);
                Color EyesColorVar2 = new Color32(ConfigurationSlime.EYES_MIDDLE_COLOR_R, ConfigurationSlime.EYES_MIDDLE_COLOR_G, ConfigurationSlime.EYES_MIDDLE_COLOR_B, byte.MaxValue);
                Color EyesColorVar3 = new Color32(ConfigurationSlime.EYES_BOTTOM_COLOR_R, ConfigurationSlime.EYES_BOTTOM_COLOR_G, ConfigurationSlime.EYES_BOTTOM_COLOR_B, byte.MaxValue);

                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", MouthColorVar1);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", MouthColorVar2);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", MouthColorVar3);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", EyesColorVar1);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", EyesColorVar2);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", EyesColorVar3);
                }
            }
            slimeAppearance.Icon = OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(ConfigurationVacSplat.SPLAT_TOP_COLOR_R, ConfigurationVacSplat.SPLAT_TOP_COLOR_G, ConfigurationVacSplat.SPLAT_TOP_COLOR_B, byte.MaxValue),
                Middle = new Color32(ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_R, ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_G, ConfigurationVacSplat.SPLAT_MIDDLE_COLOR_B, byte.MaxValue),
                Bottom = new Color32(ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_R, ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_G, ConfigurationVacSplat.SPLAT_BOTTOM_COLOR_B, byte.MaxValue),
                Ammo = new Color32(ConfigurationVacSplat.SLIME_VAC_COLOR_R, ConfigurationVacSplat.SLIME_VAC_COLOR_G, ConfigurationVacSplat.SLIME_VAC_COLOR_B, byte.MaxValue)
            };
            PediaRegistry.RegisterIdEntry(Ids.CUSTOMIZABLE_SLIME_ENTRY, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }

        public static void LoadCustomizedSlime()
        {
            (SlimeDefinition, GameObject) CustomizedTuple = CreateSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.SLIME_NAME); //Insert your own Id in the first argumeter

            SlimeDefinition CustomizedDef = CustomizedTuple.Item1;
            GameObject CustomizedObj = CustomizedTuple.Item2;

            Color32 VacpackColorVar = new Color32(ConfigurationVacSplat.SLIME_VAC_COLOR_R, ConfigurationVacSplat.SLIME_VAC_COLOR_G, ConfigurationVacSplat.SLIME_VAC_COLOR_B, byte.MaxValue);

            CustomizedObj.GetComponent<Vacuumable>().size = ConfigurationSlime.VACPACK_SIZE;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CustomizedObj);
            LookupRegistry.RegisterVacEntry(Ids.CUSTOMIZABLE_SLIME, VacpackColorVar, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png")));
            TranslationPatcher.AddPediaTranslation("t." + Ids.CUSTOMIZABLE_SLIME.ToString().ToLower(), ConfigurationSlime.SLIME_NAME);

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(CustomizedObj);
            SlimeRegistry.RegisterSlimeDefinition(CustomizedDef);
        }
    }
}