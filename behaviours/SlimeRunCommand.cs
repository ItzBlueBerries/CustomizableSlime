using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomizableSlime.behaviours
{
    public class SlimeRunCommand : SlimeSubbehaviour
    {
        public float delay;
        private float nextRun;
        private MethodInfo method;

        public override void Awake()
        {
            base.Awake();
            nextRun = Time.time + delay;
            method = AccessTools.Method(typeof(SRML.Console.Console), "ProcessInput");
        }

        public override void Action() { }

        public override float Relevancy(bool isGrounded)
        {
            if (Time.time >= nextRun && emotions.GetCurr(ConfigurationAdvanced.SLIME_RUN_COMMAND_DRIVER) >= ConfigurationAdvanced.SLIME_RUN_COMMAND_DRIVER_AMOUNT)
                return 1f;
            return 0f;
        }

        public override void Selected()
        {
            method.Invoke(null, new object[] { ConfigurationAdvanced.SLIME_RUN_COMMAND_TRIGGER, true });
            nextRun = Time.time + delay;
        }
    }
}
