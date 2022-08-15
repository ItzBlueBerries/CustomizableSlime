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

namespace CustomizableSlime.shortcut
{
    internal class CustomizableSlime
    {
        public static void LoadSlime()
        {
            (SlimeDefinition, GameObject, SlimeAppearance) customizedSlime = Slime.CreateSlime(ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE, ConfigurationSlime.WHAT_SLIME_ACTS_LIKE, Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.SLIME_NAME, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_Icon.png")), ConfigSlime.VacpackColor, ConfigSlime.SplatColor1, ConfigSlime.SplatColor2, ConfigSlime.SplatColor3, ConfigSlime.VacpackColor, ConfigurationSlime.VACPACK_SIZE);

            SlimeDefinition customDef = customizedSlime.Item1;
            GameObject customObj = customizedSlime.Item2;
            SlimeAppearance customApp = customizedSlime.Item3;

            SlimeRandomMove customMove = customObj.GetComponent<SlimeRandomMove>();

            customDef.Diet.Produces = new Identifiable.Id[] { ConfigurationSlime.WHAT_SLIME_PRODUCES };
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

            SlimeAppearanceStructure[] structures = customApp.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                    {
                        Material slimeMaterial = Slime.ColorSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE, 
                            RandomFunc.RandomColor32(), RandomFunc.RandomColor32(), RandomFunc.RandomColor32(), RandomFunc.RandomColor32());
                        slimeAppearanceStructure.DefaultMaterials[0] = slimeMaterial;
                    }
                    else
                    {
                        Material slimeMaterial = Slime.ColorSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE, ConfigSlime.SlimeColorVar1, ConfigSlime.SlimeColorVar2, ConfigSlime.SlimeColorVar3, ConfigSlime.SlimeColorVar1);
                        slimeAppearanceStructure.DefaultMaterials[0] = slimeMaterial;
                    }

                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.RAD_SLIME)
                    {
                        if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                        {
                            Randoms random = new Randoms();
                            Material radMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            radMaterial.SetColor("_MiddleColor", RandomFunc.RandomColor32());
                            radMaterial.SetColor("_EdgeColor", RandomFunc.RandomColor32());
                            customApp.Structures[1].DefaultMaterials[0] = radMaterial;
                        }
                        else
                        {
                            Material radMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                            radMaterial.SetColor("_MiddleColor", ConfigStruct.RadAuraMiddle);
                            radMaterial.SetColor("_EdgeColor", ConfigStruct.RadAuraEdge);
                            customApp.Structures[1].DefaultMaterials[0] = radMaterial;
                        }
                    }
                }
            }

            SlimeExpressionFace[] expressionFaces = customApp.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];

                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", ConfigSlime.MouthColorVar1);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", ConfigSlime.MouthColorVar2);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", ConfigSlime.MouthColorVar3);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", ConfigSlime.EyesColorVar1);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", ConfigSlime.EyesColorVar2);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", ConfigSlime.EyesColorVar3);
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
