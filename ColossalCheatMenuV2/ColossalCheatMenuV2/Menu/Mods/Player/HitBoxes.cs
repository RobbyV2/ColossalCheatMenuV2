
using Colossal.Menu;
using Colossal.Patches;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class HitBoxes : MonoBehaviour
    {
        public static float ammount;
        public void Update()
        {
            if(PluginConfig.hitboxes)
            {
                switch(PluginConfig.hitboxesradius)
                {
                    case 0:
                        ammount = 0.05f;
                        break;
                    case 1:
                        ammount = 0.07f;
                        break;
                    case 2:
                        ammount = 0.09f;
                        break;
                    case 3:
                        ammount = 0.11f;
                        break;
                    case 4:
                        ammount = 0.13f;
                        break;
                    case 5:
                        ammount = 0.15f;
                        break;
                    case 6:
                        ammount = 0.3f;
                        break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(GorillaTagger), "sphereCastRadius", MethodType.Getter)]
    public class HitBoxesPatch
    {
        static void Postfix(ref float __result)
        {
            if (PluginConfig.hitboxes)
                __result = HitBoxes.ammount;
        }
    }
}
