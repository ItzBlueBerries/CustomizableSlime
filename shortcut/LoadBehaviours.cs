using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CustomizableSlime.behaviours;
using static ShortcutLib.Shortcut;

namespace CustomizableSlime.shortcut
{
    internal class CustomizableBehaviours
    {
        public static void LoadBehaviours()
        {
            GameObject customizedObject = Prefab.GetPrefab(Ids.CUSTOMIZABLE_SLIME);
            SlimeAppearance customizedAppearance = Slime.GetSlimeDef(Ids.CUSTOMIZABLE_SLIME).AppearancesDefault[0];

            if (ConfigurationBehaviours.HAS_SLIME_HOVER)
            { customizedObject.AddComponent<SlimeHover>(); }
            if (ConfigurationBehaviours.HAS_PUDDLE_SLIME_SCOOT)
            { customizedObject.AddComponent<PuddleSlimeScoot>(); }
            if (ConfigurationBehaviours.HAS_BETTER_BREAK_ON_IMPACT)
            { customizedObject.AddComponent<BetterBreakOnImpact>(); }
            if (ConfigurationBehaviours.HAS_GOTO_PLAYER && ConfigurationBehaviours.HAS_ATTACK_PLAYER)
            {
                UnityEngine.Object.Destroy(customizedObject.GetComponent<SlimeFeral>());
                customizedObject.AddComponent<GotoPlayer>();
                customizedObject.AddComponent<AttackPlayer>();

                customizedObject.GetComponent<GotoPlayer>().shouldGotoPlayer = true;
                customizedObject.GetComponent<GotoPlayer>().minSearchRad = ConfigurationAdvanced.GOTO_PLAYER_MIN_RADIUS;
                customizedObject.GetComponent<GotoPlayer>().maxSearchRad = ConfigurationAdvanced.GOTO_PLAYER_MAX_RADIUS;
                customizedObject.GetComponent<GotoPlayer>().attemptTime = ConfigurationAdvanced.GOTO_PLAYER_ATTEMPT;
                customizedObject.GetComponent<GotoPlayer>().giveUpTime = ConfigurationAdvanced.GOTO_PLAYER_GIVEUP;
                customizedObject.GetComponent<GotoPlayer>().minDrive = ConfigurationAdvanced.GOTO_PLAYER_MIN_DRIVE;

                customizedObject.GetComponent<AttackPlayer>().shouldAttackPlayer = true;
                customizedObject.GetComponent<AttackPlayer>().damagePerAttack = ConfigurationAdvanced.ATTACK_PLAYER_DAMAGE;
            }
            if (ConfigurationBehaviours.HAS_GOTO_PLAYER)
            {
                UnityEngine.Object.Destroy(customizedObject.GetComponent<SlimeFeral>());
                customizedObject.AddComponent<GotoPlayer>();
                customizedObject.GetComponent<GotoPlayer>().shouldGotoPlayer = true;
                customizedObject.GetComponent<GotoPlayer>().minSearchRad = ConfigurationAdvanced.GOTO_PLAYER_MIN_RADIUS;
                customizedObject.GetComponent<GotoPlayer>().maxSearchRad = ConfigurationAdvanced.GOTO_PLAYER_MAX_RADIUS;
                customizedObject.GetComponent<GotoPlayer>().attemptTime = ConfigurationAdvanced.GOTO_PLAYER_ATTEMPT;
                customizedObject.GetComponent<GotoPlayer>().giveUpTime = ConfigurationAdvanced.GOTO_PLAYER_GIVEUP;
                customizedObject.GetComponent<GotoPlayer>().minDrive = ConfigurationAdvanced.GOTO_PLAYER_MIN_DRIVE;
            }
            if (ConfigurationBehaviours.HAS_ATTACK_PLAYER)
            {
                UnityEngine.Object.Destroy(customizedObject.GetComponent<SlimeFeral>());
                customizedObject.AddComponent<AttackPlayer>();
                customizedObject.GetComponent<AttackPlayer>().shouldAttackPlayer = true;
                customizedObject.GetComponent<AttackPlayer>().damagePerAttack = ConfigurationAdvanced.ATTACK_PLAYER_DAMAGE;
            }
            if (!ConfigurationBehaviours.HAS_FLEE_THREATS)
            { UnityEngine.Object.Destroy(customizedObject.GetComponent<FleeThreats>()); }
            if (ConfigurationBehaviours.HAS_FLEE_THREATS)
            {
                customizedObject.GetComponent<FleeThreats>().driver = ConfigurationAdvanced.FLEE_THREATS_DRIVER;
                customizedObject.GetComponent<FleeThreats>().maxJump = ConfigurationAdvanced.FLEE_THREATS_MAX_JUMP;
            }
            if (ConfigurationBehaviours.HAS_METEOR_MAGNETISM)
            {
                Extractor component = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_ABYSSAL).prefab.GetComponent<Extractor>();
                GameObject boomPrefab = Prefab.GetPrefab(Identifiable.Id.BOOM_SLIME).GetComponentInChildren<ExplodeIndicatorMarker>(true).gameObject;
                UnityEngine.Object.Instantiate(boomPrefab, customizedObject.transform);
                customizedObject.AddComponent<MeteorSlimeMagnetism>();
                customizedObject.GetComponent<MeteorSlimeMagnetism>().lowGravFX = component.produces[5].spawnFX;
                customizedObject.GetComponent<MeteorSlimeMagnetism>().attractFX = component.produces[5].spawnFX;
            }
            if (ConfigurationBehaviours.HAS_BOOM_EXPLOSION)
            {
                ExplosionAppearance component = Slime.GetSlimeDef(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].ExplosionAppearance;
                GameObject boomPrefab = Prefab.GetPrefab(Identifiable.Id.BOOM_SLIME).GetComponentInChildren<ExplodeIndicatorMarker>(true).gameObject;
                UnityEngine.Object.Instantiate(boomPrefab, customizedObject.transform);
                customizedObject.AddComponent<BoomSlimeExplode>();
                customizedAppearance.ExplosionAppearance = component;
            }
            if (ConfigurationBehaviours.HAS_CRYSTAL_SPIKES)
            {
                CrystalAppearance component = Slime.GetSlimeDef(Identifiable.Id.CRYSTAL_SLIME).AppearancesDefault[0].CrystalAppearance;
                customizedObject.AddComponent<CrystalSlimeLaunch>();
                customizedAppearance.CrystalAppearance = component;
            }
            if (ConfigurationBehaviours.HAS_DERVISH_TORNADO)
            {
                TornadoAppearance component = Slime.GetSlimeDef(Identifiable.Id.DERVISH_SLIME).AppearancesDefault[0].TornadoAppearance;
                DervishSlimeSpin dervishPrefab = Prefab.GetPrefab(Identifiable.Id.DERVISH_SLIME).GetComponent<DervishSlimeSpin>();
                customizedObject.AddComponent<DervishSlimeSpin>();
                customizedObject.GetComponent<DervishSlimeSpin>().fullWhirlwindPrefab = dervishPrefab.fullWhirlwindPrefab;
                customizedObject.GetComponent<DervishSlimeSpin>().tornadoLargoPrefab = dervishPrefab.tornadoLargoPrefab;
                customizedObject.GetComponent<DervishSlimeSpin>().tornadoPrefab = dervishPrefab.tornadoPrefab;
                customizedAppearance.TornadoAppearance = component;
            }
            /*if (ConfigurationBehaviours.HAS_QUANTUM_QUBIT)
            {
                GenerateQuantumQubit component = Prefab.GetPrefab(Identifiable.Id.QUANTUM_SLIME).GetComponent<GenerateQuantumQubit>();
                QuantumVibration component2 = Prefab.GetPrefab(Identifiable.Id.QUANTUM_SLIME).GetComponent<QuantumVibration>();
                QuantumSlimeSuperposition component3 = Prefab.GetPrefab(Identifiable.Id.QUANTUM_SLIME).GetComponent<QuantumSlimeSuperposition>();
                customizedObject.AddComponent<QuantumVibration>();
                customizedObject.GetComponent<QuantumVibration>().VibratingFX = component2.VibratingFX;
                customizedObject.AddComponent<QuantumSlimeSuperposition>();
                customizedObject.GetComponent<QuantumSlimeSuperposition>().SuperposeParticleFx = component3.SuperposeParticleFx;
                customizedObject.AddComponent<GenerateQuantumQubit>();
                customizedObject.GetComponent<GenerateQuantumQubit>().AppearanceApplicator = customizedObject.GetComponent<SlimeAppearanceApplicator>();
                customizedObject.GetComponent<GenerateQuantumQubit>().DissipateFx = component.DissipateFx;
                customizedObject.GetComponent<GenerateQuantumQubit>().QubitPrefab = component.QubitPrefab;
                customizedAppearance.QubitAppearance = customizedAppearance;
            }*/
            if (ConfigurationBehaviours.HAS_MOSAIC_GLINT)
            {
                GlintAppearance component = Slime.GetSlimeDef(Identifiable.Id.MOSAIC_SLIME).AppearancesDefault[0].GlintAppearance;
                customizedObject.AddComponent<GlintController>();
                customizedAppearance.GlintAppearance = component;
            }
            if (ConfigurationBehaviours.HAS_TANGLE_VINES)
            {
                VineAppearance component = Slime.GetSlimeDef(Identifiable.Id.TANGLE_SLIME).AppearancesDefault[0].VineAppearance;
                customizedObject.AddComponent<GroundVine>();
                customizedAppearance.VineAppearance = component;
            }
            if (ConfigurationBehaviours.HAS_TARR_GRAB)
            {
                TentacleGrapple component = Prefab.GetPrefab(Identifiable.Id.TARR_SLIME).GetComponent<TentacleGrapple>();
                customizedObject.AddComponent<TentacleGrapple>();
                customizedObject.GetComponent<TentacleGrapple>().causeFear = ConfigurationAdvanced.TARR_GRAB_CAUSE_FEAR;
                customizedObject.GetComponent<TentacleGrapple>().cooldown = ConfigurationAdvanced.TARR_GRAB_COOLDOWN;
                customizedObject.GetComponent<TentacleGrapple>().minSearchRad = ConfigurationAdvanced.TARR_GRAB_MIN_RADIUS;
                customizedObject.GetComponent<TentacleGrapple>().maxSearchRad = ConfigurationAdvanced.TARR_GRAB_MAX_RADIUS;
                customizedObject.GetComponent<TentacleGrapple>().tentaclePrefab = component.tentaclePrefab;
            }
            if (ConfigurationBehaviours.HAS_AGITATED_KILL)
            { customizedObject.AddComponent<AgitatedKill>(); customizedObject.GetComponent<AgitatedKill>().delay = ConfigurationAdvanced.AGITATED_KILL_DELAY; }
            if (ConfigurationBehaviours.HAS_SLIME_RUN_COMMAND)
            { customizedObject.AddComponent<SlimeRunCommand>(); customizedObject.GetComponent<SlimeRunCommand>().delay = ConfigurationAdvanced.SLIME_RUN_COMMAND_DELAY; }
        }
    }
}
