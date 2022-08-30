using CustomizableSlime;
using SRML.Config.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static SRML.SR.SlimeRegistry;


[ConfigFile("StyleAppearance")]
class ConfigurationStyleApp
{
    public static bool SECRET_STYLES_ENABLED = false;

    public static string STYLE_NAME = "De-Customizable Slime";

    public static Identifiable.Id WHAT_STYLE_MATERIAL = Identifiable.Id.PINK_SLIME;

    public static string STYLE_TOP_COLOR_RGB = "0, 0, 0";

    public static string STYLE_MIDDLE_COLOR_RGB = "0, 0, 0";

    public static string STYLE_BOTTOM_COLOR_RGB = "0, 0, 0";

    public static string STYLE_SPEC_COLOR_RGB = "0, 0, 0";

    public static string STYLE_VAC_COLOR_RGB = "255, 255, 255";

    public static string MOUTH_TOP_COLOR_RGB = "255, 255, 255";

    public static string MOUTH_MIDDLE_COLOR_RGB = "255, 255, 255";

    public static string MOUTH_BOTTOM_COLOR_RGB = "255, 255, 255";

    public static string EYES_TOP_COLOR_RGB = "255, 255, 255";

    public static string EYES_MIDDLE_COLOR_RGB = "255, 255, 255";

    public static string EYES_BOTTOM_COLOR_RGB = "255, 255, 255";

    public static string SPLAT_TOP_COLOR_RGB = "0, 0, 0";

    public static string SPLAT_MIDDLE_COLOR_RGB = "0, 0, 0";

    public static string SPLAT_BOTTOM_COLOR_RGB = "0, 0, 0";
}

[ConfigFile("StyleCosmetic")]
class ConfigurationCosmetic
{
    public static string COSMETIC_POD_ID_NAME = "CustomizableCosmeticPod";

    public static string COSMETIC_POD_POSITION = "103.6, 12.3, -136.7";

    public static string COSMETIC_POD_PARENT = "zoneRANCH/cellRanch_Entrance/Sector";

    public static string COSMETIC_POD_ROTATION = "0, 0, 0";
}

[ConfigFile("EatMapConfig")]
class ConfigurationEatMap
{
    public static bool TRANSFORM_EATMAP = false;

    public static bool PRODUCE_EATMAP = false;

    public static Identifiable.Id TRANSFORM_WHAT_SLIME_EATS = Identifiable.Id.CARROT_VEGGIE;

    public static Identifiable.Id TRANSFORM_WHAT_SLIME_BECOMES = Identifiable.Id.GOLD_SLIME;

    public static SlimeEmotions.Emotion TRANSFORM_EAT_DRIVER = SlimeEmotions.Emotion.AGITATION;

    public static float TRANSFORM_MIN_DRIVE = 1f;

    public static float TRANSFORM_EXTRA_DRIVE = 0f;

    public static Identifiable.Id PRODUCE_WHAT_SLIME_PRODUCES = Identifiable.Id.PINK_ROCK_LARGO;

    public static Identifiable.Id PRODUCE_WHAT_SLIME_EATS = Identifiable.Id.BEET_VEGGIE;

    public static SlimeEmotions.Emotion PRODUCE_EAT_DRIVER = SlimeEmotions.Emotion.AGITATION;

    public static bool PRODUCE_IS_FAVORITE_FOOD = false;

    public static int PRODUCE_FAVORITE_PRODUCTION_COUNT = 2;

    public static float PRODUCE_MIN_DRIVE = 1f;

    public static float PRODUCE_EXTRA_DRIVE = 0f;
}


/*[ConfigFile("SlimeChecks")]
class ConfigurationCheck
{
    public static bool IS_DERVISH_SLIME = false;

    public static bool IS_TABBY_SLIME = false;

    public static bool IS_LUCKY_SLIME = false;

    public static bool IS_HUNTER_SLIME = false;

    public static bool IS_HONEY_SLIME = false;

    public static bool IS_TANGLE_SLIME = false;

    public static bool IS_PHOSPHOR_SLIME = false;

    public static bool IS_ROCK_SLIME = false;

    public static bool IS_RAD_SLIME = false;

    public static bool IS_CRYSTAL_SLIME = false;

    public static bool IS_FIRE_SLIME = false;

    public static bool IS_GLITCH_SLIME = false;
}*/


/*[ConfigFile("SlimeStructures")]
class ConfigurationStructure
{
    public static bool RAD_AURA = false;

    public static bool TABBY_EARS_AND_TAIL = false;

    public static bool PHOSPHOR_WINGS_AND_ANTENNAS = false;

    public static bool HONEYCOMB = false;

    public static bool HUNTER_EARS_AND_TAIL = false;

    public static bool DERVISH_RING = false;

    public static bool TANGLE_PLANT = false;

    public static bool ROCKS = false;

    public static bool CRYSTALS = false;

    public static bool FIRE = false;

    public static bool GLITCH_TRAIL = false;

    public static bool LUCKY_COIN = false;
}*/


