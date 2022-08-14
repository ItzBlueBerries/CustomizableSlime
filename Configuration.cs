using SRML.Config.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static SRML.SR.SlimeRegistry;

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

[ConfigFile("CustomSlime")]
class ConfigurationSlime
{
    public static string SLIME_NAME = "Customizable Slime";

    public static bool TARR_SUPPORT = true;

    public static bool CAN_LARGOFY = false;

    public static Identifiable.Id WHAT_SLIME_LOOKS_LIKE = Identifiable.Id.PINK_SLIME;

    public static Identifiable.Id WHAT_SLIME_ACTS_LIKE = Identifiable.Id.PINK_SLIME;

    public static SlimeEat.FoodGroup WHAT_SLIME_EATS = SlimeEat.FoodGroup.VEGGIES;

    public static Identifiable.Id ADDITIONAL_FOOD_SLIME_EATS = Identifiable.Id.HEN;

    public static Identifiable.Id FAVORITE_SLIME_EATS = Identifiable.Id.BEET_VEGGIE;

    public static Identifiable.Id FAVORITE_SLIME_TOY = Identifiable.Id.BEACH_BALL_TOY;

    public static Vacuumable.Size VACPACK_SIZE = Vacuumable.Size.NORMAL;

    public static ZoneDirector.Zone SPAWN_ZONE = ZoneDirector.Zone.REEF;

    public static float SPAWN_CHANCE = 0.3f;

    public static byte SLIME_TOP_COLOR_R = 255;

    public static byte SLIME_TOP_COLOR_G = 255;

    public static byte SLIME_TOP_COLOR_B = 255;

    public static byte SLIME_MIDDLE_COLOR_R = 255;

    public static byte SLIME_MIDDLE_COLOR_G = 255;

    public static byte SLIME_MIDDLE_COLOR_B = 255;

    public static byte SLIME_BOTTOM_COLOR_R = 255;

    public static byte SLIME_BOTTOM_COLOR_G = 255;

    public static byte SLIME_BOTTOM_COLOR_B = 255;

    public static byte MOUTH_TOP_COLOR_R = 0;

    public static byte MOUTH_TOP_COLOR_G = 0;

    public static byte MOUTH_TOP_COLOR_B = 0;

    public static byte MOUTH_MIDDLE_COLOR_R = 0;

    public static byte MOUTH_MIDDLE_COLOR_G = 0;

    public static byte MOUTH_MIDDLE_COLOR_B = 0;

    public static byte MOUTH_BOTTOM_COLOR_R = 0;

    public static byte MOUTH_BOTTOM_COLOR_G = 0;

    public static byte MOUTH_BOTTOM_COLOR_B = 0;

    public static byte EYES_TOP_COLOR_R = 0;

    public static byte EYES_TOP_COLOR_G = 0;

    public static byte EYES_TOP_COLOR_B = 0;

    public static byte EYES_MIDDLE_COLOR_R = 0;

    public static byte EYES_MIDDLE_COLOR_G = 0;

    public static byte EYES_MIDDLE_COLOR_B = 0;

    public static byte EYES_BOTTOM_COLOR_R = 0;

    public static byte EYES_BOTTOM_COLOR_G = 0;

    public static byte EYES_BOTTOM_COLOR_B = 0;
}

[ConfigFile("VacPack&Splat")]
class ConfigurationVacSplat
{
    public static byte SPLAT_TOP_COLOR_R = 255;

    public static byte SPLAT_TOP_COLOR_G = 255;

    public static byte SPLAT_TOP_COLOR_B = 255;

    public static byte SPLAT_MIDDLE_COLOR_R = 255;

    public static byte SPLAT_MIDDLE_COLOR_G = 255;

    public static byte SPLAT_MIDDLE_COLOR_B = 255;

    public static byte SPLAT_BOTTOM_COLOR_R = 255;

    public static byte SPLAT_BOTTOM_COLOR_G = 255;

    public static byte SPLAT_BOTTOM_COLOR_B = 255;

    public static byte SLIME_VAC_COLOR_R = 255;

    public static byte SLIME_VAC_COLOR_G = 255;

    public static byte SLIME_VAC_COLOR_B = 255;

    public static byte PLORT_VAC_COLOR_R = 255;

    public static byte PLORT_VAC_COLOR_G = 255;

    public static byte PLORT_VAC_COLOR_B = 255;
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

    public static byte TOP_COLOR_R = 255;

    public static byte TOP_COLOR_G = 255;

    public static byte TOP_COLOR_B = 255;

    public static byte MIDDLE_COLOR_R = 255;

    public static byte MIDDLE_COLOR_G = 255;

    public static byte MIDDLE_COLOR_B = 255;

    public static byte BOTTOM_COLOR_R = 255;

