using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using SRML.SR;
using SRML.SR.Utils;
using CustomizableSlime.behaviours;
using MonomiPark.SlimeRancher.Regions;
using static OtherFunc;

namespace CustomizableSlime.shortcut
{
    internal class CustomizableSlime
    {
        public static void LoadSlime()
        {
            var SplatTopC = StringToByte(ConfigurationSlime.SPLAT_TOP_COLOR_RGB);
            var SplatMidC = StringToByte(ConfigurationSlime.SPLAT_MIDDLE_COLOR_RGB);
            var SplatBotC = StringToByte(ConfigurationSlime.SPLAT_BOTTOM_COLOR_RGB);
            var VacC = StringToByte(ConfigurationSlime.SLIME_VAC_COLOR_RGB);

            (SlimeDefinition, GameObject, SlimeAppearance) customizedSlime = Slime.CreateSlime(ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE, ConfigurationSlime.WHAT_SLIME_ACTS_LIKE, Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.SLIME_NAME, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_Icon.png")), 
                new Color32(VacC[0], VacC[1], VacC[2], byte.MaxValue),
                new Color32(SplatTopC[0], SplatTopC[1], SplatTopC[2], byte.MaxValue),
                new Color32(SplatMidC[0], SplatMidC[1], SplatMidC[2], byte.MaxValue),
                new Color32(SplatBotC[0], SplatBotC[1], SplatBotC[2], byte.MaxValue),
                new Color32(VacC[0], VacC[1], VacC[2], byte.MaxValue), ConfigurationSlime.VACPACK_SIZE);

            SlimeDefinition customDef = customizedSlime.Item1;
            GameObject customObj = customizedSlime.Item2;
            SlimeAppearance customApp = customizedSlime.Item3;

            SlimeRandomMove customMove = customObj.GetComponent<SlimeRandomMove>();

            customDef.Diet.Produces = new Identifiable.Id[] { (Identifiable.Id)Enum.Parse(typeof(Identifiable.Id), ConfigurationSlime.WHAT_SLIME_PRODUCES) };
            customDef.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[] { ConfigurationSlime.WHAT_SLIME_EATS };
            customDef.Diet.Favorites = new Identifiable.Id[] { ConfigurationSlime.FAVORITE_SLIME_EATS };
            customDef.Diet.AdditionalFoods = new Identifiable.Id[] { ConfigurationSlime.ADDITIONAL_FOOD_SLIME_EATS };
            customDef.CanLargofy = ConfigurationSlime.CAN_LARGOFY;
            customDef.FavoriteToys = new Identifiable.Id[] { ConfigurationSlime.FAVORITE_SLIME_TOY };

            customObj.transform.localScale *= ConfigurationAdvanced.SLIME_LOCAL_SCALE;

            if (ConfigurationSlime.TARR_SUPPORT)
            {
                SlimeDefinition slimeByIdentifiableId = Slime.GetSlimeDef(Identifiable.Id.TARR_SLIME);
                slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
                {
                    Ids.CUSTOMIZABLE_SLIME
                };
            }

            if (ConfigurationEatMap.TRANSFORM_EATMAP)
            {
                customDef.AddEatMapEntry(new SlimeDiet.EatMapEntry()
                {
                    becomesId = ConfigurationEatMap.TRANSFORM_WHAT_SLIME_BECOMES,
                    eats = ConfigurationEatMap.TRANSFORM_WHAT_SLIME_EATS,
                    driver = ConfigurationEatMap.TRANSFORM_EAT_DRIVER,
                    minDrive = ConfigurationEatMap.TRANSFORM_MIN_DRIVE,
                    extraDrive = ConfigurationEatMap.TRANSFORM_EXTRA_DRIVE
                });
            } 
            if (ConfigurationEatMap.PRODUCE_EATMAP)
            {
                customDef.AddEatMapEntry(new SlimeDiet.EatMapEntry()
                {
                    producesId = ConfigurationEatMap.PRODUCE_WHAT_SLIME_PRODUCES,
                    eats = ConfigurationEatMap.PRODUCE_WHAT_SLIME_EATS,
                    driver = ConfigurationEatMap.PRODUCE_EAT_DRIVER,
                    minDrive = ConfigurationEatMap.PRODUCE_MIN_DRIVE,
                    isFavorite = ConfigurationEatMap.PRODUCE_IS_FAVORITE_FOOD,
                    favoriteProductionCount = ConfigurationEatMap.PRODUCE_FAVORITE_PRODUCTION_COUNT,
                    extraDrive = ConfigurationEatMap.PRODUCE_EXTRA_DRIVE
                });
            }

            CustomizableBehaviours.LoadBehaviours();
            customMove.scootSpeedFactor = ConfigurationAdvanced.SLIME_SPEED_FACTOR;
            customMove.verticalFactor = ConfigurationAdvanced.SLIME_VERTICAL_FACTOR;

            if (ConfigurationAdditional.REMOVE_PHOSPHOR_ANTENNAS && ConfigurationAdditional.REMOVE_PHOSPHOR_WINGS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
            {
                customApp.Structures = new SlimeAppearanceStructure[]
                {
                    new SlimeAppearanceStructure(customApp.Structures[0])
                };
            }
            else if (ConfigurationAdditional.REMOVE_PHOSPHOR_ANTENNAS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
            {
                customApp.Structures = new SlimeAppearanceStructure[]
                {
                    new SlimeAppearanceStructure(customApp.Structures[0]),
                    Structure.AddStructure(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME), 2)
                };
            }
            else if (ConfigurationAdditional.REMOVE_PHOSPHOR_WINGS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
            {
                customApp.Structures = new SlimeAppearanceStructure[]
                {
                    new SlimeAppearanceStructure(customApp.Structures[0]),
                    Structure.AddStructure(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME), 1)
                };
            }

            SlimeAppearanceStructure[] structures = customApp.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    var SlimeTopC = StringToByte(ConfigurationSlime.SLIME_TOP_COLOR_RGB);
                    var SlimeMidC = StringToByte(ConfigurationSlime.SLIME_MIDDLE_COLOR_RGB);
                    var SlimeBotC = StringToByte(ConfigurationSlime.SLIME_BOTTOM_COLOR_RGB);
                    var SlimeSpeC = StringToByte(ConfigurationSlime.SLIME_SPEC_COLOR_RGB);

                    if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                    {
                        Material slimeMaterial = Slime.ColorSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.WHAT_SLIME_MATERIAL, 
                            RandomFunc.RandomColor32(), RandomFunc.RandomColor32(), RandomFunc.RandomColor32(), RandomFunc.RandomColor32());
                        slimeAppearanceStructure.DefaultMaterials[0] = slimeMaterial;
                    }
                    else
                    {
                        Material slimeMaterial = Slime.ColorSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE,
                            new Color32(SlimeTopC[0], SlimeTopC[1], SlimeTopC[2], byte.MaxValue), 
                            new Color32(SlimeMidC[0], SlimeMidC[1], SlimeMidC[2], byte.MaxValue), 
                            new Color32(SlimeBotC[0], SlimeBotC[1], SlimeBotC[2], byte.MaxValue),
                            new Color32(SlimeSpeC[0], SlimeSpeC[1], SlimeSpeC[2], byte.MaxValue));
                        slimeAppearanceStructure.DefaultMaterials[0] = slimeMaterial;
                    }

                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.RAD_SLIME)
                    {
                        if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                        {
                            Material radMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            radMaterial.SetColor("_MiddleColor", RandomFunc.RandomColor32());
                            radMaterial.SetColor("_EdgeColor", RandomFunc.RandomColor32());
                            customApp.Structures[1].DefaultMaterials[0] = radMaterial;
                        }
                        else
                        {
                            var RadMidC = StringToByte(ConfigurationStrucConfig.RAD_AURA_MIDDLE_RGB);
                            var RadEdgC = StringToByte(ConfigurationStrucConfig.RAD_AURA_EDGE_RGB);

                            Material radMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            radMaterial.SetColor("_MiddleColor", new Color32(RadMidC[0], RadMidC[1], RadMidC[2], byte.MaxValue));
                            radMaterial.SetColor("_EdgeColor", new Color32(RadEdgC[0], RadEdgC[1], RadEdgC[2], byte.MaxValue));
                            customApp.Structures[1].DefaultMaterials[0] = radMaterial;
                        }
                    }
                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
                    {
                        if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                        {
                            Material phosMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                            phosMaterial.SetColor("_GlowTop", RandomFunc.RandomColor32());
                            phosMaterial.SetColor("_GlowMid", RandomFunc.RandomColor32());
                            phosMaterial.SetColor("_GlowBottom", RandomFunc.RandomColor32());
                            customApp.Structures[0].DefaultMaterials[0] = phosMaterial;
                        }
                        else
                        {
                            var PhosTopC = StringToByte(ConfigurationStrucConfig.PHOSPHOR_GLOW_TOP_RGB);
                            var PhosMidC = StringToByte(ConfigurationStrucConfig.PHOSPHOR_GLOW_MID_RGB);
                            var PhosBotC = StringToByte(ConfigurationStrucConfig.PHOSPHOR_GLOW_BOT_RGB);

                            Material phosMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                            phosMaterial.SetColor("_TopColor", new Color32(SlimeTopC[0], SlimeTopC[1], SlimeTopC[2], byte.MaxValue));
                            phosMaterial.SetColor("_MiddleColor", new Color32(SlimeMidC[0], SlimeMidC[1], SlimeMidC[2], byte.MaxValue));
                            phosMaterial.SetColor("_BottomColor", new Color32(SlimeBotC[0], SlimeBotC[1], SlimeBotC[2], byte.MaxValue));
                            phosMaterial.SetColor("_GlowTop", new Color32(PhosTopC[0], PhosTopC[1], PhosTopC[2], byte.MaxValue));
                            phosMaterial.SetColor("_GlowMid", new Color32(PhosMidC[0], PhosMidC[1], PhosMidC[2], byte.MaxValue));
                            phosMaterial.SetColor("_GlowBottom", new Color32(PhosBotC[0], PhosBotC[1], PhosBotC[2], byte.MaxValue));
                            customApp.Structures[0].DefaultMaterials[0] = phosMaterial;
                        }
                    }
                }
            }

            SlimeExpressionFace[] expressionFaces = customApp.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                var MouthTopC = StringToByte(ConfigurationSlime.MOUTH_TOP_COLOR_RGB);
                var MouthMidC = StringToByte(ConfigurationSlime.MOUTH_MIDDLE_COLOR_RGB);
                var MouthBotC = StringToByte(ConfigurationSlime.MOUTH_BOTTOM_COLOR_RGB);

                var EyeTopC = StringToByte(ConfigurationSlime.EYES_TOP_COLOR_RGB);
                var EyeMidC = StringToByte(ConfigurationSlime.EYES_MIDDLE_COLOR_RGB);
                var EyeBotC = StringToByte(ConfigurationSlime.EYES_BOTTOM_COLOR_RGB);

                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(MouthBotC[0], MouthBotC[1], MouthBotC[2], byte.MaxValue));
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(MouthMidC[0], MouthMidC[1], MouthMidC[2], byte.MaxValue));
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(MouthTopC[0], MouthTopC[1], MouthTopC[2], byte.MaxValue));
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(EyeTopC[0], EyeTopC[1], EyeTopC[2], byte.MaxValue));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(EyeMidC[0], EyeMidC[1], EyeMidC[2], byte.MaxValue));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(EyeBotC[0], EyeBotC[1], EyeBotC[2], byte.MaxValue));
                }
            }

            PediaRegistry.RegisterIdEntry(Ids.CUSTOMIZABLE_SLIME_ENTRY, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png")));
        }

        public static void PreloadSpawn()
        {
            if (!ConfigurationAdditional.DISABLE_SPAWNING)
            {
                if (ConfigurationZone.SPAWN_EVERYWHERE)
                {
                    SRCallbacks.PreSaveGameLoad += (s =>
                    {
                        foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                            .Where(ss =>
                            {
                                ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                                return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.RANCH || zone == ZoneDirector.Zone.REEF || zone == ZoneDirector.Zone.QUARRY || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.DESERT || zone == ZoneDirector.Zone.SEA || zone == ZoneDirector.Zone.RUINS || zone == ZoneDirector.Zone.RUINS_TRANSITION || zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.SLIMULATIONS;
                            }))
                        {
                            foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                            {
                                List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                            {
                                new SlimeSet.Member
                                {
                                    prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.CUSTOMIZABLE_SLIME),
                                    weight = ConfigurationZone.SPAWN_CHANCE
                                }
                            };
                                constraint.slimeset.members = members.ToArray();
                            }
                        }
                    });
                }
                else
                {
                    SRCallbacks.PreSaveGameLoad += (s =>
                    {
                        foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                            .Where(ss =>
                            {
                                ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                                return zone == ConfigurationZone.SPAWN_ZONE_1 | zone == ConfigurationZone.SPAWN_ZONE_2 | zone == ConfigurationZone.SPAWN_ZONE_3 | zone == ConfigurationZone.SPAWN_ZONE_4 | zone == ConfigurationZone.SPAWN_ZONE_5;
                            }))
                        {
                            foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                            {
                                List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                                {
                                    new SlimeSet.Member
                                    {
                                        prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.CUSTOMIZABLE_SLIME),
                                        weight = ConfigurationZone.SPAWN_CHANCE
                                    }
                                };
                                constraint.slimeset.members = members.ToArray();
                            }
                        }
                    });
                }
            }
        }
    }
}