[ConfigFile("SpawnZoneConfig")]
class ConfigurationZone
{
    public static bool SPAWN_EVERYWHERE = false;

    public static float SPAWN_CHANCE = 0.3f;

    public static ZoneDirector.Zone SPAWN_ZONE_1 = ZoneDirector.Zone.REEF;

    public static ZoneDirector.Zone SPAWN_ZONE_2 = ZoneDirector.Zone.NONE;

    public static ZoneDirector.Zone SPAWN_ZONE_3 = ZoneDirector.Zone.NONE;

    public static ZoneDirector.Zone SPAWN_ZONE_4 = ZoneDirector.Zone.NONE;

    public static ZoneDirector.Zone SPAWN_ZONE_5 = ZoneDirector.Zone.NONE;
}


[ConfigFile("LargoProperties")]
class ConfigurationLargoProps
{
    public static LargoProps LARGO_PROPERTY_1 = LargoProps.REPLACE_BASE_MAT_AS_SLIME1;

    public static LargoProps LARGO_PROPERTY_2 = LargoProps.RECOLOR_SLIME2_ADDON_MATS;

    public static LargoProps LARGO_PROPERTY_3 = LargoProps.GENERATE_NAME;

    public static LargoProps LARGO_PROPERTY_4 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_5 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_6 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_7 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_8 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_9 = LargoProps.NONE;

    public static LargoProps LARGO_PROPERTY_10 = LargoProps.NONE;
}


[ConfigFile("CustomSlime")]
class ConfigurationSlime
{
    public static string SLIME_NAME = "Customizable Slime";

    public static bool TARR_SUPPORT = true;

    public static bool CAN_LARGOFY = false;

    public static Identifiable.Id WHAT_SLIME_LOOKS_LIKE = Identifiable.Id.PINK_SLIME;

    public static Identifiable.Id WHAT_SLIME_ACTS_LIKE = Identifiable.Id.PINK_SLIME;

    public static Identifiable.Id WHAT_SLIME_MATERIAL = Identifiable.Id.PINK_SLIME;

    public static string WHAT_SLIME_PRODUCES = "CUSTOMIZABLE_PLORT";

    public static SlimeEat.FoodGroup WHAT_SLIME_EATS = SlimeEat.FoodGroup.VEGGIES;

    public static Identifiable.Id ADDITIONAL_FOOD_SLIME_EATS = Identifiable.Id.HEN;

    public static Identifiable.Id FAVORITE_SLIME_EATS = Identifiable.Id.BEET_VEGGIE;

    public static Identifiable.Id FAVORITE_SLIME_TOY = Identifiable.Id.BEACH_BALL_TOY;

    public static Vacuumable.Size VACPACK_SIZE = Vacuumable.Size.NORMAL;

    public static string SLIMEPEDIA_TITLE = "Customizable Slime";

    public static string SLIMEPEDIA_INTRO = "This slime can be customized via configuration files!";

    public static string SLIMEPEDIA_DIET = "Veggies";

    public static string SLIMEPEDIA_FAVORITE = "Heart Beet";

    public static string SLIMEPEDIA_SLIMEOLOGY = "[Insert Long Description Here] and that's what the Customizable Slime can do!";

    public static string SLIMEPEDIA_RISKS = "Don't break your slime! Be a little bit careful when you configure it.";

    public static string SLIMEPEDIA_PLORTONOMICS = "Its a customized plort..?";

    public static string SLIME_TOP_COLOR_RGB = "255, 255, 255";

    public static string SLIME_MIDDLE_COLOR_RGB = "255, 255, 255";

    public static string SLIME_BOTTOM_COLOR_RGB = "255, 255, 255";

    public static string SLIME_SPEC_COLOR_RGB = "255, 255, 255";

    public static string SLIME_VAC_COLOR_RGB = "255, 255, 255";

    public static string MOUTH_TOP_COLOR_RGB = "0, 0, 0";

    public static string MOUTH_MIDDLE_COLOR_RGB = "0, 0, 0";

    public static string MOUTH_BOTTOM_COLOR_RGB = "0, 0, 0";

    public static string EYES_TOP_COLOR_RGB = "0, 0, 0";

    public static string EYES_MIDDLE_COLOR_RGB = "0, 0, 0";

    public static string EYES_BOTTOM_COLOR_RGB = "0, 0, 0";

    public static string SPLAT_TOP_COLOR_RGB = "255, 255, 255";

    public static string SPLAT_MIDDLE_COLOR_RGB = "255, 255, 255";

    public static string SPLAT_BOTTOM_COLOR_RGB = "255, 255, 255";
}


[ConfigFile("CustomPlort")]
class ConfigurationPlort
{
    public static string PLORT_NAME = "Customizable Plort";

    public static bool HAS_ROCKS = false;

    public static Identifiable.Id WHAT_PLORT_LOOKS_LIKE = Identifiable.Id.PINK_PLORT;

    public static Vacuumable.Size VACPACK_SIZE = Vacuumable.Size.NORMAL;

    public static float PLORT_PRICE = 50f;

    public static float PLORT_SATURATION = 20f;

    public static string PLORT_TOP_COLOR_RGB = "255, 255, 255";

