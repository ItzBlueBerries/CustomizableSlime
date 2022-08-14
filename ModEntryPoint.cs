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

            if (!ConfigurationAdditional.DISABLE_SPAWNING)
            {
                SRCallbacks.PreSaveGameLoad += (s =>
                {
                    foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                        .Where(ss =>
                        {
                            ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                            return zone == ConfigurationSlime.SPAWN_ZONE;
                        }))
                    {
                        foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                        {
                            List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                            {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.CUSTOMIZABLE_SLIME),
                                weight = ConfigurationSlime.SPAWN_CHANCE
                            }
                            };
                            constraint.slimeset.members = members.ToArray();
                        }
                    }
                });
            }
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