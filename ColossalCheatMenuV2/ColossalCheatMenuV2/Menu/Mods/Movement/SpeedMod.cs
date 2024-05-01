using Colossal.Menu;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class SpeedMod : MonoBehaviour
    {
        private int distance;
        public void Update()
        {
            if(PluginConfig.speed)
            {
                switch (PluginConfig.speedammount)
                {
                    case 0:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                        break;
                    case 1:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                        break;
                    case 2:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                        break;
                    case 3:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                        break;
                    case 4:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                        break;
                    case 5:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                        break;
                    case 6:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                        break;
                    case 7:
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                        break;
                        //case 9:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                        //    break;
                        //case 10:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                        //    break;
                        //case 11:
                        //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                        //    break;
                }
            }

            if(PluginConfig.speedlg)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    switch (PluginConfig.speedlgammount)
                    {
                        case 0:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                            break;
                        case 1:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                            break;
                        case 2:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                            break;
                        case 3:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                            break;
                        case 4:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                            break;
                        case 5:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                            break;
                        case 6:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                            break;
                        case 7:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                            break;
                            //case 9:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                            //    break;
                            //case 10:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                            //    break;
                            //case 11:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                            //    break;
                    }
                }
                else if (!ControllerInputPoller.instance.rightGrab && PluginConfig.speedlgammount != 0)
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                    else
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            }

            if(PluginConfig.speedrg)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    switch (PluginConfig.speedrgammount)
                    {
                        case 0:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                            break;
                        case 1:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                            break;
                        case 2:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                            break;
                        case 3:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                            break;
                        case 4:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                            break;
                        case 5:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                            break;
                        case 6:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                            break;
                        case 7:
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                            break;
                            //i am very good at making stuff undetected -Lars
                            //case 9:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.8f;
                            //    break;
                            //case 10:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
                            //    break;
                            //case 11:
                            //    GorillaLocomotion.Player.Instance.maxJumpSpeed = int.MaxValue;
                            //    break;
                    }
                }
                else if (!ControllerInputPoller.instance.leftGrab && PluginConfig.speedrgammount != 0)
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                    else
                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            }

            if(PluginConfig.nearspeed)
            {
                foreach(VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if(!vrrig.isOfflineVRRig && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected"))
                    {
                        if (vrrig.mainSkin.material.name.ToLower().Contains("fected"))
                        {
                            if (PluginConfig.nearspeeddistance <= Vector3.Distance(GorillaTagger.Instance.transform.position, vrrig.transform.position))
                            {
                                switch (PluginConfig.nearspeedmmount)
                                {
                                    case 0:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.2f;
                                        break;
                                    case 1:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.4f;
                                        break;
                                    case 2:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.6f;
                                        break;
                                    case 3:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.8f;
                                        break;
                                    case 4:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                                        break;
                                    case 5:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.2f;
                                        break;
                                    case 6:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.4f;
                                        break;
                                    case 7:
                                        GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.6f;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