    public static string PLORT_MIDDLE_COLOR_RGB = "255, 255, 255";

    public static string PLORT_BOTTOM_COLOR_RGB = "255, 255, 255";

    public static string PLORT_VAC_COLOR_RGB = "255, 255, 255";

    public static string ROCKS_TOP_COLOR_RGB = "0, 0, 0";

    public static string ROCKS_MIDDLE_COLOR_RGB = "0, 0, 0";

    public static string ROCKS_BOTTOM_COLOR_RGB = "0, 0, 0";
}


[ConfigFile("StructureConfig")]
class ConfigurationStrucConfig
{
    public static string RAD_AURA_MIDDLE_RGB = "255, 255, 255";

    public static string RAD_AURA_EDGE_RGB = "0, 0, 0";

    public static string PHOSPHOR_GLOW_TOP_RGB = "0, 0, 0";

    public static string PHOSPHOR_GLOW_MID_RGB = "0, 0, 0";

    public static string PHOSPHOR_GLOW_BOT_RGB = "0, 0, 0";

    public static string STYLED_RAD_AURA_MIDDLE_RGB = "0, 0, 0";

    public static string STYLED_RAD_AURA_EDGE_RGB = "255, 255, 255";

    public static string STYLED_PHOSPHOR_GLOW_TOP_RGB = "255, 255, 255";

    public static string STYLED_PHOSPHOR_GLOW_MID_RGB = "255, 255, 255";

    public static string STYLED_PHOSPHOR_GLOW_BOT_RGB = "255, 255, 255";
}


[ConfigFile("AdditionalConfig")]
class ConfigurationAdditional
{
    public static bool DISABLE_SPAWNING = false;

    public static bool RANDOM_SLIME_COLORS = false;

    public static bool RANDOM_PLORT_COLORS = false;

    public static bool REMOVE_PHOSPHOR_WINGS = false;

    public static bool REMOVE_PHOSPHOR_ANTENNAS = false;

    public static bool REMOVE_STYLED_PHOSPHOR_WINGS = false;

    public static bool REMOVE_STYLED_PHOSPHOR_ANTENNAS = false;
}


[ConfigFile("BehavioursConfig")]
class ConfigurationBehaviours
{
    public static bool HAS_SLIME_HOVER = false;

    public static bool HAS_PUDDLE_SLIME_SCOOT = false;

    public static bool HAS_BETTER_BREAK_ON_IMPACT = false;

    public static bool HAS_GOTO_PLAYER = false;

    public static bool HAS_ATTACK_PLAYER = false;

    public static bool HAS_FLEE_THREATS = true;

    public static bool HAS_METEOR_MAGNETISM = false;

    public static bool HAS_BOOM_EXPLOSION = false;

    public static bool HAS_CRYSTAL_SPIKES = false;

    public static bool HAS_DERVISH_TORNADO = false;

    // public static bool HAS_QUANTUM_QUBIT = false;

    public static bool HAS_MOSAIC_GLINT = false;

    public static bool HAS_TANGLE_VINES = false;

    public static bool HAS_TARR_GRAB = true;

    public static bool HAS_AGITATED_KILL = false;

    public static bool HAS_SLIME_RUN_COMMAND = false;
}


[ConfigFile("AdvancedConfig")]
class ConfigurationAdvanced
{
    public static float SLIME_LOCAL_SCALE = 1f;

    public static float SLIME_SPEED_FACTOR = 1f;

    public static float SLIME_VERTICAL_FACTOR = 1f;

    public static float PLORT_LOCAL_SCALE = 1f;

    public static int ATTACK_PLAYER_DAMAGE = 20;

    public static float GOTO_PLAYER_MIN_RADIUS = 5f;

    public static float GOTO_PLAYER_MAX_RADIUS = 20f;

    public static float GOTO_PLAYER_ATTEMPT = 10f;

    public static float GOTO_PLAYER_GIVEUP = 10f;

    public static float GOTO_PLAYER_MIN_DRIVE = 1f;

    public static bool TARR_GRAB_CAUSE_FEAR = true;

    public static float TARR_GRAB_COOLDOWN = 2f;

    public static float TARR_GRAB_MIN_RADIUS = 5f;

    public static float TARR_GRAB_MAX_RADIUS = 30f;

    public static SlimeEmotions.Emotion FLEE_THREATS_DRIVER = SlimeEmotions.Emotion.FEAR;

    public static float FLEE_THREATS_MAX_JUMP = 2f;

    public static Identifiable.Id AGITATED_KILL_IGNORE = Identifiable.Id.NONE;

    public static float AGITATED_KILL_DELAY = 60f;

    public static float SLIME_RUN_COMMAND_DELAY = 30f;

    public static SlimeEmotions.Emotion SLIME_RUN_COMMAND_DRIVER = SlimeEmotions.Emotion.AGITATION;

    public static float SLIME_RUN_COMMAND_DRIVER_AMOUNT = 0.5f;

    public static string SLIME_RUN_COMMAND_TRIGGER = "spawn PINK_SLIME";
}