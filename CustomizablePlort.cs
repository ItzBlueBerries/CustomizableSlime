using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomizableSlime
{
    class CustomizablePlort
    {
        public static GameObject CustomizedPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(ConfigurationPlort.WHAT_PLORT_LOOKS_LIKE)); //It can be any plort, but pink works the best. 
            Prefab.name = ConfigurationPlort.PLORT_NAME;

            Prefab.GetComponent<Identifiable>().id = Ids.CUSTOMIZABLE_PLORT;
            Prefab.GetComponent<Vacuumable>().size = ConfigurationPlort.VACPACK_SIZE;

            Prefab.GetComponent<MeshRenderer>().material = UnityEngine.Object.Instantiate(Prefab.GetComponent<MeshRenderer>().material);

            Color PlortColorVar1 = new Color32(ConfigurationPlort.TOP_COLOR_R, ConfigurationPlort.TOP_COLOR_G, ConfigurationPlort.TOP_COLOR_B, byte.MaxValue);
            Color PlortColorVar2 = new Color32(ConfigurationPlort.MIDDLE_COLOR_R, ConfigurationPlort.MIDDLE_COLOR_G, ConfigurationPlort.MIDDLE_COLOR_B, byte.MaxValue);
            Color PlortColorVar3 = new Color32(ConfigurationPlort.BOTTOM_COLOR_R, ConfigurationPlort.BOTTOM_COLOR_G, ConfigurationPlort.BOTTOM_COLOR_B, byte.MaxValue);

            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", PlortColorVar1);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", PlortColorVar2);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", PlortColorVar3);

            if (ConfigurationPlort.HAS_ROCKS)
            {
                Color RockColorVar1 = new Color32(ConfigurationAdditional.PLORT_ROCKS_TOP_COLOR_R, ConfigurationAdditional.PLORT_ROCKS_TOP_COLOR_G, ConfigurationAdditional.PLORT_ROCKS_TOP_COLOR_B, byte.MaxValue);
                Color RockColorVar2 = new Color32(ConfigurationAdditional.PLORT_ROCKS_MIDDLE_COLOR_R, ConfigurationAdditional.PLORT_ROCKS_MIDDLE_COLOR_G, ConfigurationAdditional.PLORT_ROCKS_MIDDLE_COLOR_B, byte.MaxValue);
                Color RockColorVar3 = new Color32(ConfigurationAdditional.PLORT_ROCKS_BOTTOM_COLOR_R, ConfigurationAdditional.PLORT_ROCKS_BOTTOM_COLOR_G, ConfigurationAdditional.PLORT_ROCKS_BOTTOM_COLOR_B, byte.MaxValue);

                Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_TopColor", RockColorVar1);
                Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", RockColorVar2);
                Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", RockColorVar3);
            }

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }

        public static void LoadCustomizedPlort()
        {
            GameObject CustomizedTuple = CustomizedPlort();

            GameObject CustomizedObj = CustomizedTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CustomizedObj);

            Sprite CustomizedIcon = OtherFunc.CreateSprite(OtherFunc.LoadAsset("Images\\plort_icon.png"));
            Color VacpackColorVar = new Color32(ConfigurationVacSplat.PLORT_VAC_COLOR_R, ConfigurationVacSplat.PLORT_VAC_COLOR_G, ConfigurationVacSplat.PLORT_VAC_COLOR_B, byte.MaxValue);

            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.CUSTOMIZABLE_PLORT, VacpackColorVar, CustomizedIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.CUSTOMIZABLE_PLORT);

            float plortPrice = ConfigurationPlort.PLORT_PRICE;
            float plortSaturation = ConfigurationPlort.PLORT_SATURATION;
            PlortRegistry.AddEconomyEntry(Ids.CUSTOMIZABLE_PLORT, plortPrice, plortSaturation);
            PlortRegistry.AddPlortEntry(Ids.CUSTOMIZABLE_PLORT);
            DroneRegistry.RegisterBasicTarget(Ids.CUSTOMIZABLE_PLORT);
        }
    }
}