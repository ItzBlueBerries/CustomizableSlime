using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SRML.Console.Console;
using UnityEngine;
using System.Reflection;

namespace CustomizableSlime.behaviours
{
    public class AgitatedKill : SlimeSubbehaviour
    {
        public float delay;
        private float nextKill;
        private MethodInfo method;

        public override void Awake()
        {
            base.Awake();
            nextKill = Time.time + delay;
            method = AccessTools.Method(typeof(SRML.Console.Console), "ProcessInput");
        }

        public override void Action() { }

        public override float Relevancy(bool isGrounded)
        {
            if (Time.time >= nextKill && emotions.GetCurr(SlimeEmotions.Emotion.AGITATION) >= 0.5f)
                return 1f;
            return 0f;
        }

        public override void Selected()
        {
            Identifiable.Id randID = Randoms.SHARED.Pick(Identifiable.SLIME_CLASS.ToArray());
            if (randID == base.gameObject.GetComponent<Identifiable>().id && randID == ConfigurationAdvanced.AGITATED_KILL_IGNORE)
                return;
            method.Invoke(null, new object[] { "killall " + randID.ToString(), true });
            nextKill = Time.time + delay;
            ShortcutLib.Debugging.Log(base.gameObject.name + " has killed " + randID.ToString() + " due to agitation.");
        }
    }
}
