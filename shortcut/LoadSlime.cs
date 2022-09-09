using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ShortcutLib.Shortcut;
using SRML.SR;
using SRML.SR.Utils;
using MonomiPark.SlimeRancher.Regions;
using static OtherFunc;

namespace CustomizableSlime.shortcut
{
    internal class CustomizableSlime
    {
        internal static (SlimeDefinition, GameObject, SlimeAppearance) customizedSlime;
        public static void LoadSlime()
        {
            var SplatTopC = StringToByte(ConfigurationSlime.SPLAT_TOP_COLOR_RGB);
            var SplatMidC = StringToByte(ConfigurationSlime.SPLAT_MIDDLE_COLOR_RGB);
            var SplatBotC = StringToByte(ConfigurationSlime.SPLAT_BOTTOM_COLOR_RGB);
            var VacC = StringToByte(ConfigurationSlime.SLIME_VAC_COLOR_RGB);

            if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.QUICKSILVER_SLIME)
                ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE = Identifiable.Id.PINK_SLIME;

            customizedSlime = Slime.CreateSlime(ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE, ConfigurationSlime.WHAT_SLIME_ACTS_LIKE, Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.SLIME_NAME, OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\slime_icon.png")), 
                new Color32(VacC[0], VacC[1], VacC[2], byte.MaxValue),
                new Color32(SplatTopC[0], SplatTopC[1], SplatTopC[2], byte.MaxValue),
                new Color32(SplatMidC[0], SplatMidC[1], SplatMidC[2], byte.MaxValue),
                new Color32(SplatBotC[0], SplatBotC[1], SplatBotC[2], byte.MaxValue),
                new Color32(VacC[0], VacC[1], VacC[2], byte.MaxValue), ConfigurationSlime.VACPACK_SIZE);

            SlimeDefinition customDef = customizedSlime.Item1;
            GameObject customObj = customizedSlime.Item2;
            SlimeAppearance customApp = customizedSlime.Item3;

            SlimeRandomMove customMove = customObj.GetComponent<SlimeRandomMove>();

            List<Identifiable.Id> list = new List<Identifiable.Id>();

            foreach (string stringedID in ConfigurationSlime.WHAT_SLIME_PRODUCES)
            {
                list.Add((Identifiable.Id)Enum.Parse(typeof(Identifiable.Id), stringedID));
            }

            customDef.Diet.Produces = list.ToArray();
            customDef.Diet.MajorFoodGroups = ConfigurationSlime.WHAT_SLIME_EATS;
            customDef.Diet.Favorites = ConfigurationSlime.FAVORITE_SLIME_EATS;
            customDef.Diet.AdditionalFoods = ConfigurationSlime.ADDITIONAL_FOOD_SLIME_EATS;
            customDef.CanLargofy = ConfigurationSlime.CAN_LARGOFY;
            customDef.FavoriteToys = ConfigurationSlime.FAVORITE_SLIME_TOY;

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

            SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
            {
                SlimeAppearance.SlimeBone.JiggleBack,
                SlimeAppearance.SlimeBone.JiggleBottom,
                SlimeAppearance.SlimeBone.JiggleFront,
                SlimeAppearance.SlimeBone.JiggleLeft,
                SlimeAppearance.SlimeBone.JiggleRight,
                SlimeAppearance.SlimeBone.JiggleTop
            };