    public static byte BOTTOM_COLOR_G = 255;

    public static byte BOTTOM_COLOR_B = 255;

    public static byte ROCKS_TOP_COLOR_R = 0;

    public static byte ROCKS_TOP_COLOR_G = 0;

    public static byte ROCKS_TOP_COLOR_B = 0;

    public static byte ROCKS_MIDDLE_COLOR_R = 0;

    public static byte ROCKS_MIDDLE_COLOR_G = 0;

    public static byte ROCKS_MIDDLE_COLOR_B = 0;

    public static byte ROCKS_BOTTOM_COLOR_R = 0;

    public static byte ROCKS_BOTTOM_COLOR_G = 0;

    public static byte ROCKS_BOTTOM_COLOR_B = 0;
}

[ConfigFile("StructureConfig")]
class ConfigurationStrucConfig
{
    public static byte RAD_AURA_MIDDLE_R = 255;

    public static byte RAD_AURA_MIDDLE_G = 255;

    public static byte RAD_AURA_MIDDLE_B = 255;

    public static byte RAD_AURA_EDGE_R = 255;

    public static byte RAD_AURA_EDGE_G = 255;

    public static byte RAD_AURA_EDGE_B = 255;

    /*public static byte TABBY_TOP_COLOR_R = 0;

    public static byte TABBY_TOP_COLOR_G = 0;

    public static byte TABBY_TOP_COLOR_B = 0;

    public static byte TABBY_MIDDLE_COLOR_R = 0;

    public static byte TABBY_MIDDLE_COLOR_G = 0;

    public static byte TABBY_MIDDLE_COLOR_B = 0;

    public static byte TABBY_BOTTOM_COLOR_R = 0;

    public static byte TABBY_BOTTOM_COLOR_G = 0;

    public static byte TABBY_BOTTOM_COLOR_B = 0;

    public static byte COIN_TOP_COLOR_R = 255;

    public static byte COIN_TOP_COLOR_G = 255;

    public static byte COIN_TOP_COLOR_B = 255;

    public static byte COIN_MIDDLE_COLOR_R = 255;

    public static byte COIN_MIDDLE_COLOR_G = 255;

    public static byte COIN_MIDDLE_COLOR_B = 255;

    public static byte COIN_BOTTOM_COLOR_R = 255;

    public static byte COIN_BOTTOM_COLOR_G = 255;

    public static byte COIN_BOTTOM_COLOR_B = 255;*/
}

[ConfigFile("AdditionalConfig")]
class ConfigurationAdditional
{
    public static bool DISABLE_SPAWNING = false;

    public static bool RANDOM_SLIME_COLORS = false;

    public static bool RANDOM_PLORT_COLORS = false;
}

[ConfigFile("SlimepediaConfig")]
class ConfigurationPedia
{
    public static string SLIMEPEDIA_TITLE = "Customizable Slime";

    public static string SLIMEPEDIA_INTRO = "This slime can be customized via configuration files!";

    public static string SLIMEPEDIA_DIET = "Veggies";

    public static string SLIMEPEDIA_FAVORITE = "Heart Beet";

    public static string SLIMEPEDIA_SLIMEOLOGY = "[Insert Long Description Here] and that's what the Customizable Slime can do!";

    public static string SLIMEPEDIA_RISKS = "Don't break your slime! Be a little bit careful when you configure it.";

    public static string SLIMEPEDIA_PLORTONOMICS = "Its a customized plort..?";
}


[ConfigFile("BehavioursConfig")]
class ConfigurationBehaviours
{
    public static bool HAS_SLIME_HOVER = false;

    public static bool HAS_PUDDLE_SLIME_SCOOT = false;

    public static bool HAS_BETTER_BREAK_ON_IMPACT = false;

    public static bool HAS_GOTO_PLAYER = false;

    public static bool HAS_ATTACK_PLAYER = false;

    public static bool HAS_SLIME_FLEE = false;

    public static bool HAS_FLEE_THREATS = true;

    public static bool HAS_METEOR_MAGNETISM = false;

    public static bool HAS_BOOM_EXPLOSION = false;

    public static bool HAS_CRYSTAL_SPIKES = false;

    public static bool HAS_DERVISH_TORNADO = false;

    // public static bool HAS_QUANTUM_QUBIT = false;

    public static bool HAS_MOSAIC_GLINT = false;

    public static bool HAS_TANGLE_VINES = false;

    public static bool HAS_TARR_GRAB = true;
}

[ConfigFile("AdvancedConfig")]
class ConfigurationAdvanced
{
    public static float SLIME_SPEED_FACTOR = 1f;

    public static float SLIME_VERTICAL_FACTOR = 1f;

    public static float SLIME_FLEE_DISTANCE = 25f;

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
}