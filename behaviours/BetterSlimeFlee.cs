using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ShortcutLib;

namespace CustomizableSlime.behaviours
{
    internal class BetterSlimeFlee : SlimeFlee
    {
        public void Update()
        {
            //SRML.Console.Console.Log("Checking if the slime is currently fleeing...");
            if (!base.IsFleeing())
            {
                //SRML.Console.Console.Log("Slime is not fleeing. Checking for distance...");
                float dist;
                dist = Vector3.Distance(base.gameObject.transform.position, Camera.main.transform.position);
                Debugging.Log("Distance is " + Convert.ToString(dist));
                if (dist <= this.fleeDist)
                {
                    GameObject playerPosition = new GameObject("playerpos");
                    playerPosition.transform.position = Camera.main.transform.position;
                    //SRML.Console.Console.Log("Fleeing from player...");
                    this.StartFleeing(playerPosition);
                }
            }
        }

        public float fleeDist = ConfigurationAdvanced.SLIME_FLEE_DISTANCE;
    }
}