            if (ConfigurationMesh.CUSTOM_MESH_ENABLED)
            {
                if (ConfigurationMesh.CUSTOM_MESH_ENABLED && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.QUANTUM_SLIME)
                    return;
                    (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) customMeshBody = Structure.CreateBasicStructure(LoadAssetBundle("slime_bundle"), ConfigurationMesh.CUSTOM_MESH_OBJ_NAME, "slime_" + ConfigurationMesh.CUSTOM_MESH_OBJ_NAME, SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, ConfigurationMesh.CUSTOM_MESH_RUBBER_EFFECT);
                customMeshBody.Item2.IgnoreLODIndex = ConfigurationMesh.CUSTOM_MESH_IGNORE_LOD_INDEX;
                AssetsLib.MeshUtils.GenerateBoneData(customObj.GetComponent<SlimeAppearanceApplicator>(), customMeshBody.Item2, ConfigurationMesh.CUSTOM_MESH_JIGGLE, ConfigurationMesh.CUSTOM_MESH_SCALE);
                Structure.SetStructureElement(ConfigurationMesh.CUSTOM_MESH_OBJ_NAME, customApp, new SlimeAppearanceObject[] { customMeshBody.Item2 }, 0, false, true);
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
                        Material slimeMaterial = Slime.ColorSlime(Ids.CUSTOMIZABLE_SLIME, ConfigurationSlime.WHAT_SLIME_MATERIAL,
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
                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME || ConfigurationSlime.WHAT_SLIME_MATERIAL == Identifiable.Id.PHOSPHOR_SLIME)
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
                    if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.BOOM_SLIME || ConfigurationSlime.WHAT_SLIME_MATERIAL == Identifiable.Id.BOOM_SLIME)
                    {
                        if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                        {
                            Material boomMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                            boomMaterial.SetColor("_CrackColor", RandomFunc.RandomColor32());
                            customApp.Structures[0].DefaultMaterials[0] = boomMaterial;
                        }
                        else
                        {
                            var BoomCrackC = StringToByte(ConfigurationStrucConfig.BOOM_CRACKS_RGB);

                            Material boomMaterial = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                            boomMaterial.SetColor("_TopColor", new Color32(SlimeTopC[0], SlimeTopC[1], SlimeTopC[2], byte.MaxValue));
                            boomMaterial.SetColor("_MiddleColor", new Color32(SlimeMidC[0], SlimeMidC[1], SlimeMidC[2], byte.MaxValue));
                            boomMaterial.SetColor("_BottomColor", new Color32(SlimeBotC[0], SlimeBotC[1], SlimeBotC[2], byte.MaxValue));
                            boomMaterial.SetColor("_CrackColor", new Color32(BoomCrackC[0], BoomCrackC[1], BoomCrackC[2], byte.MaxValue));
                            customApp.Structures[0].DefaultMaterials[0] = boomMaterial;
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

        public static void LoadStyle()
        {
            if (ConfigurationStyleApp.SECRET_STYLES_ENABLED)
            {
                SlimeAppearance customizedStyle = Style.CreateStyleAppearance(Ids.CUSTOMIZABLE_SLIME, Slime.GetSlimeDef(Ids.CUSTOMIZABLE_SLIME), ConfigurationStyleApp.STYLE_NAME);

                customizedStyle.Icon = CreateSprite(LoadAsset("Images\\exotic_slime_icon.png"));

                var SplatColorTop = StringToByte(ConfigurationStyleApp.SPLAT_TOP_COLOR_RGB);
                var SplatColorMid = StringToByte(ConfigurationStyleApp.SPLAT_MIDDLE_COLOR_RGB);
                var SplatColorBot = StringToByte(ConfigurationStyleApp.SPLAT_BOTTOM_COLOR_RGB);
                var SplatColorAm = StringToByte(ConfigurationStyleApp.STYLE_VAC_COLOR_RGB);

                var SlimeTopColor = StringToByte(ConfigurationStyleApp.STYLE_TOP_COLOR_RGB);
                var SlimeMidColor = StringToByte(ConfigurationStyleApp.STYLE_MIDDLE_COLOR_RGB);
                var SlimeBotColor = StringToByte(ConfigurationStyleApp.STYLE_BOTTOM_COLOR_RGB);
                var SlimeSpecColor = StringToByte(ConfigurationStyleApp.STYLE_SPEC_COLOR_RGB);

                if (ConfigurationAdditional.REMOVE_STYLED_PHOSPHOR_ANTENNAS && ConfigurationAdditional.REMOVE_STYLED_PHOSPHOR_WINGS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
                {
                    customizedStyle.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(customizedStyle.Structures[0])
                    };
                }
                else if (ConfigurationAdditional.REMOVE_STYLED_PHOSPHOR_ANTENNAS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
                {
                    customizedStyle.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(customizedStyle.Structures[0]),
                        Structure.AddStructure(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME), 2)
                    };
                }
                else if (ConfigurationAdditional.REMOVE_STYLED_PHOSPHOR_WINGS && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
                {
                    customizedStyle.Structures = new SlimeAppearanceStructure[]
                    {
                        new SlimeAppearanceStructure(customizedStyle.Structures[0]),
                        Structure.AddStructure(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME), 1)
                    };
                }

                customizedStyle.ColorPalette = new SlimeAppearance.Palette
                {
                    Top = new Color32(SplatColorTop[0], SplatColorTop[1], SplatColorTop[2], byte.MaxValue),
                    Middle = new Color32(SplatColorMid[0], SplatColorMid[1], SplatColorMid[2], byte.MaxValue),
                    Bottom = new Color32(SplatColorBot[0], SplatColorBot[1], SplatColorBot[2], byte.MaxValue),
                    Ammo = new Color32(SplatColorAm[0], SplatColorAm[1], SplatColorAm[2], byte.MaxValue)
                };

                SlimeAppearance.SlimeBone[] attachedBones = new SlimeAppearance.SlimeBone[]
                {
                    SlimeAppearance.SlimeBone.JiggleBack,
                    SlimeAppearance.SlimeBone.JiggleBottom,
                    SlimeAppearance.SlimeBone.JiggleFront,
                    SlimeAppearance.SlimeBone.JiggleLeft,
                    SlimeAppearance.SlimeBone.JiggleRight,
                    SlimeAppearance.SlimeBone.JiggleTop
                };

                if (ConfigurationMesh.STYLED_CUSTOM_MESH_ENABLED)
                {
                    (GameObject, SlimeAppearanceObject, SlimeAppearance.SlimeBone[]) styledCustomMeshBody = Structure.CreateBasicStructure(LoadAssetBundle("slime_bundle"), ConfigurationMesh.STYLED_CUSTOM_MESH_OBJ_NAME, "exotic_slime_" + ConfigurationMesh.STYLED_CUSTOM_MESH_OBJ_NAME, SlimeAppearance.SlimeBone.Slime, SlimeAppearance.SlimeBone.None, attachedBones, RubberBoneEffect.RubberType.Slime, ConfigurationMesh.STYLED_CUSTOM_MESH_RUBBER_EFFECT);
                    styledCustomMeshBody.Item2.IgnoreLODIndex = ConfigurationMesh.STYLED_CUSTOM_MESH_IGNORE_LOD_INDEX;
                    AssetsLib.MeshUtils.GenerateBoneData(customizedSlime.Item2.GetComponent<SlimeAppearanceApplicator>(), styledCustomMeshBody.Item2, ConfigurationMesh.STYLED_CUSTOM_MESH_JIGGLE, ConfigurationMesh.STYLED_CUSTOM_MESH_SCALE);
                    Structure.SetStructureElement(ConfigurationMesh.STYLED_CUSTOM_MESH_OBJ_NAME, customizedStyle, new SlimeAppearanceObject[] { styledCustomMeshBody.Item2 }, 0, false, true);
                }

                if (ConfigurationMesh.STYLED_CUSTOM_MESH_ENABLED && ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.QUANTUM_SLIME)
                    UnityEngine.Object.Destroy(customizedStyle.QubitAppearance);

                SlimeAppearanceStructure[] structures = customizedStyle.Structures;
                foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
                {
                    Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                    if (defaultMaterials != null && defaultMaterials.Length != 0)
                    {
                        if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                        {

                            slimeAppearanceStructure.DefaultMaterials[0] = (Material)Prefab.Instantiate(Slime.GetSlimeDef(ConfigurationStyleApp.WHAT_STYLE_MATERIAL).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_TopColor", RandomFunc.RandomColor32());
                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_MiddleColor", RandomFunc.RandomColor32());
                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_BottomColor", RandomFunc.RandomColor32());
                        }
                        else
                        {
                            slimeAppearanceStructure.DefaultMaterials[0] = (Material)Prefab.Instantiate(Slime.GetSlimeDef(ConfigurationStyleApp.WHAT_STYLE_MATERIAL).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_TopColor", new Color32(SlimeTopColor[0], SlimeTopColor[1], SlimeTopColor[2], byte.MaxValue));
                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_MiddleColor", new Color32(SlimeMidColor[0], SlimeMidColor[1], SlimeMidColor[2], byte.MaxValue));
                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_BottomColor", new Color32(SlimeBotColor[0], SlimeBotColor[1], SlimeBotColor[2], byte.MaxValue));
                            slimeAppearanceStructure.DefaultMaterials[0].SetColor("_BottomColor", new Color32(SlimeSpecColor[0], SlimeSpecColor[1], SlimeSpecColor[2], byte.MaxValue));
                        }

                        if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.RAD_SLIME)
                        {
                            if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                            {
                                customizedStyle.Structures[1].DefaultMaterials[0] = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);

                                customizedStyle.Structures[1].DefaultMaterials[0].SetColor("_MiddleColor", RandomFunc.RandomColor32());
                                customizedStyle.Structures[1].DefaultMaterials[0].SetColor("_EdgeColor", RandomFunc.RandomColor32());
                            }
                            else
                            {
                                var StyleRadMidC = StringToByte(ConfigurationStrucConfig.STYLED_RAD_AURA_MIDDLE_RGB);
                                var StyleRadEdgC = StringToByte(ConfigurationStrucConfig.STYLED_RAD_AURA_EDGE_RGB);

                                customizedStyle.Structures[1].DefaultMaterials[0] = (Material)Prefab.Instantiate(Slime.GetSlimeDef(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                                customizedStyle.Structures[1].DefaultMaterials[0].SetColor("_MiddleColor", new Color32(StyleRadMidC[0], StyleRadMidC[1], StyleRadMidC[2], byte.MaxValue));
                                customizedStyle.Structures[1].DefaultMaterials[0].SetColor("_EdgeColor", new Color32(StyleRadEdgC[0], StyleRadEdgC[1], StyleRadEdgC[2], byte.MaxValue));
                            }
                        }
                        if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.PHOSPHOR_SLIME)
                        {
                            if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                            {
                                customizedStyle.Structures[0].DefaultMaterials[0] = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowTop", RandomFunc.RandomColor32());
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowMid", RandomFunc.RandomColor32());
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowBottom", RandomFunc.RandomColor32());
                            }
                            else
                            {
                                var StyledPhosTopC = StringToByte(ConfigurationStrucConfig.STYLED_PHOSPHOR_GLOW_TOP_RGB);
                                var StyledPhosMidC = StringToByte(ConfigurationStrucConfig.STYLED_PHOSPHOR_GLOW_MID_RGB);
                                var StyledPhosBotC = StringToByte(ConfigurationStrucConfig.STYLED_PHOSPHOR_GLOW_BOT_RGB);

                                customizedStyle.Structures[0].DefaultMaterials[0] = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.PHOSPHOR_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_TopColor", new Color32(SlimeTopColor[0], SlimeTopColor[1], SlimeTopColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_MiddleColor", new Color32(SlimeMidColor[0], SlimeMidColor[1], SlimeMidColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_BottomColor", new Color32(SlimeBotColor[0], SlimeBotColor[1], SlimeBotColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowTop", new Color32(StyledPhosTopC[0], StyledPhosTopC[1], StyledPhosTopC[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowMid", new Color32(StyledPhosMidC[0], StyledPhosMidC[1], StyledPhosMidC[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_GlowBottom", new Color32(StyledPhosBotC[0], StyledPhosBotC[1], StyledPhosBotC[2], byte.MaxValue));
                            }
                        }
                        if (ConfigurationSlime.WHAT_SLIME_LOOKS_LIKE == Identifiable.Id.BOOM_SLIME)
                        {
                            if (ConfigurationAdditional.RANDOM_SLIME_COLORS)
                            {
                                customizedStyle.Structures[0].DefaultMaterials[0] = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_CrackColor", RandomFunc.RandomColor32());
                            }
                            else
                            {
                                var StyledBoomCrackC = StringToByte(ConfigurationStrucConfig.STYLED_BOOM_CRACKS_RGB);

                                customizedStyle.Structures[0].DefaultMaterials[0] = UnityEngine.Object.Instantiate(Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_TopColor", new Color32(SlimeTopColor[0], SlimeTopColor[1], SlimeTopColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_MiddleColor", new Color32(SlimeMidColor[0], SlimeMidColor[1], SlimeMidColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_BottomColor", new Color32(SlimeBotColor[0], SlimeBotColor[1], SlimeBotColor[2], byte.MaxValue));
                                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_CrackColor", new Color32(StyledBoomCrackC[0], StyledBoomCrackC[1], StyledBoomCrackC[2], byte.MaxValue));
                            }
                        }
                    }
                }

                customizedStyle.Structures[0].DefaultMaterials[0] = (Material)Prefab.Instantiate(Slime.GetSlimeDef(ConfigurationStyleApp.WHAT_STYLE_MATERIAL).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_TopColor", new Color32(SlimeTopColor[0], SlimeTopColor[1], SlimeTopColor[2], byte.MaxValue));
                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_MiddleColor", new Color32(SlimeMidColor[0], SlimeMidColor[1], SlimeMidColor[2], byte.MaxValue));
                customizedStyle.Structures[0].DefaultMaterials[0].SetColor("_BottomColor", new Color32(SlimeBotColor[0], SlimeBotColor[1], SlimeBotColor[2], byte.MaxValue));

                SlimeExpressionFace[] expressionFaces = customizedStyle.Face.ExpressionFaces;
                for (int k = 0; k < expressionFaces.Length; k++)
                {
                    SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                    var StyledMouthTopC = StringToByte(ConfigurationStyleApp.MOUTH_TOP_COLOR_RGB);
                    var StyledMouthMidC = StringToByte(ConfigurationStyleApp.MOUTH_MIDDLE_COLOR_RGB);
                    var StyledMouthBotC = StringToByte(ConfigurationStyleApp.MOUTH_BOTTOM_COLOR_RGB);

                    var StyledEyeTopC = StringToByte(ConfigurationStyleApp.EYES_TOP_COLOR_RGB);
                    var StyledEyeMidC = StringToByte(ConfigurationStyleApp.EYES_MIDDLE_COLOR_RGB);
                    var StyledEyeBotC = StringToByte(ConfigurationStyleApp.EYES_BOTTOM_COLOR_RGB);

                    if ((bool)slimeExpressionFace.Mouth)
                    {
                        slimeExpressionFace.Mouth.SetColor("_MouthBot", new Color32(StyledMouthBotC[0], StyledMouthBotC[1], StyledMouthBotC[2], byte.MaxValue));
                        slimeExpressionFace.Mouth.SetColor("_MouthMid", new Color32(StyledMouthMidC[0], StyledMouthMidC[1], StyledMouthMidC[2], byte.MaxValue));
                        slimeExpressionFace.Mouth.SetColor("_MouthTop", new Color32(StyledMouthTopC[0], StyledMouthTopC[1], StyledMouthTopC[2], byte.MaxValue));
                    }
                    if ((bool)slimeExpressionFace.Eyes)
                    {
                        slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(StyledEyeTopC[0], StyledEyeTopC[1], StyledEyeTopC[2], byte.MaxValue));
                        slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(StyledEyeMidC[0], StyledEyeMidC[1], StyledEyeMidC[2], byte.MaxValue));
                        slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(StyledEyeBotC[0], StyledEyeBotC[1], StyledEyeBotC[2], byte.MaxValue));
                    }
                }
                customizedStyle.Face.OnEnable();

                var CosmeticPosition = StringToFloat(ConfigurationCosmetic.COSMETIC_POD_POSITION);
                var CosmeticRotation = StringToFloat(ConfigurationCosmetic.COSMETIC_POD_ROTATION);

                Style.CreateCosmetic(ConfigurationCosmetic.COSMETIC_POD_ID_NAME, "zoneREEF/cellReef_GordoIsland/Sector/Loot/treasurePodCosmetic", ConfigurationCosmetic.COSMETIC_POD_PARENT, new Vector3(CosmeticPosition[0], CosmeticPosition[1], CosmeticPosition[2]), customizedStyle, Slime.GetSlimeDef(Ids.CUSTOMIZABLE_SLIME), Quaternion.Euler(new Vector3(CosmeticRotation[0], CosmeticRotation[1], CosmeticRotation[2])), true);
            }
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
